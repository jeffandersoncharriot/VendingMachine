# Simple Vending Machine
## App Snapshots
![image](https://github.com/jeffandersoncharriot/VendingMachine/assets/98402030/fb57982a-78cf-42b4-b20a-2e9f96efdd2a)
![image](https://github.com/jeffandersoncharriot/VendingMachine/assets/98402030/de84555c-298f-4dba-bb8d-821249b4a530)
![image](https://github.com/jeffandersoncharriot/VendingMachine/assets/98402030/a6de6820-b026-47e0-9d9c-f7c84d48fc3a)
![image](https://github.com/jeffandersoncharriot/VendingMachine/assets/98402030/28390d31-968a-4952-b23b-a9f364d6f439)
![image](https://github.com/jeffandersoncharriot/VendingMachine/assets/98402030/524496bb-e5c4-4424-a4b1-b27c2307f57f)


## Team Information
- Eike Morgado Bodecker
- Jeff Anderson Charriot
## Project Description
### Requirements for the app:
-	Quantities of products are loaded from a file
-	If item is not available, it is greyed out
-	Shopping cart
-	Multiple types of payment methods (credit/debit card & cash)
-	Receipt with breakdown of change if needed
-	Reset shopping cart options
-	Save transactions to file
-	Save new quantities of items to file after checkout

## Functionality:
### Main shopping window:
-	Radio buttons with all items that can be bought
-	Disabled if no more items
-	Cart list box with a delete button underneath
-	Toolbar with reset option and save transactions options

### Checkout window:
-	Type of payment
-	If cash options (radio buttons for bills)
-	Pay button
-	Back button
### Receipt Window:
-	Thank you, message
-	Home button
-	List of what you bought and the total price
-	Method of payment is listed
-	If cash a breakdown of the cash back is given

## OOP Design
## UML CLASS DIAGRAM:
### VendingMachine (base-class) inherited by Product Class – Concrete class
-	products : List<Product>
-	transactions : StringBuilder
-	receipt : StringBuilder
-	transactionNum : integer
-	currentIndex : integer
-	productQty : integer
-	productQuantities: integer array
     + Add(ProductName, integer) : void
-	GetProductQuantities(string) : Integer array
-	AddProductQuantitie(Integer array) : void
+ CheckProductQuantity(ProductName) : int
+ ListOfProducts(ProductName) : string
-	RemoveProductQuantity(ProductName,integer) : Void
+   ProductEnumName(string): ProductName
+ ItemPrice(ProductName) :Void
+ Checkout(integer): void
+ BreakdownChange(double): string
+ Checkout(): Void
       + GetTransactions(): Void
       + GetReceipt(): void
+ Checkout (int) : Void


Product (derived-class of VendingMachine) – Concrete class
(Properties) (get – set)
+ Quantity: int
+ Name: ProductName
+ Payment: PaymentType
+ ProductPrice : double
+ ProductName : enum
+ PaymentType : enum
 
ISyntaxVendingMachine - Interface
Checkout(integer) : void
Checkout(): Void
GetTransactions: string
GetReceipt : string

## Contributions
- Eike: Front-End
- Jeff: Back-End

## Future Work
UI could be improved to make it look more inviting.
Right now, only the quantity of items is read from a file in the future also the items themselves could be read from a file (maybe a csv file with columns: item quantity, price.


