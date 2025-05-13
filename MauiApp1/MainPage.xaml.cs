using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1;

public class BaseBindable : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
}

public abstract class BaseContentPage<TViewModel> : ContentPage where TViewModel : BaseBindable
{
}


public abstract class BasePageViewModel<TItemViewModel> : BaseBindable
    where TItemViewModel : BaseModel
{
    public ICommand TestCommand => new Command(OnTestCommand);

    private void OnTestCommand(object obj)
    {
        Application.Current.MainPage.DisplayAlert("Test", "XamlC works well", "OK");
    }
}

public abstract class BaseModel
{
    
}

public class MainPageModel : BaseModel
{
    
}

public class MainPageViewModel : BasePageViewModel<MainPageModel>
{
}

public partial class MainPage : BaseContentPage<BasePageViewModel<BaseModel>>
{
    public MainPage()
    {
        BindingContext = new MainPageViewModel();
        InitializeComponent();
    }
}