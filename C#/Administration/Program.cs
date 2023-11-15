int mode = 0; //determines what menu the user is in
int submode = 0; //determines where the user is in the current menu
List<customer> customers = new List<customer>(); //list of all customers
customer current_customer = new customer(); //currently selected customer

void main_menu()
{
    submode = 0;
    Console.Clear();
    Console.WriteLine("Home menu \n\nPlease choose an option\n\n0: Add customer\n1: Display customer info\n2: Exit");
    string? input = Console.ReadLine();
    //choose which menu to enter
    switch (input)
    {
        //add customer
        case "0":
            current_customer = new customer();
            mode = 1;
            break;
        //display customer info
        case "1":
            mode = 2;
            break;
        //exit program
        case "2":
            Environment.Exit(0);
            break;
        //default
        default:
            break;
    }
    Console.Clear();
}
void add_customer()
{
    Console.Clear();
    Console.WriteLine("Add customer\n"); 
    string? input;
    switch (submode)
    {
        //add name
        case 0:
            Console.WriteLine("Enter name:");
            input = Console.ReadLine();
            if (input == null || input == "")
                break;
            current_customer.name = input;
            submode++;
            break;
        //add address
        case 1:
            Console.WriteLine("Enter address:");
            input = Console.ReadLine();
            if (input == null || input == "")
                break;
            current_customer.address = input;
            submode++;
            break;
        //add email
        case 2:
            Console.WriteLine("Enter email:");
            input = Console.ReadLine();
            if (input == null || input == "")
                break;
            current_customer.email = input;
            submode++;
            break;
        //add phone number
        case 3:
            Console.WriteLine("Enter phone number:");
            input = Console.ReadLine();
            if (input == null || input == "")
                break;
            current_customer.phone = input;
            submode++;
            break;
        //add name
        case 4:
            display_current_customer_info();
            Console.WriteLine("\nConfirm?\n0:no\n1:yes");
            input = Console.ReadLine();
            if (input == null || input == "")
                break;
            if (input == "1")
            {
                customers.Add(current_customer);
                save_customers();
            }
            mode = 0;
            break;
        default:
            break;
    }
}
void display_customer()
{
    Console.Clear();
    Console.WriteLine("Display customer info");
    string? input;
    switch (submode)
    {
        case 0:
            Console.WriteLine("Name - Address - Email - Phone number");
            //display the info of all customers per line
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i}: {customers[i].name} - {customers[i].address} - {customers[i].email} - {customers[i].phone}");
            }
            Console.WriteLine($"{customers.Count}: home");
            input = Console.ReadLine();
            //try to convert the input to a number, do nothing if it fails
            try { int.Parse(input); }
            catch { break; }
            //go back to home menu 
            if (int.Parse(input) == customers.Count)
            {
                mode = 0;
                break;
            }
            //prepare to display customer info
            if (int.Parse(input) <= customers.Count)
            {
                current_customer = customers[int.Parse(input)];
                Console.Clear();
                submode++;
                break;
            }
            else
                Console.WriteLine($"Invalid input '{input}'");
            break;
        //display the customer info
        case 1:
            display_current_customer_info();
            Console.WriteLine("\n0: back to home\n1: back to customer list\n2: edit info\n3: delete customer");
            input = Console.ReadLine();
            //back to all customers
            if (input == "0")
            {
                mode = 0;
                break;
            }
            else if (input == "1")
            {
                submode--;
                break;
            }
            //edit customer
            else if (input == "2")
            {
                mode = 3;
                submode = 0;
                break;
            }
            //delete customer
            else if (input == "3")
            {
                delete_customer();
                break;
            }
            break;
    }
}
void display_current_customer_info()
{
    Console.WriteLine($"Name: {current_customer.name}");
    Console.WriteLine($"Address: {current_customer.address}");
    Console.WriteLine($"Email: {current_customer.email}");
    Console.WriteLine($"Phone number: {current_customer.phone}");
}
void edit_customer()
{
    Console.Clear();
    Console.WriteLine("Edit customer info");
    string? input;
    int index = customers.IndexOf(current_customer);
    customer old_customer = current_customer;
    switch (submode)
    {
        case 0:
            display_current_customer_info();
            Console.WriteLine("\n0: Change name\n1: Change address\n2: Change email\n3: Change phone number\n4: Back to home");
            input = Console.ReadLine();
            //try to convert the input to a number, do nothing if it fails
            try { int.Parse(input); }
            catch { break; }
            if (int.Parse(input) < 4)
                submode = int.Parse(input) + 1;
            else
                mode = 0;
            return;
        case 1:
            Console.WriteLine("Edit customer name");
            current_customer.name = Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("Edit customer address");
            current_customer.address = Console.ReadLine();
            break;
        case 3:
            Console.WriteLine("Edit customer email");
            current_customer.email = Console.ReadLine();
            break;
        case 4:
            Console.WriteLine("Edit customer phone number");
            current_customer.phone = Console.ReadLine();
            break;
        default:
            return;
    }
    if (index != -1)
    {
        customers.Remove(old_customer);
        customers.Insert(index, current_customer);
    }
    else
        customers.Add(current_customer);
    save_customers();
    submode = 0;
}
void delete_customer()
{
    Console.WriteLine("Delete customer");
    Console.WriteLine("Do you want to delete this customer:\n");
    display_current_customer_info();
    Console.WriteLine("\n0:no\n1:yes");
    if (Console.ReadLine() == "1")
    {
        customers.Remove(current_customer);
        save_customers();
    }
    mode = 2;
    submode = 0;
    Console.Clear();
}
void load_customers()
{
    string path;
    string[] data;
    //load the customers from the current path
    path = Directory.GetCurrentDirectory() + "/customer list.txt";
    if (!File.Exists(path))
    {
        Console.WriteLine("Customer file not found.");
        Console.ReadLine();
        return;
    }
    data = File.ReadAllLines(path);
    //add the saved customers to the 'customers' list
    try
    {
        foreach (var item in data)
        {
            string[] customer_data = item.Split(',');
            customer new_customer = new customer
            {
                name = customer_data[0],
                address = customer_data[1],
                email = customer_data[2],
                phone = customer_data[3]
            };
            customers.Add(new_customer);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error reading data.\n\n{e}\n\npress enter to continue.");
        Console.ReadLine();
    }
}
void save_customers()
{
    //load the customers from the current path
    string path = Directory.GetCurrentDirectory() + "/customer list.txt";
    //clear the file to not save duplicate customers
    File.WriteAllText(path, string.Empty);
    //write customers to the file one by one
    foreach (customer customer in customers)
    {
        string info = customer.name + "," + customer.address + "," + customer.email + "," + customer.phone;
        File.AppendAllText(path, info + Environment.NewLine);
    }
}

load_customers();
//main loop 
while (true)
{
    switch (mode)
    {
        //main menu
        case 0:
            main_menu();
            break;
        //add customer
        case 1:
            add_customer();
            break;
        //display customer info
        case 2:
            display_customer();
            break;
        //edit the customer info
        case 3:
            edit_customer();
            break;
        default:
            mode = 0;
            break;
    }
}
struct customer
{
    public string name;
    public string address;
    public string email;
    public string phone;
}
