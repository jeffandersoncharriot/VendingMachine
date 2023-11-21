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
using PIIIProjectCode;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Window
    {
        #region Data Fields

        // Constants
        public const int MIN = 0;
        public const int DECIMALPLACES = 2;
        public const int CREDITMIN = 5;
        private const int QTYINDEX = 1;
        private const int PRODUCTINDEX = 0;
        private const int PRICEINDEX = 2;


        private List<RadioButton> radioButtons = new List<RadioButton>();
        private List<RadioButton> radioButtonsPaymentType = new List<RadioButton>();

        #endregion

        #region Constructor
        // Default Constructor
        // Generates list of products and gets radio buttons in a list
        public Checkout()
        {
            
            InitializeComponent();

            GenerateList();

            GetRadioButtonsMoney();

            GetRadioButtonsPayment();

        }
        #endregion


        #region Methods

        // Gets radio buttons of payment type
        private void GetRadioButtonsPayment()
        {
            radioButtonsPaymentType.Add(credit);
            radioButtonsPaymentType.Add(cash);
        }
        
        // Gets radio buttons of money that can be added
        private void GetRadioButtonsMoney()
        {
            

            radioButtons.Add(five);
            radioButtons.Add(ten);
            radioButtons.Add(twenty);
            radioButtons.Add(fifty);
            radioButtons.Add(hundred);

        }

        /// <summary>
        /// Deletes selected money that was added to listview
        /// Throws error if no money selected from listview
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void btnDeleteMoney_Click(object sender, RoutedEventArgs e)
        {
            if (moneyAdded.SelectedValue is null)
                MessageBox.Show("Select one item to delete!", "Error",
    MessageBoxButton.OK, MessageBoxImage.Warning);

            else
                moneyAdded.Items.RemoveAt(moneyAdded.SelectedIndex);
        }


        // Generates list from products added to listview
        // Displays total amount by the total cart property
        private void GenerateList()
        {
            try
            {


                StringBuilder builder = new StringBuilder();

                string[] productDetails;



                for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).articles.Items.Count; i++)
                {
                    productDetails = ((MainWindow)Application.Current.MainWindow).articles.Items[i].ToString().Split(",");

                    builder.AppendLine($"Item: {productDetails[PRODUCTINDEX]} - Quantity: {productDetails[QTYINDEX]} - Price: ${productDetails[PRICEINDEX]}");

                }

                amount.Text = $"$ {(Convert.ToString(Math.Round(((MainWindow)Application.Current.MainWindow).TotalCart, DECIMALPLACES)))}";

                listCart.Text = builder.ToString();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

        }

        // Checks if a payment type was checked - throws error to select a payment type otherwise
        // Checks if total cart is minimum 5 dollars for credit card radio button, throws error otherwise
        // if payment type is cash, calls a method to checkout articles with cash, otherwise does it with credit
        private void btnConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            
            PaymentType? type = null;
            bool noneChecked = true;
            


            foreach (RadioButton radioButton in radioButtonsPaymentType)
            {
                if ((bool)radioButton.IsChecked)
                {
                    type = GetPaymentType(radioButton.Name);

                    noneChecked = false;

                    break;
                }

                
            }

            if (noneChecked is true)
                MessageBox.Show("Select a payment Type", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
           
            else if(type is PaymentType.CREDITORDEBIT && ((MainWindow)Application.Current.MainWindow).TotalCart < CREDITMIN)
                MessageBox.Show("Minimum amount for credit or debit is 5$, please add items", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else if (type is PaymentType.CASH)
                CheckoutCash();
   
            else
                CheckoutCredit();
            


        }

        /// <summary>
        /// Checks if total cash received is higher than the total cart, throws error otherwise
        /// Gets all product details from listview of the cart and adds it to the vending machine object
        /// vending machine object checks out with the cash received
        /// opens the receipt window and resets the total cart and list view to 0
        /// Regenerates list of product with the new quantities
        /// </summary>
        private void CheckoutCash()
        {
            string[] productDetails;
            int totalMoneyReceived = 0;


            foreach (int money in moneyAdded.Items)
                totalMoneyReceived += money;
            

            if (totalMoneyReceived < ((MainWindow)Application.Current.MainWindow).TotalCart)
            {
                MessageBox.Show("Insufficient cash given", "Error",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {


                for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).articles.Items.Count; i++)
                {

                    productDetails = ((MainWindow)Application.Current.MainWindow).articles.Items[i].ToString().Split(",");


                    ((MainWindow)Application.Current.MainWindow).VendingMachine.Add(((MainWindow)Application.Current.MainWindow).VendingMachine.ProductEnumName(productDetails[PRODUCTINDEX]), Convert.ToInt32(productDetails[QTYINDEX]));

                    

                }

           ((MainWindow)Application.Current.MainWindow).VendingMachine.Checkout(totalMoneyReceived);


                CallReceiptWindow();

            }
        }


        /// <summary>
        /// Gets all product details from the listview of cart and adds it to the vending machine object
        /// calls vending machine object to checkout and print the receipt
        /// calls the receipt window and shows it and resets listview, total cart amount, and regenerates list with new products quantities
        /// </summary>
        private void CheckoutCredit()
        {
            string[] productDetails;


            for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).articles.Items.Count; i++)
            {

                productDetails = ((MainWindow)Application.Current.MainWindow).articles.Items[i].ToString().Split(",");


                ((MainWindow)Application.Current.MainWindow).VendingMachine.Add(((MainWindow)Application.Current.MainWindow).VendingMachine.ProductEnumName(productDetails[PRODUCTINDEX]), Convert.ToInt32(productDetails[QTYINDEX]));

                
            }

               ((MainWindow)Application.Current.MainWindow).VendingMachine.Checkout();


            CallReceiptWindow();

        }

        // creates receipt window and shows it
        // closes checkout window
        // Resets list view and total cart
        // regenerates list for main window
        private void CallReceiptWindow()
        {
            Receipt receiptWindow = new Receipt();

            Close();

            receiptWindow.Show();

            ((MainWindow)Application.Current.MainWindow).List();

            ((MainWindow)Application.Current.MainWindow).articles.Items.Clear();

            ((MainWindow)Application.Current.MainWindow).TotalCart = MIN;

            ((MainWindow)Application.Current.MainWindow).totalCartTxt.Text = "Total : $0";
        }

        // Shows main window back and hides this current window (checkout window)
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {

            Visibility = Visibility.Hidden;

            ((MainWindow)Application.Current.MainWindow).Show();
        }

        // Adds money to the listview if the radio is checked (whatever denomination)
        private void btnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            foreach(RadioButton radioButton in radioButtons)
            {
                if ((bool)radioButton.IsChecked)
                {
                    moneyAdded.Items.Add(GetMoney(radioButton.Name));
                    break;
                }


            }
        }


        // Returns the integer value of the current string
        private int GetMoney(string money)
        {
            switch (money)
            {

                case "five":
                    return 5;
                case "ten":
                    return 10;

                case "twenty":
                    return 20;

                case "fifty":
                    return 50;

                case "hundred":

                    return 100;

                default: //in case a formatting is missed
                    throw new ArgumentException("denomination not found");
            }

          
        }

        // returns enum payment type of the radio button name
        private PaymentType GetPaymentType(string paymentType)
        {
            switch (paymentType)
            {
                case "cash":
                    return PaymentType.CASH;
                case "credit":
                    return PaymentType.CREDITORDEBIT;

                default: //in case a formatting is missed
                    throw new ArgumentException("payment type not found");
            }

        }

        // Shows cash panel if the payment type is cash (when radio button is selected)
        private void cash_Checked(object sender, RoutedEventArgs e)
        {
            CashPanel.Visibility = Visibility.Visible;
            CashBorder.Visibility = Visibility.Visible;
        }

        // Hides cash panel if payment type cash not selected (radiobutton)
        private void cash_Unchecked(object sender, RoutedEventArgs e)
        {
            CashPanel.Visibility = Visibility.Hidden;
            CashBorder.Visibility = Visibility.Hidden;
        }
    }

    #endregion
}
