using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;

namespace TaskApp.Services
{
    internal class TaskManager
    {
        private static ObservableCollection<Issue> issues = new ObservableCollection<Issue>()
        {
            new Issue(){ FirstName = "Test1", LastName = "Testname1", Email = "Test1@mail.com", PhoneNumber = "123", Topic = "TopicTest1", Description = "Det är Test1", Status = 1 },
            new Issue(){ FirstName = "Test2", LastName = "Testname2", Email = "Test2@mail.com", PhoneNumber = "456", Topic = "TopicTest2", Description = "Det är Test2", Status = 2, Comment = "Det är Comment2" },
            new Issue(){ FirstName = "Test3", LastName = "Testname3", Email = "Test3@mail.com", PhoneNumber = "789", Topic = "TopicTest3", Description = "Det är Test3", Status = 3 },
            new Issue(){ FirstName = "Test4", LastName = "Testname4", Email = "Test4@mail.com", PhoneNumber = "000", Topic = "TopicTest4", Description = "Det är Test4", Status = 2, Comment = "Det är Comment4" }
        };

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

}
