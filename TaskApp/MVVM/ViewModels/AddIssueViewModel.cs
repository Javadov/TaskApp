﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows.Controls;
using TaskApp.MVVM.Entities;
using TaskApp.Services;
using static TaskApp.MVVM.ViewModels.MainViewModel;

namespace TaskApp.MVVM.ViewModels
{
    internal partial class AddIssueViewModel : ObservableObject
    {

        [ObservableProperty]
        private string pageTitle = "Skapa ärende";

        [ObservableProperty]
        private string firstname = null!;

        [ObservableProperty]
        private string lastname = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phonenumber = null!;

        [ObservableProperty]
        private string topic = null!;

        [ObservableProperty]
        private string description = null!;


        [RelayCommand]
        private async void Add()
        {
            var database = new DataService();

            await database.SaveIssueAsync(new IssueEntity
            {
                Topic = Topic,
                Description = Description,
                Status = 1,
                DateTime = System.DateTime.Now,
                ContactId = await database.IssuesAsync(new ContactEntity
                {
                    FirstName = Firstname,
                    LastName = Lastname,
                    Email = Email,
                    PhoneNumber = Phonenumber
                }),
            });;

            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Phonenumber = string.Empty;
            Topic = string.Empty;
            Description = string.Empty;
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

    }
}
