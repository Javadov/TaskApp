using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskApp.MVVM.ViewModels.MainViewModel;

namespace TaskApp.MVVM.ViewModels
{
    internal partial class HomeViewModel : ObservableObject
    {
        [RelayCommand]
        public void ToAddIssue()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new AddIssueViewModel()));
        }

        [RelayCommand]
        public void ToIssues()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new IssuesViewModel()));
        }
    }
}
