using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelHai.CS.CsharpCourse._05_Wpflinq.Models;

//Idan Rossin 212102776

namespace TelHai.CS.CsharpCourse._05_Wpflinq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Class Level Variable to hold the data
        // We use ObservableCollection so the UI updates automatically when we delete
        private ObservableCollection<Song> _songsCollection;

        // We need a backup list to support "Search" (so we can go back to the full list)
        private List<Song> _originalList;

        // Toggles for sorting
        private bool _isDurationAscending = true;
        private bool _isTitleAscending = true;

        public MainWindow()
        {
            InitializeComponent();
            this.songsListBox.SelectionChanged += SongsListBox_SelectionChanged;
        }

        private void SongsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (songsListBox.SelectedItem != null)
            {
                if (lbl != null)
                {
                    lbl.Content = songsListBox.SelectedItem.ToString();
                }
            }
        }
        /*
        int index = 0;

        // <Button Name ="btn1" Margin="5,5,5,0" Content="Button1 (unused)" />
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            index++;
            this.songsListBox.Items.Add("Item " + index);
        }

        List<Song> songs = new List<Song>()
            {
                new Song { Id = Guid.NewGuid().ToString(), Name = "song 1", Duration = 4.20f },
                new Song { Id = Guid.NewGuid().ToString(), Name = "song 2", Duration = 3.20f },
                new Song { Id = Guid.NewGuid().ToString(), Name = "song 3", Duration = 2.20f },
                new Song { Id = Guid.NewGuid().ToString(), Name = "song 4", Duration = 1.20f }
            };

        // <Button Name ="btn2" Margin="5,5,5,0" Content="Button2 (unused)" />
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            //this.songsListBox.ItemsSource = null;
            //this.songsListBox.ItemsSource = songs;

            var rangeList = songs
                .Where(s => s.Duration > 1f && s.Duration < 2.5f)
                .OrderBy(s => s.Duration);

            songsListBox.Items.Clear();
            foreach (Song s in rangeList)
            {
                songsListBox.Items.Add(s);
            }
        }
        */

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of 50 songs from the Singleton Service
            List<Song> newSongs = RandomSongService.Instance.GenerateSongs(50);

            _originalList = newSongs;

            // Convert to ObservableCollection and store in the class-level variable
            _songsCollection = new ObservableCollection<Song>(newSongs);

            // Bind the UI to this collection
            songsListBox.ItemsSource = _songsCollection;
            CalculateStatistics();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Check if a song is actually selected
            if (songsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a song to delete first.");
                return;
            }

            // Get the selected song object
            Song songToDelete = songsListBox.SelectedItem as Song;

            // Remove it from the collection
            // Because it is an ObservableCollection, it disappears from the ListBox immediately
            if (songToDelete != null && _songsCollection != null)
            {
                _songsCollection.Remove(songToDelete);
                _originalList.Remove(songToDelete);
                if (lbl != null)
                {
                    lbl.Content = "Songs";
                }
            }
            CalculateStatistics();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_songsCollection == null)
            {
                _songsCollection = new ObservableCollection<Song>();
                songsListBox.ItemsSource = _songsCollection;
            }

            // Validation for texts
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtArtist.Text))
            {
                MessageBox.Show("Please enter both Title and Artist.");
                return;
            }

            // Validation for duration
            if (!double.TryParse(txtDuration.Text, out double duration) || duration < 1 || duration > 10)
            {
                MessageBox.Show("Duration must be a number between 1 and 10.");
                return;
            }

            Song newSong = new Song
            {
                Title = txtTitle.Text,
                Artist = txtArtist.Text,
                Duration = duration 
            };
            
            _songsCollection.Add(newSong);
            _originalList.Add(newSong);
            CalculateStatistics();

            // Clear Fields 
            txtTitle.Clear();
            txtArtist.Clear();
            txtDuration.Clear();
        }

        private void BtnSort1_Click(object sender, RoutedEventArgs e)
        {
            // SORT BY DURATION
            if (_songsCollection == null || _songsCollection.Count == 0) return;

            // Create a sorted version of the current collection
            IEnumerable<Song> sorted;

            if (_isDurationAscending)
                sorted = _songsCollection.OrderBy(s => s.Duration);
            else
                sorted = _songsCollection.OrderByDescending(s => s.Duration);
            
            // Update toggle for next time
            _isDurationAscending = !_isDurationAscending;

            // Update the UI
            UpdateListAndStats(sorted);
        }

        private void BtnSort2_Click(object sender, RoutedEventArgs e)
        {
            // SORT BY TITLE
            if (_songsCollection == null || _songsCollection.Count == 0) return;

            // Create a sorted version of the current collection
            IEnumerable<Song> sorted;

            if (_isTitleAscending)
                sorted = _songsCollection.OrderBy(s => s.Title); 
            else
                sorted = _songsCollection.OrderByDescending(s => s.Title);

            // Update toggle for next time
            _isTitleAscending = !_isTitleAscending;

            // Update the UI
            UpdateListAndStats(sorted);
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (_originalList == null) return;

            string query = txtSearch.Text.ToLower(); // Case Insensitive

            // If search is empty, return to original list (Sorted by Title as per requirements)
            if (string.IsNullOrWhiteSpace(query))
            {
                var resetList = _originalList.OrderBy(s => s.Title);
                UpdateListAndStats(resetList);
            }
            else
            {
                // Title contains OR Artist contains
                var filtered = _originalList.Where(s => s.Title.ToLowerInvariant().Contains(query) || s.Artist.ToLowerInvariant().Contains(query)); 

                UpdateListAndStats(filtered);
            }
        }

        private void BtnShortHits_Click(object sender, RoutedEventArgs e)
        {
            // SHORT HITS: Duration < 3.0, Sorted by Title
            if (_originalList == null) return;

            var shortHits = _originalList
                            .Where(s => s.Duration < 3.0)  // Filter duration
                            .OrderBy(s => s.Title);        // Sort by Title

            UpdateListAndStats(shortHits);
        }

        // This updates the ListBox AND calculates the Statistics
        private void UpdateListAndStats(IEnumerable<Song> sourceList)
        {
            if(sourceList != null)
            {
                // Convert to ObservableCollection so existing Delete/Add buttons still work
                _songsCollection = new ObservableCollection<Song>(sourceList);
                songsListBox.ItemsSource = _songsCollection;
            }

            CalculateStatistics();
        }

        private void CalculateStatistics()
        {
            // If the list is missing or empty, reset to 0
            if (_songsCollection == null || _songsCollection.Count == 0)
            {
                txtTotalDuration.Text = "0";
                txtAverageLength.Text = "0";
                txtLongestSong.Text = "-";
                return;
            }

            // Perform Calculations
            double totalDuration = _songsCollection.Sum(s => s.Duration);
            double avgDuration = _songsCollection.Average(s => s.Duration);

            string longestSongName = _songsCollection
                                        .OrderByDescending(s => s.Duration)
                                        .First()
                                        .Title;

            txtTotalDuration.Text = totalDuration.ToString();
            txtAverageLength.Text = avgDuration.ToString("F2");
            txtLongestSong.Text = longestSongName;
        }

        private void BtnGroupBy_Click(object sender, RoutedEventArgs e)
        {
            if (_songsCollection == null || _songsCollection.Count == 0)
            {
                MessageBox.Show("No songs to group.");
                return;
            }

            // Group by Artist
            var groupedSongs = _songsCollection.GroupBy(s => s.Artist);

            // Build the string output
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Songs per Artist:");

            foreach (var group in groupedSongs)
            {
                // group.Key = The Artist Name
                // group.Count() = The number of songs for that artist
                sb.AppendLine($"{group.Key}: {group.Count()} songs");
            }

            // Display in MessageBox
            MessageBox.Show(sb.ToString(), "Artist Groups");
        }


    }


}
