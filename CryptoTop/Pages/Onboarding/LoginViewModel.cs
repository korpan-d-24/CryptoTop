using CommunityToolkit.Mvvm.Input;
using CryptoTop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoTop.Pages.Onboarding;
public partial class LoginViewModel : ViewModelBase
{
    private INavigationService _navigationService;
    private static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    #region Properties
    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            if (_email == value)
                return;
            _email = value;
            RaisePropertyChange(nameof(Email));
        }
    }
    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            if (_password == value)
                return;
            _password = value;
            RaisePropertyChange(nameof(Password));
        }
    }
    private string _erorMassege;
    public string ErrorMessage
    {
        get => _erorMassege;
        set
        {
            if (_erorMassege == value)
                return;
            _erorMassege = value;
            RaisePropertyChange(nameof(ErrorMessage));
        }
    }
    private bool _isEmailInvalid;
    public bool IsEmailInvalid
    {
        get => _isEmailInvalid;
        set
        {
            if (_isEmailInvalid == value)
                return;
            _isEmailInvalid = value;
            RaisePropertyChange(nameof(IsEmailInvalid));
        }
    }
    private bool _isPasswordInvalid;
    public bool IsPasswordInvalid
    {
        get => _isPasswordInvalid;
        set
        {
            if (_isPasswordInvalid == value)
                return;
            _isPasswordInvalid = value;
            RaisePropertyChange(nameof(IsPasswordInvalid));
        }
    }
    #endregion

    #region Commands
    public Command NavigateCommand => new Command(async () => await _navigationService.NavigateToRegistrationPage());
    public ICommand HideKeyboardCommand { get; set; }
    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrEmpty(Email))
        {
            ErrorMessage = "Enter the Email";
            IsEmailInvalid = true;
            return;
        }
        if (!EmailRegex.IsMatch(Email))
        {
            ErrorMessage = "Mailbox in the wrong format";
            IsEmailInvalid = true;
            return;
        }
        if (string.IsNullOrEmpty(Password))
        {
            ErrorMessage = "Enter the password";
            IsPasswordInvalid = true;
            return;
        }
        if (Password.Length < 8)
        {
            ErrorMessage = "Password too short, minimum 8 symbols";
            IsPasswordInvalid = true;
            return;
        }

        // SingIn

    }
    #endregion

    #region Constructor
    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    #endregion
}
