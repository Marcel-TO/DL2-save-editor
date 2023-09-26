namespace Editor_ViewModel
{
    using Sudoku_ViewModel;
    using System.ComponentModel;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            this.FileContents = "Please select a File to see the full hex code. Keep in Mind though, that loading the file could take a while.";

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string FileContents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the command for exiting the game.
        /// </summary>
        /// <value>The command which exits the game.</value>
        public ICommand ExitApplicationCommand
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    Environment.Exit(0);
                });
            }
        }

        public void LoadFile(string filePath)
        {
            try
            {
                // Open the file for reading in binary mode
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Create a byte array to hold the file contents
                    byte[] fileContents = new byte[fs.Length];

                    // Read the binary data from the file into the byte array
                    fs.Read(fileContents, 0, (int)fs.Length);

                    // Now, the fileContents byte array contains the binary data from the file
                    // You can work with the data as needed
                    this.FileContents = BitConverter.ToString(fileContents).Replace("-", " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
        }
    }
}