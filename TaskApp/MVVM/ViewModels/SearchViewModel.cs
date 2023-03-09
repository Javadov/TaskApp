using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskApp.MVVM.ViewModels.MainViewModel;
using System.Windows;
using TaskApp.MVVM.Models;
using TaskApp.Services;

namespace TaskApp.MVVM.ViewModels
{
    internal partial class SearchViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Sök Ärende";


        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private static ObservableCollection<Issue> issue;

        public SearchViewModel()
        {
            Issue = new ObservableCollection<Issue>();
        }

        public async Task LoadPage()
        {
            new ObservableCollection<Issue>();
        }


        #region Get Specific Issues
        [RelayCommand]
        public async Task Search()
        {
            var email = Email;

            if (!string.IsNullOrEmpty(email))
            {
                IEnumerable<Issue> issue = await DataService.GetAsync(email);

                if (issue != null && issue.Any())
                {
                    Issue = new ObservableCollection<Issue>(issue);
                }
                else
                {

                    MessageBox.Show("Ingen kund med den angivna e-postadressen hittades");
                }
            }
            else
            {
                MessageBox.Show("Ingen e-postadress angiven ");
            }
        }
        #endregion


        [ObservableProperty]
        private Issue selectedIssue = null!;

        [RelayCommand]
        public void Back()
        {
            Messenger.Default.Send(new ChangeViewModelMessage(new SearchViewModel()));
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
        public async void Remove()
        {
            MessageBoxResult result = MessageBox.Show("Är du säker på att ta bort den?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            var issue = SelectedIssue;

            if (result == MessageBoxResult.Yes)
            {
                await DataService.DeleteAsync(issue);
            }
            LoadPage();
        }

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

        [RelayCommand]
        public async void Select1()
        {
            var issue = SelectedIssue;

            issue.Status = 1;

            await DataService.UpdateAsync(issue);
            LoadPage();
        }

        [RelayCommand]
        public async void Select2()
        {
            var issue = SelectedIssue;

            issue.Status = 2;

            await DataService.UpdateAsync(issue);
            LoadPage();
        }

        [RelayCommand]
        public async void Select3()
        {
            var issue = SelectedIssue;

            issue.Status = 3;

            await DataService.UpdateAsync(issue);
            LoadPage();
        }
    }
}
