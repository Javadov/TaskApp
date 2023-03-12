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
using Newtonsoft.Json.Linq;
using System.Windows.Controls.Primitives;
using TaskApp.MVVM.Views;
using System.Windows.Media;
using System.Windows.Controls;
using System.Runtime.Intrinsics.X86;
using Microsoft.JSInterop;

namespace TaskApp.MVVM.ViewModels
{
    internal partial class IssuesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Alla Ärenden";


        [ObservableProperty]
        private ObservableCollection<Issue> issues;

        public IssuesViewModel()
        {
            LoadIssues();
        }

        public async Task LoadIssues()
        {
            IEnumerable<Issue> issues = await DataService.GetAllAsync();
            Issues = new ObservableCollection<Issue>(issues);
        }

        public async Task LoadPage()
        {
            new ObservableCollection<Issue>();
        }

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
        public void ToSearch()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new SearchViewModel()));
        }

        #region Remove Task
        [RelayCommand]
        public async void Remove()
        {
            MessageBoxResult result = MessageBox.Show("Är du säker på att ta bort den?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            var issue = SelectedIssue;

            if (result == MessageBoxResult.Yes)
            {
                await DataService.DeleteAsync(issue);
            }
            LoadIssues();
        }
        #endregion

        #region Change Task Status
        [RelayCommand]
        public async void Select1()
        {
            var issue = SelectedIssue;

            issue.Status = 1;

            await DataService.UpdateAsync(issue);
            LoadIssues();
        }

        [RelayCommand]
        public async void Select2()
        {
            var issue = SelectedIssue;

            issue.Status = 2;

            await DataService.UpdateAsync(issue);
            LoadIssues();
        }

        [RelayCommand]
        public async void Select3()
        {
            var issue = SelectedIssue;

            issue.Status = 3;

            await DataService.UpdateAsync(issue);
            LoadIssues();
        }
        #endregion

        #region Hide/Show Comments
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
        #endregion

        [ObservableProperty]
        private string comment = string.Empty;


        [ObservableProperty]
        private Comment selectedComment = null!;


        [RelayCommand]
        private async void AddComment()
        {
            var database = new DataService();

            await database.SaveCommentAsync(new CommentEntity
            {                
                Comment = Comment,
                IssueId = SelectedIssue.Id,
                DateTime = DateTime.Now                
            });
        }

        [RelayCommand]
        private async void DeleteComment()
        {
            MessageBoxResult confirm = MessageBox.Show("Är du säker på att ta bort den?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            var comment = selectedComment;

            if (confirm == MessageBoxResult.Yes)
            {
                await DataService.DeleteCommentAsync(comment);
            }
        }
    }
}
