using CommunityToolkit.Mvvm.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskApp.MVVM.Models;
using TaskApp.MVVM.ViewModels;
using TaskApp.Services;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using static TaskApp.MVVM.ViewModels.MainViewModel;

namespace TaskApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>
    public partial class IssuesView : UserControl
    {
        public IssuesView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void Popup_LostFocus(object sender, RoutedEventArgs e)
        {
            if (popup.IsOpen && !IsOptionSelected())
            {
                popup.IsOpen = false;
            }
        }

        private bool IsOptionSelected()
        {
            // check if any option is selected
            return true; // replace with your own logic
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void CommentButton_Click(object sender, RoutedEventArgs e)
        {
            commentpopup.IsOpen = true;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            commentpopup.IsOpen = false;
        }

        private void DeleteComment_Click(object sender, RoutedEventArgs e)
        {
            var issuesViewModel = (IssuesViewModel)DataContext;
            issuesViewModel.DeleteComment();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Get the corresponding item for the ListViewItem
            var item = ((FrameworkElement)sender).DataContext;

            // Set the selected item of the ListView
            listView.SelectedItem = item;
        }

    }
}
