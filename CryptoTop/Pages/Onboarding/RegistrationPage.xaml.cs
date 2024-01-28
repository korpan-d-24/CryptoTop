using CommunityToolkit.Maui.Core.Platform;

namespace CryptoTop.Pages.Onboarding;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage(RegistrationViewModel registrationViewModel)
    {
        InitializeComponent();
        registrationViewModel.HideKeyboardCommand = new Command(async () => { await KeyboardExtensions.HideKeyboardAsync(HideKeyboardEntry, default); ((Command)registrationViewModel.HideKeyboardCommand).ChangeCanExecute(); });
        BindingContext = registrationViewModel;
    }
}