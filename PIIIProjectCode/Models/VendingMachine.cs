using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PIIIProjectCode
{
    // Vending machine class that has signed contract with interface ISyntaxVendingMachine
    public class VendingMachine : ISyntaxVendingMachine
    {

        #region Data Fields

        private List<Product> products;
        private StringBuilder transactions;
        private StringBuilder receipt;
        private int transactionNum;

        
        private int currentIndex;
        private int appleQty;
        private int orangeQty;
        private int doritosQty;
        private int laysQty;
        private int raisinsQty;
        private int milkQty;
        private int biscuitsQty;
        private int soupQty;
        private int juiceQty;
        private int candyQty;
        private int waterQty;
        private int tostitosQty;


        private int[] productQuantities;

        #endregion

        #region Constants

        public const string fileName = "../../../../PIIIProjectCode/ProductQuantitiesFile/ProductQuantities.txt";

        public const int HUNDREDBILL = 100;
        public const int FIFTYBILL = 50;
        public const int TWENTYBILL = 20;
        public const int TENBILL = 10;
        public const int FIVEBILL = 5;
        public const int ONEBILL = 1;
        public const double QUARTER = 0.25;
        public const double DIME = 0.10;
        public const int MIN = 0;

        public const int maxBillsLength = 8;
        public const int MONEYDECIMALS = 3;
        public const int ONEINDEX = 1;
        public const int TWOINDEX = 2;
        public const int THREEINDEX = 3;
        public const int FOURINDEX = 4;
        public const int FIVEINDEX = 5;
        public const int SIXINDEX = 6;
        public const int SEVENINDEX = 7;
        public const int EIGHTINDEX = 8;
        public const int NINEINDEX = 9;
        public const int TENINDEX = 10;
        public const int ELEVENINDEX = 11;
        public const int TWELVEINDEX = 12;

        #endregion

        #region Constructor

        // Default constructor
        // calls new objects and string builder
        // gets product quantities from file 
        // adds it to the data fields
        public VendingMachine()
        {
            products = new List<Product>();
            receipt = new StringBuilder();
            transactions = new StringBuilder();

           productQuantities = GetProductQuantities(fileName);

            AddProductQuantities(productQuantities);
            
        }

        #endregion

        #region Methods

        // Adds product details to new product object to the properties
        public void Add(ProductName item, int quantity)
        {
            products.Add(new Product() { Quantity = quantity, Name = item, ProductPrice = ItemPrice(item) });

        }



        #region Methods product details

        /// <summary>
        /// Checks if file exists, otherwise returns null
        /// Gets product quantities from file
        /// adds it to integer array and return it
        /// </summary>
        /// <param name="fileName"> string </param>
        /// <returns></returns>
        private int[] GetProductQuantities(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {

                    string[] itemQuantities = File.ReadAllLines(fileName);

                    int[] itemQuantitiesToInt = new int[itemQuantities.Length];


                    for (int i = 0; i < itemQuantities.Length; i++)
                        itemQuantitiesToInt[i] = Convert.ToInt32(itemQuantities[i]);

                    return itemQuantitiesToInt;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);

                    return null;
                }
            }
            else
            {
                Console.Write("File doesnt exist");

                return null;
            }
            

        }

        /// <summary>
        /// Adds product quantities from integer array to integers
        /// 
        /// </summary>
        /// <param name="productsQuantities"> integer array </param>
        private void AddProductQuantities(int[] productsQuantities)
        {
            appleQty = productsQuantities[MIN];
            orangeQty = productsQuantities[ONEINDEX];
            doritosQty = productsQuantities[TWOINDEX];
            laysQty = productsQuantities[THREEINDEX];

            raisinsQty = productsQuantities[FOURINDEX];
            milkQty = productsQuantities[FIVEINDEX];
            biscuitsQty = productsQuantities[SIXINDEX];
            soupQty = productsQuantities[SEVENINDEX];

            juiceQty = productsQuantities[EIGHTINDEX];
            candyQty = productsQuantities[NINEINDEX];
            waterQty = productsQuantities[TENINDEX];
            tostitosQty = productsQuantities[ELEVENINDEX];
        }

        /// <summary>
        /// Checks product quantity from enum item
        /// </summary>
        /// <param name="item"> Product Name </param>
        /// <returns></returns>
        public int CheckProductQuantity(ProductName item)
        {
            switch (item)
            {
                case ProductName.APPLE:
                    return appleQty;

                case ProductName.ORANGE:
                    return orangeQty;

                case ProductName.LAYS:
                    return laysQty;

                case ProductName.DORITOS:
                    return doritosQty;

                case ProductName.RAISINS:
                    return raisinsQty;

                case ProductName.MILK:
                    return milkQty;

                case ProductName.BISCUITS:

                    return biscuitsQty;

                case ProductName.SOUP:

                    return soupQty;

                case ProductName.JUICE:
                    return juiceQty;

                case ProductName.CANDY:
                    return candyQty;

                case ProductName.WATER:
                    return waterQty;

                case ProductName.TOSTITOS:
                    return tostitosQty;

                default: //in case a formatting is missed
                    throw new ArgumentException("not found");
            }

        }

        /// <summary>
        /// Returns string details of product from enum
        /// 
        /// </summary>
        /// <param name="item"> ProductName </param>
        /// <returns></returns>
        public string ListOfProducts(ProductName item)
        {
            switch (item)
            {
                case ProductName.APPLE:
                    return $"Apple - ${ItemPrice(item)} - Qty: {appleQty}";

                case ProductName.ORANGE:
                    return $"Orange - ${ItemPrice(item)} - Qty: {orangeQty}";

                case ProductName.LAYS:
                    return $"Lays - ${ItemPrice(item)} - Qty: {laysQty}";

                case ProductName.DORITOS:
                    return $"Doritos - ${ItemPrice(item)} - Qty: {doritosQty}";

                case ProductName.RAISINS:
                    return $"Raisins - ${ItemPrice(item)} - Qty: {raisinsQty}";

                case ProductName.MILK:
                    return $"Milk - ${ItemPrice(item)} - Qty: {milkQty}";

                case ProductName.BISCUITS:

                return $"Biscuits - ${ItemPrice(item)} - Qty: {biscuitsQty}";

                case ProductName.SOUP:

                  return $"Soup - ${ItemPrice(item)} - Qty: {soupQty}";

                case ProductName.JUICE:
                    return $"Juice - ${ItemPrice(item)} - Qty: {juiceQty}";

                case ProductName.CANDY:
                    return $"Candy - ${ItemPrice(item)} - Qty: {candyQty}";

                case ProductName.WATER:
                    return $"Water - ${ItemPrice(item)} - Qty: {waterQty}";

                case ProductName.TOSTITOS:
                    return $"Tostitos - ${ItemPrice(item)} - Qty: {tostitosQty}";

                default: //in case a formatting is missed
                    throw new ArgumentException("not found");
            }
            
        }

        /// <summary>
        /// Removes quantity from specific product with on quantity
        /// </summary>
        /// <param name="item"> ProcutName (enum) </param>
        /// <param name="qty">integer</param>
        private void RemoveProductQuantity(ProductName item,int qty)
        {

            switch (item)
            {
                case ProductName.APPLE:

                    appleQty -= qty;
                    break;

                case ProductName.ORANGE:

                    orangeQty -= qty;
                    break;

                case ProductName.LAYS:

                    laysQty -= qty;
                    break;

                case ProductName.RAISINS:

                    raisinsQty -= qty;
                    break;

                case ProductName.MILK:

                    milkQty-=qty;
                    break;

                case ProductName.BISCUITS:

                    biscuitsQty -= qty;
                    break;

                case ProductName.SOUP:

                    soupQty -= qty;
                    break;

                case ProductName.JUICE:

                    juiceQty -= qty;
                    break;

                case ProductName.CANDY:

                    candyQty -= qty;
                    break;

                case ProductName.WATER:

                    waterQty -= qty;
                    break;

                case ProductName.TOSTITOS:

                    tostitosQty -= qty;
                    break;
            }


        }




        /// <summary>
        /// gets productname enum from string
        /// </summary>
        /// <param name="item">string</param>
        /// <returns> ProcutName Enum </returns>
        public ProductName ProductEnumName(string item)
        {
            switch (item)
            {
                case "Apple":
                    return ProductName.APPLE;

                case "Orange":
                    return ProductName.ORANGE;

                case "Doritos":
                    return ProductName.DORITOS;
                case "Lays":
                    return ProductName.LAYS;


                case "Raisins":
                    return ProductName.RAISINS;
                case "Milk":
                    return ProductName.MILK;
                case "Biscuits":
                    return ProductName.BISCUITS;
                case "Soup":
                    return ProductName.SOUP;

                case "Juice":
                    return ProductName.JUICE;
                case "Candy":
                    return ProductName.CANDY;
                case "Water":
                    return ProductName.WATER;
                case "Tostitos":
                    return ProductName.TOSTITOS;

                default: //in case a formatting is missed
                    throw new ArgumentException("not found");

            }

           
        }
        /// <summary>
        ///  gets price of Product
        /// </summary>
        /// <param name="item">ProductName enum</param>
        /// <returns>double</returns>
        public double ItemPrice(ProductName item)
        {
            double price = 0;

            switch (item)
            {
                case ProductName.APPLE:

                    price = 2.99;
                    break;

                case ProductName.ORANGE:

                    price = 2.99;
                    break;

                case ProductName.DORITOS:

                    price = 2.99;
                    break;

                case ProductName.LAYS:

                    price = 2.99;
                    break;

                case ProductName.RAISINS:

                    price = 1.49;
                    break;

                case ProductName.MILK:

                    price = 5.49;
                    break;

                case ProductName.BISCUITS:

                    price = 4.99;
                    break;

                case ProductName.SOUP:

                    price = 10.99;
                    break;

                case ProductName.JUICE:

                    price = 2.99;
                    break;

                case ProductName.CANDY:

                    price = 6.99;
                    break;

                case ProductName.WATER:

                    price = 3.99;
                    break;

                case ProductName.TOSTITOS:

                    price = 2.99;
                    break;


            }

            return price;

        }


        #endregion


        #region Checkout Methods

        /// <summary>
        /// gets cash received from user
        /// calculates change
        /// adds all product details and total amount to the string builders
        /// gets breakdown of change given
        /// </summary>
        /// <param name="amountReceived">integer </param>
        public void Checkout(int amountReceived)
        {
            try
            {


                double change = amountReceived;
                int temp = currentIndex;
                string breakdown;
                double totalAmount = 0;


                transactionNum++;

                transactions.AppendLine($"Transaction # {transactionNum}");



                for (int i = temp; i < products.Count; i++)
                {

                    RemoveProductQuantity(products[i].Name, products[i].Quantity);
                    transactions.AppendLine($"Item - {products[i].Name} - Qty: {products[i].Quantity} - Price: {products[i].ProductPrice}");

                    receipt.AppendLine($"Item - {products[i].Name} - Qty: {products[i].Quantity} - Price: {products[i].ProductPrice}");

                    change -= products[i].ProductPrice * products[i].Quantity;

                    totalAmount += products[i].ProductPrice * products[i].Quantity;

                    currentIndex++;
                }

                breakdown = BreakdownChange(change);

                transactions.AppendLine();
                transactions.AppendLine($"Total amount: ${Math.Round(totalAmount, MONEYDECIMALS)}");
                transactions.AppendLine();
                transactions.AppendLine($"Payment type: Cash");
                transactions.AppendLine($"Money Received: ${amountReceived}");
                transactions.AppendLine($"Change: ${Math.Round(change, MONEYDECIMALS)}");

                transactions.AppendLine();



                receipt.AppendLine($"Total amount: ${Math.Round(totalAmount, MONEYDECIMALS)}");
                receipt.AppendLine($"Payment type: Cash");
                receipt.AppendLine($"Money Received: ${amountReceived}");
                receipt.AppendLine($"Change: ${Math.Round(change, MONEYDECIMALS)}");

                receipt.AppendLine();



                receipt.AppendLine(breakdown);
                transactions.AppendLine(breakdown);

                transactions.AppendLine($"-- End -- ");
                transactions.AppendLine();

            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
           
        }

        /// <summary>
        /// gets breakdown of change given
        /// adds the breakdown to the stringbuilder
        /// static because it does not involve any other data in the class
        /// </summary>
        /// <param name="totalAmount">double</param>
        /// <returns>string</returns>
        public static string BreakdownChange(double totalAmount)
        {

            double totalGiven = 0;

            int[] numberOfBills = new int[maxBillsLength];

            

            StringBuilder breakdown = new StringBuilder();

            for (numberOfBills[MIN] = MIN; totalAmount >= HUNDREDBILL; numberOfBills[MIN]++)
            {
                totalAmount = totalAmount - HUNDREDBILL;

                totalGiven += HUNDREDBILL;
            }
            for (numberOfBills[ONEINDEX] = MIN; totalAmount >= FIFTYBILL; numberOfBills[ONEINDEX]++)
            {
                totalAmount = totalAmount - FIFTYBILL;

                totalGiven += FIFTYBILL;
            }
            for (numberOfBills[TWOINDEX] = MIN; totalAmount >= TWENTYBILL; numberOfBills[TWOINDEX]++)
            {
                totalAmount = totalAmount - TWENTYBILL;

                totalGiven += TWENTYBILL;
            }
            for (numberOfBills[THREEINDEX] = MIN; totalAmount > TENBILL; numberOfBills[THREEINDEX]++)
            {
                totalAmount = totalAmount - TENBILL;

                totalGiven += TENBILL;
            }
            for (numberOfBills[FOURINDEX] = MIN; totalAmount >= FIVEBILL; numberOfBills[FOURINDEX]++)
            {
                totalAmount = totalAmount - FIVEBILL;

                totalGiven += FIVEBILL;
            }
            for (numberOfBills[FIVEINDEX] = MIN; totalAmount >= ONEBILL; numberOfBills[FIVEINDEX]++)
            {
                totalAmount = totalAmount - ONEBILL;

                totalGiven += ONEBILL;
            }
            for (numberOfBills[SIXINDEX] = MIN; totalAmount >= QUARTER; numberOfBills[SIXINDEX]++)
            {
                totalAmount = totalAmount - QUARTER;

                totalGiven += QUARTER;
            }
            for (numberOfBills[SEVENINDEX] = MIN; totalAmount >= DIME; numberOfBills[SEVENINDEX]++)
            {
                totalAmount = totalAmount - DIME;

                totalGiven += DIME;
            }


            breakdown.AppendLine($"Total Given: $ {string.Format("{0:0.00}",totalGiven)}");
            breakdown.AppendLine();

            breakdown.AppendLine("Breakdown:");


            breakdown.AppendLine($"Number of 100s: {numberOfBills[MIN]}");
            breakdown.AppendLine($"Number of 50s: {numberOfBills[ONEINDEX]}");
            breakdown.AppendLine($"Number of 20s: {numberOfBills[TWOINDEX]}");
            breakdown.AppendLine($"Number of 10s: {numberOfBills[THREEINDEX]}");
            breakdown.AppendLine($"Number of 5s: {numberOfBills[FOURINDEX]}");
            breakdown.AppendLine($"Number of 1s: {numberOfBills[FIVEINDEX]}");
            breakdown.AppendLine($"Number of 0.25s: {numberOfBills[SIXINDEX]}");
            breakdown.AppendLine($"Number of 0.10s: {numberOfBills[SEVENINDEX]}");


            return breakdown.ToString();


        }


        /// <summary>
        /// Gets all product details from list of product
        /// adds it to stringbuilder
        /// </summary>
        public void Checkout()
        {

            double total = 0;
            int temp = currentIndex;
            transactionNum++;

            transactions.AppendLine($"Transaction # {transactionNum}");



            for (int i = temp; i < products.Count; i++)
            {

                RemoveProductQuantity(products[i].Name, products[i].Quantity);
                transactions.AppendLine($"Item - {products[i].Name} - Qty: {products[i].Quantity} - Price: {products[i].ProductPrice}");

                receipt.AppendLine($"Item - {products[i].Name} - Qty: {products[i].Quantity} - Price: {products[i].ProductPrice}");

                total += products[i].ProductPrice * products[i].Quantity;

                currentIndex++;
            }

            transactions.AppendLine($"Total ${Math.Round(total, MONEYDECIMALS)}");
            transactions.AppendLine();

            receipt.AppendLine($"Total ${Math.Round(total, MONEYDECIMALS)}");
            receipt.AppendLine();
            receipt.AppendLine("Payment type: Credit");
            receipt.AppendLine($"Total money received: ${Math.Round(total,MONEYDECIMALS)}");

            transactions.AppendLine("Payment type: Credit");
            transactions.AppendLine($"Total money received: {total}");
            transactions.AppendLine($"-- End -- ");
            transactions.AppendLine();



        }


        //returns transactions
        public string GetTransactions()
        {
            return transactions.ToString();
        }

        // assigns new string the current receipt
        // clears the main receipt and returns receipt temp
        public string GetReceipt()
        {
            string receiptTmp = receipt.ToString();

            receipt.Clear();

            return receiptTmp;
        }

        #endregion


        #endregion
    }
}
