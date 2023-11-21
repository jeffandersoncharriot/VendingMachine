Simple Vending Machine
 
Team Information
Eike Morgado Bodecker
Jeff Anderson Charriot
Project Description
Requirements for the app:
-	Quantities of products are loaded from a file
-	If item is not available, it is greyed out
-	Shopping cart
-	Multiple types of payment methods (credit/debit card & cash)
-	Receipt with breakdown of change if needed
-	Reset shopping cart options
-	Save transactions to file
-	Save new quantities of items to file after checkout

Functionality:
Main shopping window:
-	Radio buttons with all items that can be bought
-	Disabled if no more items
-	Cart list box with a delete button underneath
-	Toolbar with reset option and save transactions options

Checkout window:
-	Type of payment
-	If cash options (radio buttons for bills)
-	Pay button
-	Back button
Receipt Window:
-	Thank you, message
-	Home button
-	List of what you bought and the total price
-	Method of payment is listed
-	If cash a breakdown of the cash back is given

Development Approach
Explain how you prepared for the project. You can use the 5 steps of algorithmic thinking to you help build this section (you will need to elaborate on each step).
1.	Understanding the problem. 
-	Looked online for ideas about how such an app could be implemented
-	Build a simple vending machine app
-	See the requirements section of the documentation
2.	Formulating the problem.
-	See functionality section of documentation
3.	Developing the application \ algorithm.
-	See OOP Design UML class diagram
4.	Implementing the application \algorithm.
-	Separated work into front and back end
5.	Testing.
-	Tested for edge-cases and more obvious causes for errors
 
OOP Design
UML CLASS DIAGRAM:
VendingMachine (base-class) inherited by Product Class – Concrete class
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

Contributions
Eike: Front-End
Jeff: Back-End
App Snapshots 

Main Windows:
 

Checkout if Debit is used:	Checkout if cash is used:
    	 
Receipt if debit was used:	Receipt if cash was used:
 		 




Future Work
UI could be improved to make it look more inviting.
Right now, only the quantity of items is read from a file in the future also the items themselves could be read from a file (maybe a csv file with columns: item quantity, price.
Appendix A: Team Contract
 
This is an informal contract to ensure that all team members have a common understanding of what is expected in terms of work standards, communication, division or work, and conflict resolution.
Team Members (Name & ID)
 	Name 	Student ID
Member A:	 Eike Morgado Bodecker	2137571
Member B:	 Jeff Anderson Charriot	 2133124
 
Strength & Weaknesses
Within the context of this project, what are the strengths and weaknesses that each member brings to the team?
 
Member A: I am good at taking in feedback and putting it into my work. I do lack somewhat motivation and if I get stuck for a while I don’t want to work anymore. (Usually only lasts about 1-2 hours though)
Member B: My strengths are that I’m good at concentrating on my task and completing it and my weaknesses are procrastinating and distractions.
 
Definition of “good enough” for this project
What would the team collectively consider “good enough” of an achievement for the project?
(One response for the whole team)

 An app that is fully functional to the extent that is needed, but also looks and works like a normal app would (not like a child made it)
 
 
Picked Topic
 Simple Vending App
 
Division of work
How will each member contribute to the project?
Member A: Front-end
Member B: Back-end
 

Frequency of communication
How often will the team be in touch and what tools will be used to communicate?
Every day they should be in touch and use some sort of messaging app or be in a call to communicate

Response delays
What is a reasonable delay to reply to messages? Is it the same for weekdays and weekends?
Reasonable delay to replay messages are in hours and it’s not the same for weekdays and weekends as people tend to do more personal stuff on weekends then they would do work on weekdays.
 
Receiving feedback
Each member must provide a sample sentence for how they would like to receive constructive feedback from their peers.
(If unsure, assume a hypothetical situation such as you have not completed your work in time or you have not replied to a message in a timely manner).
 
Member A: [Person’s name] Why have you not done [what I was supposed to do]. You were supposed to have done it for [time it was supposed to be done for]. Please do so ASAP.
Member B: Teammate, I would like you to answer my texts more quickly as we need to complete the project at a given time.
 
In case of conflict
If a team member fails to communicate as described in this contract or does not respond to constructive feedback, what measures should the other teammate take?
(One response for the whole team)
The other teammate should take a failed mark on the project because he didn’t contribute enough and/or work as a team.


