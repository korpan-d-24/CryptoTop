using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CryptoTop.Services;

public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged
{
    public virtual Task OnNavigatingTo(object? parameter)
        => Task.CompletedTask;
    public virtual Task OnNavigatingTo(object? firstParameter, object? secondParameter)
        => Task.CompletedTask;

    public virtual Task OnNavigatedFrom(bool isForwardNavigation)
        => Task.CompletedTask;

    public virtual Task OnNavigatedTo()
        => Task.CompletedTask;

    public event PropertyChangedEventHandler PropertyChanged;
    public void RaisePropertyChange(string propertyname)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}