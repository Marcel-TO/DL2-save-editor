namespace Editor_ViewModel
{
    using Editor_Model.EventArgs;
    using Editor_Model.Items;
    using Editor_Model.Logic;
    using Editor_ViewModel.Interfaces;
    using Editor_ViewModel.Languages;
    using Editor_ViewModel.Logic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {
        private string fileContents;

        private ObservableCollection<ILanguageDisplay> supportedLanguages;

        private ILanguageDisplay selectedLanguage;

        private PageNameEnum currentPage;

        private FileAnalizerVM fileAnalizer;

        private SaveFile saveFile;

        private IdSearcherVM idSearcher;

        private IdData[] idData;

        public MainViewModel()
        {
            this.supportedLanguages = this.CreateSupportedLanguages();
            this.SelectedLanguage = new EnglishUI();
            this.IsChangeLanguageSelected = true;
            this.FileContents = this.SelectedLanguage.NoFileSelected;
            this.FileAnalizer = new FileAnalizerVM();
            this.FileAnalizer.AnalizedSaveFile += this.OnAnalizedFile;
            this.FileAnalizer.ErrorMessage += this.OnErrorMessage;
            this.FileAnalizer.ChangedSkillItems += this.OnSkillItemsChanged;
            this.IdSearcher = new IdSearcherVM();
            this.IdSearcher.OnIdSearch += this.OnIdSearch;
            this.IdSearcher.GetIDs();

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
                //if (value == null)
                //{
                //    throw new ArgumentNullException($"The {nameof(this.SaveFile)} must not be null!");
                //}

                this.saveFile = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SaveFile)));
            }
        }

        public IdData[] IdData
        {
            get
            {
                return this.idData;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.IdData)} must not be null!");
                }

                this.idData = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IdData)));
            }
        }

        public IdSearcherVM IdSearcher
        {
            get
            {
                return this.idSearcher;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.IdSearcher)} must not be null!");
                }

                this.idSearcher = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IdSearcher)));
            }
        }

        public bool IsSaveFileNull
        {
            get
            {
                return this.CheckIfSaveFileIsNull();
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

        /// <summary>
        /// Gets the command for exiting the game.
        /// </summary>
        /// <value>The command which exits the game.</value>
        public ICommand ResetCurrentSaveFile
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.SaveFile = null;
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

        /// <summary>
        /// Gets the command for changing the value.
        /// </summary>
        /// <value>The command which changes the value.</value>
        public ICommand ChangeSkillValueCommand
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    if (obj is object[])
                    {
                        object[] parameters = (object[])obj;

                        if (parameters.Length != 5 && parameters[0] is not int && parameters[1] is not string && parameters[2] is not string && parameters[3] is not string && parameters[4] is not int)
                        {
                            return;
                        }

                        int index = (int)parameters[0];
                        string name = (string)parameters[1];
                        string beforeChange = (string)parameters[2];
                        string afterChange = (string)parameters[3];
                        int size = (int)parameters[4];

                        this.FileAnalizer.ChangeSkillItems(this.SaveFile, index, name, size, beforeChange, afterChange);
                    }
                });
            }
        }

        public void LoadFile(string filePath)
        {
            this.FileAnalizer.ReadSaveFile(filePath);
        }

        protected void OnErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            // Send Notification!
        }

        protected void OnAnalizedFile(object sender, AnalizedSaveFileEventArgs e)
        {
            this.SaveFile = e.SaveFile;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SaveFile)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FileContents)));
        }

        protected void OnIdSearch(object sender, FoundIDsEventArgs e)
        {
            this.IdData = e.IdData;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IdData)));

        }

        protected void OnSkillItemsChanged(object sender, ChangedItemsEventArgs e)
        {
            this.SaveFile = new SaveFile("",new byte[] {}, "",new List<InventoryItem[]>(), new Skills(new SkillIItem[] {}, new SkillIItem[] {}), new UnlockableItems[] {});
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SaveFile)));
            this.SaveFile = e.Savegame;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SaveFile)));
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

        private bool CheckIfSaveFileIsNull()
        {
            if (this.SaveFile == null)
            {
                return true;
            }

            return false;
        }
    }
}