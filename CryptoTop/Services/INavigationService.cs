using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTop.Services;
public interface INavigationService
{
    INavigation Navigation { get; }

    Task NavigateToRegistrationPage();
    Task NavigateBack();
    Task NavigateToLoginPage();
}