# Dying Light 2 Editor

---
- [Dying Light 2 Editor](#dying-light-2-editor)
  - [Introdcution](#introdcution)
  - [Prerequisites for programming](#prerequisites-for-programming)
  - [User Interface for application](#user-interface-for-application)
  - [Code Explanation](#code-explanation)
    - [Design Pattern](#design-pattern)
    - [Language Support](#language-support)
    - [Pages](#pages)
    - [Communication between View and ViewModel](#communication-between-view-and-viewmodel)
    - [Structure](#structure)
  - [Contributers](#contributers)

---

## Introdcution
Introducing our work-in-progress application, the first public Dying Light 2 Editor! Developed by a dedicated team of two passionate gamers, our editor empowers you to take control of your Dying Light 2 experience like never before. With this tool, you can manipulate stats and customize items to tailor your in-game adventure to your liking. While not all features are implemented just yet, we're committed to continuously improving and expanding our editor to enhance your gaming journey. Stay tuned for updates and join us in shaping your Dying Light 2 experience!

## Prerequisites for programming
- A Windows-based computer
- [.NET Framework](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwjvqfunheSBAxWRRPEDHWFtC8YQFnoECCoQAQ&url=https%3A%2F%2Fdotnet.microsoft.com%2Fen-us%2F&usg=AOvVaw11IVg-jth7EB7DUyQDipCa&opi=89978449) or .NET Core runtime (currently using TargetFramework `net6.0`)
- Visual Studio (For further information about .NET please click [here](https://learn.microsoft.com/en-us/visualstudio/get-started/visual-basic/tutorial-console?view=vs-2022))


## User Interface for application
The Application contains a customized toolbar at the top. It allows the User to do certain administrative interactions with the application like the following:
- InfoPage with a short introduction and explanation
- LanguageSupport (The application supports different languages and even allows introducing a new language with a breeze. More regarding this topic will be explained in the chapter [Code Explanation](#code-explanation))
- Exit Application Button

The main body of the application contains of a navigation bar with selections like `Skills` or `Inventory` to allow the user to navigate between the different pages. Each page displays the current contents of the save file and gives the possibility to manipulate the values and change them

## Code Explanation
### Design Pattern
The MVVM (Model-View-ViewModel) programming model is a design pattern used in software development, particularly in the context of graphical user interface (GUI) applications like those built using WPF (Windows Presentation Foundation) and other similar frameworks. MVVM helps to separate an application's user interface (UI) logic from the underlying business logic and data. Here's an explanation of the MVVM pattern:

![mvvm](https://github.com/Marcel-TO/Verse-Interpreter-in-Python/assets/91308057/f1557ed2-ff83-411c-96d0-b36ee214c565)

*Model*:
The Model represents the application's data and business logic. It contains classes that define the structure and behavior of the data. The Model is responsible for retrieving, processing, and manipulating data. It does not have any direct knowledge of the user interface.

*View*:
The View is responsible for presenting the data to the user and handling user interactions. It corresponds to the visual elements of the application, such as windows, pages, controls, and user interface components. In the MVVM pattern, the View is as passive as possible, meaning it should have minimal code related to business logic.

*ViewModel*:
The ViewModel acts as an intermediary between the Model and the View. It serves as a data and command provider for the View, translating data from the Model into a format that can be easily displayed in the View. It also handles user input from the View and processes it before passing it on to the Model. The ViewModel encapsulates the application's presentation logic.


*Key aspects of the MVVM pattern*:

*Data Binding*: MVVM relies heavily on data binding mechanisms provided by frameworks like WPF. Data binding establishes a connection between the ViewModel and the View, automatically updating the UI when data changes in the ViewModel and vice versa.

*Commands*: MVVM uses commands to handle user interactions. Commands are actions or methods that can be executed in response to user input, such as button clicks or menu selections. ViewModels expose commands that the View can bind to UI elements.

*Testability*: MVVM enhances testability by separating the UI logic (ViewModel) from the data (Model) and the actual UI (View). This makes it easier to write unit tests for the ViewModel and the Model, as they can be tested independently of the UI.

*Flexibility*: MVVM promotes a modular and maintainable code structure, making it easier to update or replace the user interface without affecting the underlying logic. It also supports the development of cross-platform applications.

*Scalability*: MVVM can scale to accommodate large and complex applications by breaking them into manageable components. Each View can have its associated ViewModel, and multiple Views can use the same ViewModel.

Overall, the MVVM pattern improves the separation of concerns in your application, making it more maintainable, testable, and adaptable to changes in UI design or business logic. It's particularly well-suited for applications where a clean separation of the UI from the application logic is essential.

### Language Support
All general Texts that are specified in the according language interface [ILanguageDisplay.cs](./Editor_ViewModel/Interfaces/ILanguageDisplay.cs). If the need for another language is required, a new Class inside the languages directory that inherits the interface from before is all it takes to implement a new language. But to be able to select it, it must be instanced in the [MainViewModel](./Editor_ViewModel/MainViewModel.cs) as well. The method is called `CreateSupportedLanguages`.

### Pages
For each selectable page, a corresponding view is created in the Views directory. The content of the views don't include the navigation bar or the toolbar at the top. Those are in the main window.

### Communication between View and ViewModel
*View to ViewModel*:
Property binding allows you to bind UI elements in the View (e.g., text boxes, labels) to properties in the ViewModel. When a user interacts with a bound UI element (e.g., enters text into a text box), the value is automatically synchronized with the corresponding property in the ViewModel. This means that changes made in the UI are reflected in the ViewModel, and vice versa, without the need for explicit code to update the UI.
```xaml
<Window x:Class="MyApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MVVM Data Binding Example" Height="200" Width="300"
        DataContext="{Binding MyViewModel}">
    <Grid>
        <TextBox Text="{Binding TextValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                 HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Window>
```

*ViewModel to View*:
Property binding also works in the other direction. When properties in the ViewModel are updated (e.g., data retrieved from a database), the bound UI elements in the View automatically reflect these changes. This seamless synchronization simplifies the process of displaying and updating data in the UI.
```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MyViewModel : INotifyPropertyChanged
{
    private string _textValue;

    public string TextValue
    {
        get { return _textValue; }
        set
        {
            if (_textValue != value)
            {
                _textValue = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextValue)));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}

```

> The PropertyChanged event is very important, otherwise the View would not really notice if the textvalue would change

### Structure
The MainViewModel communicates with the Model to initiate data-related operations. This communication typically involves calling methods or properties in the Model. For example, when a user clicks a button in the View to process a file, the MainViewModel triggers a method in the Model responsible for reading and processing the file's bytes.

## Contributers
Currently there are 2 contributers that work hard to increase the experience of Dying Light 2. With the help of Caz`s incredible knowledge of savegamefiles and the coding experience of Marcel, the Editor is not only extremely useful, but has a modern UI with Dying Light 2 themed content.


<p>
  <a href="https://github.com/zCaazual">
    <img src="https://img.shields.io/badge/Github-zCazual-899994"/>
  </a>
</p>
<p>
  <a href="https://github.com/Marcel-TO">
    <img src="https://img.shields.io/badge/Github-Marcel-526264"/>
  </a>
</p>