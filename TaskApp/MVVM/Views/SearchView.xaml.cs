using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
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
    }
}
