using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;
using System.Windows.Controls;

namespace TaskApp.Services
{
    internal class TaskManager
    {
        private static ObservableCollection<Issue> issues = new ObservableCollection<Issue>();

        public static void Remove(Issue issue)
        {
            issues.Remove(issue);
        }

        public static ObservableCollection<Issue> Issues()
        {
            return issues;
        }
    }

    public class NullVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityToInverseVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class StatusToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int status)
            {
                switch (status)
                {
                    case 1:
                        return "Ej påbörjad";
                    case 2:
                        return "Pågående";
                    case 3:
                        return "Avslutad";
                    default:
                        return string.Empty;
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                return count == 0 ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ListViewItemToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedItem = value as ListViewItem;
            if (selectedItem == null)
            {
                return new Thickness(0);
            }
            var listView = ItemsControl.ItemsControlFromItemContainer(selectedItem) as ListView;
            if (listView == null)
            {
                return new Thickness(0);
            }
            var index = listView.ItemContainerGenerator.IndexFromContainer(selectedItem);
            if (index < 0)
            {
                return new Thickness(0);
            }
            var topMargin = (index == 0) ? selectedItem.ActualHeight : 0;
            return new Thickness(0, topMargin, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
