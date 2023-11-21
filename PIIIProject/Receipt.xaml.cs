using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for Receipt.xaml
    /// </summary>
    public partial class Receipt : Window
    {

        // Default constructor
        public Receipt()
        {
            InitializeComponent();

            
            GenerateReceipt();
        }

        #region Methods

        // Gets receipt from vending machine property
        // outputs it to the window
        public void GenerateReceipt()
        {
            string receipt = ((MainWindow)Application.Current.MainWindow).VendingMachine.GetReceipt();

            receiptTxt.Text = receipt;
        }

        // Closes current window and goes back to main window
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Close();

            ((MainWindow)Application.Current.MainWindow).Show();
           
        }

        #endregion

    }
}
