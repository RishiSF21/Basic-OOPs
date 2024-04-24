using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public static class Operations
    {
        
        //Customer list
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        //Product list
        static List<ProductDetails> productList = new List<ProductDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();

        static CustomerDetails currentUser;
        public static void DefaultData()
        {
            //creating object reference for product details
            ProductDetails pro1 = new ProductDetails();
            pro1.ProductID = "PID101";
            pro1.ProductName = "Mobile (Samsung)";
            pro1.AvailableStock = 10;
            pro1.PricePerQty = 10000;
            pro1.ShippingDuration = 3;

            ProductDetails pro2 = new ProductDetails();
            pro2.ProductID = "PID102";
            pro2.ProductName = "Tablet (Lenovo)";
            pro2.AvailableStock = 5;
            pro2.PricePerQty = 15000;
            pro2.ShippingDuration = 2;

            ProductDetails pro3 = new ProductDetails();
            pro3.ProductID = "PID103";
            pro3.ProductName = "Camera (Sony)";
            pro3.AvailableStock = 3;
            pro3.PricePerQty = 20000;
            pro3.ShippingDuration = 4;

            ProductDetails pro4 = new ProductDetails();
            pro4.ProductID = "PID104";
            pro4.ProductName = "iPhone (Apple)";
            pro4.AvailableStock = 5;
            pro4.PricePerQty = 50000;
            pro4.ShippingDuration = 6;

            ProductDetails pro5 = new ProductDetails();
            pro5.ProductID = "PID105";
            pro5.ProductName = "Laptop (Lenovo I3)";
            pro5.AvailableStock = 3;
            pro5.PricePerQty = 40000;
            pro5.ShippingDuration = 3;

            ProductDetails pro6 = new ProductDetails();
            pro6.ProductID = "PID106";
            pro6.ProductName = "Headphone (Boat)";
            pro6.AvailableStock = 5;
            pro6.PricePerQty = 1000;
            pro6.ShippingDuration = 2;

            ProductDetails pro7 = new ProductDetails();
            pro7.ProductID = "PID107";
            pro7.ProductName = "Speakers (Boat)";
            pro7.AvailableStock = 4;
            pro7.PricePerQty = 500;
            pro7.ShippingDuration = 2;

            //adding products to the List
            productList.Add(pro1);
            productList.Add(pro2);
            productList.Add(pro3);
            productList.Add(pro4);
            productList.Add(pro5);
            productList.Add(pro6);
            productList.Add(pro7);

            CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai",7829927890,"ravi@gmail",200);
            CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai",8075427890,"baskaran@gmail",1200);
            customerList.Add(customer1);
            customerList.Add(customer2);

            OrderDetails order1 = new OrderDetails(customer1.CustomerID,pro1.ProductID,20000,DateTime.Now,2,OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails(customer2.CustomerID,pro3.ProductID,40000,DateTime.Now,2,OrderStatus.Ordered);
            orderList.Add(order1);
            orderList.Add(order2);
        }

        public static void MainMenu()
        {
            string option;
            do
            {

                Console.WriteLine("<--------!! Welcome to SynCart !! -------->");
                Console.WriteLine();
                Console.WriteLine("1. Customer Registration\n2. Login\n3. Exit\n");
                Console.WriteLine("--------------------------------");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            Register();
                            break;
                        }
                    case "2":
                        {
                            Login();
                            break;
                        }
                    case "3":
                        {
                            Exit();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input.. Please Try Again..");
                            break;
                        }
                }
            } while (option != "3");
        }
        public static void Register(){
           
            //customer name
            Console.Write("Enter Your Name : ");
            string customerName = Console.ReadLine();
            Console.Write("City : ");
            string city = Console.ReadLine();
            //mobile number
            Console.Write("Enter Your Mobile Number : ");
            long phoneNo = Convert.ToInt64(Console.ReadLine());
            //mail id
            Console.Write("Enter Your Mail ID : ");
            string mailID = Console.ReadLine();
            Console.Write("Enter Wallet balance -> ");
            double balance = Convert.ToDouble(Console.ReadLine());

            //adding customers to the list
            CustomerDetails customer01 = new CustomerDetails(customerName,city,phoneNo,mailID,balance);
            customerList.Add(customer01);
            Console.Clear();
            Console.WriteLine("Registration Successfull!! :-)");
    
            Console.WriteLine($"Your Customer ID : {customer01.CustomerID}\nName : {customer01.CustomerName}");
            Console.WriteLine();
        }

        public static void Login(){
            Console.Clear();
            Console.Write("Enter Customer ID -> ");
            string cID = Console.ReadLine();
            bool isValid = false;
            foreach(CustomerDetails cust in customerList){
                // string checkUser = cust.CustomerID;
                if(cust.CustomerID==cID){
                    currentUser = cust;
                    isValid = true;
                    Console.WriteLine("Login Successful...");
                    SubMenu();
                }
            }
            if(!isValid){
                Console.WriteLine("Invalid Customer ID..Please try again..");
            }
        }

        public static void SubMenu(){
            string submenuOption;
            do
            {
                Console.WriteLine("a. Purchase\nb. Order History\nc. Cancel Order\nd. Wallet Balance\ne. Wallet Recharge\nf. Exit");
                submenuOption = Console.ReadLine();
                switch (submenuOption)
                {
                    case "a":
                        {
                            Purchase();
                            break;
                        }
                    case "b":
                        {
                            OrderHistory();
                            break;
                        }
                    case "c":
                        {
                            CancelOrder();
                            break;
                        }
                    case "d":
                        {
                            WalletBalance();
                            break;
                        }
                    case "e":
                        {
                            WalletRecharge();
                            break;
                        }
                    case "f":
                        {
                            Exit();
                            break;
                        }
                }
            } while(submenuOption != "f");
            
        }

        public static void Purchase(){
            Console.Clear();
            Console.WriteLine("| Product ID | Product Name | Stock | Price | Shipping Duration |");
            foreach(ProductDetails prod in productList){
                Console.WriteLine($"| {prod.ProductID} | {prod.ProductName} | {prod.AvailableStock} | {prod.PricePerQty} | {prod.ShippingDuration}");
            }
            Console.Write("\nEnter a ProductID -> ");
            string customerProID = Console.ReadLine().ToUpper();

            bool isStocked = true;
            double totalCost = 0;
            foreach(ProductDetails prod in productList)
            {
                if(prod.ProductID.Equals(customerProID))
                {
                    Console.Write("\nEnter Product Quantity you wish to purchase -> ");
                    int userQuantity = int.Parse(Console.ReadLine());
                    if(prod.AvailableStock >= userQuantity)
                    {
                        isStocked = false;
                        double deliveryCharge = 50;
                        totalCost = userQuantity * prod.PricePerQty + deliveryCharge;
                        if(currentUser.WalletBalance >= totalCost)
                        {
                            currentUser.WalletBalance -= totalCost;
                            prod.AvailableStock -= userQuantity;
                            OrderDetails order1 = new OrderDetails(currentUser.CustomerID,prod.ProductID,totalCost,DateTime.Now,userQuantity,OrderStatus.Ordered);
                            orderList.Add(order1);
                            Console.WriteLine("Order Placed Successfully");
                        }
                        else{
                            Console.WriteLine("\nInsufficient Balance");
                        }
                    }
                }
            }
            if(isStocked)
            {
                Console.WriteLine("Out of Stock");
            }
        }
        public static void OrderHistory()
        {
            Console.WriteLine("|  OrderID  |  | CustomerID  |  ProductID  |  TotalPrice  |  Purchase Date  |  Quantity  |  Order Status  |");
            foreach(OrderDetails orders in orderList)
            {
                if(orders.CustomerID.Equals(currentUser.CustomerID))
                {
                    Console.WriteLine($"|  {orders.OrderID}  |  | {orders.CustomerID}  |  {orders.ProductID}  |  {orders.TotalPrice}  |  {orders.PurchaseDate}  |  {orders.Quantity}  |  {orders.Status}  |");
                }
            }
        }
        public static void CancelOrder()
        {
            Console.WriteLine("|  OrderID  |  | CustomerID  |  ProductID  |  TotalPrice  |  Purchase Date  |  Quantity  |  Order Status  |");
            foreach(OrderDetails orders in orderList)
            {
                if(orders.CustomerID.Equals(currentUser.CustomerID) && orders.Status==OrderStatus.Ordered)
                {
                    Console.WriteLine($"|  {orders.OrderID}  |  | {orders.CustomerID}  |  {orders.ProductID}  |  {orders.TotalPrice}  |  {orders.PurchaseDate}  |  {orders.Quantity}  |  {orders.Status}  |");
                }
            }
            Console.Write("Select OrderID to cancel -> ");
            string cancelOrder = Console.ReadLine();
            foreach(OrderDetails orders in orderList)
            {
                if(orders.OrderID.Equals(cancelOrder))
                {
                    foreach(ProductDetails prod in productList)
                    {
                        prod.AvailableStock += orders.Quantity;
                        orders.Status = OrderStatus.Cancelled;
                        currentUser.WalletBalance += orders.TotalPrice;
                        Console.WriteLine($"OrderID {orders.OrderID} Cancelled Successfully");
                        break;
                    }
                }
            }
        }
        public static void WalletBalance()
        {
            Console.WriteLine($"\nCurrent Wallet Balance -> {currentUser.WalletBalance}");
        }
        public static void WalletRecharge()
        {
            Console.Write("\nEnter Recharge Amount -> ");
            double amount = Convert.ToDouble(Console.ReadLine());
            currentUser.WalletBalance += amount;
            Console.WriteLine("\nRecharge Successfull");
        }

        public static void Exit(){}
    }
}