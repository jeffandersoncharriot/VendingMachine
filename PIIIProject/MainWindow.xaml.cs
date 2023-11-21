using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using PIIIProjectCode;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

   
    
    public partial class MainWindow : Window
    {

        #region Data fields

        //Constants
        public const int MIN = 0;
        public const int DECIMALPLACES = 2;


        private VendingMachine vendingMachine = new VendingMachine();

        private List<RadioButton> radioButtons = new List<RadioButton>();

        private double totalCart;

        #endregion

       // Default constructor
       // Generates list of products with quantities
        public MainWindow()
        {
            
           InitializeComponent();

            GetRadioButtons();


            List();
          
            
        }

        // Class cart for list view (articles) that gets all product details
        // overrides string to the details on a string to get the details when needed on other methods
        public class Cart
        {
            public string Product { get; set; }

            public int Quantity { get; set; }

            public double Price { get; set; }
            public override string ToString()
            {
                return string.Format($"{Product},{Quantity},{Price}");
            }
        }


        #region Properties

        // Total Cart integer property with get and set
        public double TotalCart
        {
            get => totalCart;

            set => totalCart = value;
        }


        // read-only property of vendingmachine object
        public VendingMachine VendingMachine
        {
            get => vendingMachine;
            
        }
        #endregion

        #region Methods

        /// <summary>
        /// Checks product quantity
        /// If product has no more quantity, disables radio button
        /// </summary>
        /// <param name="product"> ProductName (enum) </param>
        private void NoQuantityItems(ProductName product)
        {

            switch(product)
            {
                case ProductName.APPLE:

                    if (vendingMachine.CheckProductQuantity(ProductName.APPLE) == MIN)
                        Apple.IsEnabled = false;
                    else
                        Apple.IsEnabled = true;

                    break;

                case ProductName.ORANGE:

                    if (vendingMachine.CheckProductQuantity(ProductName.ORANGE) == MIN)
                        Orange.IsEnabled = false;
                    else
                        Orange.IsEnabled = true;

                    break;

                case ProductName.DORITOS:

                    if (vendingMachine.CheckProductQuantity(ProductName.DORITOS) == MIN)
                        Doritos.IsEnabled = false;
                    else
                        Doritos.IsEnabled = true;

                    break;

                case ProductName.LAYS:

                    if (vendingMachine.CheckProductQuantity(ProductName.LAYS) == MIN)
                        Lays.IsEnabled = false;
                    else
                        Doritos.IsEnabled = true;

                    break;

                case ProductName.RAISINS:

                    if (vendingMachine.CheckProductQuantity(ProductName.RAISINS) == MIN)
                        Raisins.IsEnabled = false;
                    else
                        Raisins.IsEnabled = true;

                    break;

                case ProductName.MILK:

                    if (vendingMachine.CheckProductQuantity(ProductName.MILK) == MIN)
                        Milk.IsEnabled = false;
                    else
                        Milk.IsEnabled = true;

                    break;

                case ProductName.BISCUITS:

                    if (vendingMachine.CheckProductQuantity(ProductName.BISCUITS) == MIN)
                        Biscuits.IsEnabled = false;
                    else
                        Biscuits.IsEnabled = true;

                    break;

                case ProductName.SOUP:

                    if (vendingMachine.CheckProductQuantity(ProductName.SOUP) == MIN)
                        Soup.IsEnabled = false;
                    else
                        Soup.IsEnabled = true;

                    break;

                case ProductName.JUICE:

                    if (vendingMachine.CheckProductQuantity(ProductName.JUICE) == MIN)
                        Juice.IsEnabled = false;
                    else
                        Juice.IsEnabled = true;

                    break;
                case ProductName.CANDY:

                    if (vendingMachine.CheckProductQuantity(ProductName.CANDY) == MIN)
                        Candy.IsEnabled = false;
                    else
                        Candy.IsEnabled = true;

                    break;
                case ProductName.WATER:

                    if (vendingMachine.CheckProductQuantity(ProductName.WATER) == MIN)
                        Water.IsEnabled = false;
                    else
                        Water.IsEnabled = true;

                    break;
                case ProductName.TOSTITOS:

                    if (vendingMachine.CheckProductQuantity(ProductName.TOSTITOS) == MIN)
                        Tostitos.IsEnabled = false;
                    else
                        Tostitos.IsEnabled = true;

                    break;

                default: //in case a formatting is missed
                    throw new ArgumentException("ProductName enum not found");
            }
        }

        // Generates the list of products of each enum to the radio buttons
        // Checks the quantity of each product to see to disable it or not
        public void List()
        {
             
            Apple.Content = vendingMachine.ListOfProducts(ProductName.APPLE);
            NoQuantityItems(ProductName.APPLE);

            Orange.Content = vendingMachine.ListOfProducts(ProductName.ORANGE);
            NoQuantityItems(ProductName.ORANGE);

            Doritos.Content = vendingMachine.ListOfProducts(ProductName.DORITOS);
            NoQuantityItems(ProductName.DORITOS);

            Lays.Content = vendingMachine.ListOfProducts(ProductName.LAYS);
            NoQuantityItems(ProductName.LAYS);

            Raisins.Content = vendingMachine.ListOfProducts(ProductName.RAISINS);
            NoQuantityItems(ProductName.RAISINS);

            Milk.Content = vendingMachine.ListOfProducts(ProductName.MILK);
            NoQuantityItems(ProductName.MILK);

            Biscuits.Content = vendingMachine.ListOfProducts(ProductName.BISCUITS);
            NoQuantityItems(ProductName.BISCUITS);

            Soup.Content = vendingMachine.ListOfProducts(ProductName.SOUP);
            NoQuantityItems(ProductName.SOUP);

            Juice.Content = vendingMachine.ListOfProducts(ProductName.JUICE);
            NoQuantityItems(ProductName.JUICE);

            Candy.Content = vendingMachine.ListOfProducts(ProductName.CANDY);
            NoQuantityItems(ProductName.CANDY);

            Water.Content = vendingMachine.ListOfProducts(ProductName.WATER);
            NoQuantityItems(ProductName.WATER);

            Tostitos.Content = vendingMachine.ListOfProducts(ProductName.TOSTITOS);
            NoQuantityItems(ProductName.TOSTITOS);


        }

        // Gets radio buttons of all products
        private void GetRadioButtons()
        {
            radioButtons.Add(Apple);
            radioButtons.Add(Orange);
            radioButtons.Add(Doritos);
            radioButtons.Add(Lays);

            radioButtons.Add(Raisins);
            radioButtons.Add(Milk);
            radioButtons.Add(Biscuits);
            radioButtons.Add(Soup);

            radioButtons.Add(Juice);
            radioButtons.Add(Candy);
            radioButtons.Add(Water);
            radioButtons.Add(Tostitos);

        }

        #region Button Click Methods

        // Calls a new vending machine object to reset everything
        // Regenerates list to put back all quantities
        private void btnResetMachine_Click(object sender, RoutedEventArgs e)
        {
            vendingMachine = new VendingMachine();
            List();
        }

        // Checks all transactions made on the vending machine object
        private void btnTransactions_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(vendingMachine.GetTransactions()))
                MessageBox.Show("No transactions have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
            
            else
                MessageBox.Show(vendingMachine.GetTransactions(), "Transactions", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }



        // declares a new checkout window and hides the main window, shows the checkout window
        // doesnt go on the checkout window if no items added to cart
        private void btnCart_Click(object sender, RoutedEventArgs e)
        {

            if (articles.Items.Count == MIN)
                MessageBox.Show("Add items to cart to proceed with checkout", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {

                UpdateTotalCart();

                Checkout checkout = new Checkout();

                Visibility = Visibility.Hidden;

                checkout.Show();
            }

        }

        //updates total cart
        private void UpdateTotalCart()
        {
            totalCart = 0;

            foreach (Cart item in articles.Items)
                totalCart += item.Quantity * item.Price;

            totalCartTxt.Text = $"Total: ${totalCart}";
            
        }

        // Deletes product from listview
        // throws error message box if no selected item from listview
        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (articles.SelectedValue is null)
                MessageBox.Show("Select one item to delete!", "Error",
    MessageBoxButton.OK, MessageBoxImage.Warning);

            else
            {
                articles.Items.RemoveAt(articles.SelectedIndex);

                UpdateTotalCart();
            }
        }

        // Checks if one of the radio button is checked from the radio button list
        // checks if theres quantity added or else doesnt proceed and throws error
        // Checks if the item selected is already on the cart, throws error if it is
        // Throws error if theres less quantity of requested aamount from user
        // adds item with requested quantity to the listview (articles) if everything is correct
        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                bool sameProduct = false;


                foreach (RadioButton radioButton in radioButtons)
                {

                    if ((bool)radioButton.IsChecked && slider.Value == MIN)
                    {
                        MessageBox.Show($"You have to add quantity for {radioButton.Name}", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                        break;
                    }
                    else if ((bool)radioButton.IsChecked && slider.Value != MIN)
                    {

                        foreach (Cart item in articles.Items)
                        {

                            if (radioButton.Name == item.Product)
                            {
                                MessageBox.Show("You already have the same item on the list, delete to redo quantity", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                                sameProduct = true;

                                break;
                            }

                        }

                        if (slider.Value > vendingMachine.CheckProductQuantity(vendingMachine.ProductEnumName(radioButton.Name)))
                        {
                            MessageBox.Show($"Insufficent amount of {radioButton.Name}", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                        else if (sameProduct is false)
                        {
                            totalCart += slider.Value * vendingMachine.ItemPrice(vendingMachine.ProductEnumName(radioButton.Name));

                            totalCartTxt.Text = $"Total : ${Math.Round(totalCart, DECIMALPLACES)}";

                            articles.Items.Add(new Cart { Product = radioButton.Name, Quantity = (int)slider.Value, Price = vendingMachine.ItemPrice(vendingMachine.ProductEnumName(radioButton.Name)) });
                        }

                        break;

                    }
                }

            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        #endregion

        
        // Saves transactions to a file name
        // if transactions file isnt empty, proceeds to save to a file on the computer
        private void sveTransactions_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(vendingMachine.GetTransactions()))
                {
                    MessageBox.Show($"No transactions has been made", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string fileLocation = string.Empty;

                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    saveFileDialog.Filter = "txt file | *.txt";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        fileLocation = saveFileDialog.FileName;
                    }
                    if (!string.IsNullOrEmpty(fileLocation))
                    {
                        string extension = System.IO.Path.GetExtension(fileLocation);

                        File.WriteAllText(fileLocation, vendingMachine.GetTransactions());
                    }
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }

        #endregion
    }
}
