using System;
using System.Collections.Generic;
using System.Text;

namespace PIIIProjectCode
{
    // interface that has signed contract with VendingMachine
    public interface ISyntaxVendingMachine
    {
        // Checkout with cash of vendingmachine
        void Checkout(int amountReceived);

        // Checkout with payment type credit
        void Checkout();

        // transactions of vending machine
        string GetTransactions();
        // receipt for the payment
        string GetReceipt();




    }
}
