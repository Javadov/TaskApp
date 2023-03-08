using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;
using TaskApp.Services;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using static TaskApp.MVVM.ViewModels.MainViewModel;

namespace TaskApp.MVVM.ViewModels
{
    internal partial class IssuesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Alla Ärenden";


        [ObservableProperty]
        private ObservableCollection<Issue> issues = DataService.Issues;

        [ObservableProperty]
        private Issue selectedIssue = null!;

        [RelayCommand]
        public void Back() 
        {
           Messenger.Default.Send(new ChangeViewModelMessage(new IssuesViewModel()));
        }

        [RelayCommand]
        public void Home()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new HomeViewModel()));
        }

        [RelayCommand]
        public void ToIssues()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new IssuesViewModel()));
        }

        [RelayCommand]
        public void ToAddIssue()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new AddIssueViewModel()));
        }

        [RelayCommand]
        public void Remove()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure about deleting it?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        
                  if (result == MessageBoxResult.Yes)
                {
                  issues.Remove(selectedIssue);
            }
        }

        private bool _isCommentVisible;
 
        public Visibility CommentVisibility
        {
            get => _isCommentVisible ? Visibility.Visible : Visibility.Collapsed;
            set
            {
                _isCommentVisible = value == Visibility.Visible;
                OnPropertyChanged(nameof(CommentVisibility));
            }
        }
        [RelayCommand]
        private void ToggleComment()
        {
            CommentVisibility = _isCommentVisible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
