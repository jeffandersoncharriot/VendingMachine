using System;
using System.Collections.Generic;
using System.Text;

namespace PIIIProjectCode
{

    // Product class that inherits vending machine class
    public class Product : VendingMachine
    {
        // Properties with get and set

        public int Quantity { get; set; }

        public ProductName Name { get; set; }

        public PaymentType Payment { get; set; }

        public double ProductPrice { get; set; }


    }

    // Enum of all products that will be displayed
    public enum ProductName
    {
       APPLE,ORANGE,DORITOS,LAYS,RAISINS,MILK,BISCUITS,SOUP,JUICE,CANDY,WATER,TOSTITOS
    }

    // Payment types enum
    public enum PaymentType
    {
        CREDITORDEBIT,CASH
    }


}
