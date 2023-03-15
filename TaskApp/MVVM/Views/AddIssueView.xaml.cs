using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;

namespace TaskApp.MVVM.Views
{
    public partial class AddIssueView : UserControl
    {
        public AddIssueView()
        {
            InitializeComponent();
        }

        private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                FirstNameTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                LastNameTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }

            if (string.IsNullOrEmpty(TopicTextBox.Text))
            {
                TopicTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                TopicTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }

            if (string.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                DescriptionTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                DescriptionTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
            }
        }

    }


}
