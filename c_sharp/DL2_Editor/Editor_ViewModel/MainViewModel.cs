namespace Editor_ViewModel
{
    using Editor_Model.EventArgs;
    using Editor_Model.Logic;
    using Editor_ViewModel.Interfaces;
    using Editor_ViewModel.Languages;
    using Editor_ViewModel.Logic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {
        private string fileContents;

        private ObservableCollection<ILanguageDisplay> supportedLanguages;

        private ILanguageDisplay selectedLanguage;

        private PageNameEnum currentPage;

        private FileAnalizerVM fileAnalizer;

        private SaveFile saveFile;

        public MainViewModel()
        {
            this.supportedLanguages = this.CreateSupportedLanguages();
            this.SelectedLanguage = new EnglishUI();
            this.IsChangeLanguageSelected = true;
            this.FileContents = this.SelectedLanguage.NoFileSelected;
            this.FileAnalizer = new FileAnalizerVM();
            this.FileAnalizer.AnalizedSaveFile += this.OnAnalizedFile;
            this.FileAnalizer.ErrorMessage += this.OnErrorMessage;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string FileContents
        {
            get
            {
                return this.fileContents;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.FileContents)} must not be null!");
                }

                this.fileContents = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
            }
        }

        public ObservableCollection<ILanguageDisplay> SupportedLanguages { get => this.supportedLanguages; }

        public ILanguageDisplay SelectedLanguage
        {
            get
            {
                return this.selectedLanguage;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SelectedLanguage)} must not be null!");
                }

                this.selectedLanguage = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedLanguage)));
            }
        }

        public bool IsChangeLanguageSelected { get; set; }

        public PageNameEnum CurrentPage
        {
            get
            {
                return this.currentPage;
            }

            private set
            {
                this.currentPage = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentPage)));
            }
        }

        public FileAnalizerVM FileAnalizer
        {
            get
            {
                return this.fileAnalizer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.FileAnalizer)} must not be null!");
                }

                this.fileAnalizer = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileAnalizer)));
            }
        }

        public SaveFile SaveFile
        {
            get
            {
                return this.saveFile;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.SaveFile)} must not be null!");
                }

                this.saveFile = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SaveFile)));
            }
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

        public ICommand ChangeLanguageSelction
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.IsChangeLanguageSelected = !this.IsChangeLanguageSelected;
                });
            }
        }

        public ICommand SelectingNewLanguge
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    ILanguageDisplay tmp = this.SelectedLanguage;
                    try
                    {
                        tmp = obj as ILanguageDisplay;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                    }

                    if (tmp != null)
                    {
                        this.SelectedLanguage = tmp;
                        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedLanguage)));
                        this.FileContents = this.SelectedLanguage.NoFileSelected;
                        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
                    }
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

                    //// the fileContents byte array contains the binary data from the file
                    //this.FileContents = BitConverter.ToString(fileContents).Replace("-", " ");
                    this.FileAnalizer.AnalyzeUnlockableItemsData(fileContents);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
        }

        protected void OnErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            // Send Notification!
        }

        protected void OnAnalizedFile(object sender, AnalizedSaveFileEventArgs e)
        {
            this.SaveFile = e.SaveFile;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SaveFile.Items)));
        }

        private ObservableCollection<ILanguageDisplay> CreateSupportedLanguages()
        {
            return new ObservableCollection<ILanguageDisplay>()
            {
                new EnglishUI(),
                new GermanUI(),
                new SpanishUI()
            };
        }
    }
}