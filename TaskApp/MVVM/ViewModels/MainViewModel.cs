using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public class ChangeViewModelMessage
        {
            public object NewViewModel { get; }

            public ChangeViewModelMessage(object newViewModel)
            {
                NewViewModel = newViewModel;
            }
        }


        public MainViewModel() 
        {
            // Register to receive ChangeViewModelMessage messages
            Messenger.Default.Register<ChangeViewModelMessage>(this, message =>
            {
                CurrentViewModel = (ObservableObject)message.NewViewModel;
            });

            CurrentViewModel = new HomeViewModel();
        }
    }
}