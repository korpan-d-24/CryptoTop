using CommunityToolkit.Maui.Core.Platform;
namespace CryptoTop.Pages.Onboarding;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        loginViewModel.HideKeyboardCommand = new Command(async () => { await KeyboardExtensions.HideKeyboardAsync(HideKeyboardEntry, default); ((Command)loginViewModel.HideKeyboardCommand).ChangeCanExecute(); });
        BindingContext = loginViewModel;
    }
}