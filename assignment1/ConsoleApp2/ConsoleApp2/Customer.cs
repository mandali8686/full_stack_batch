namespace ConsoleApp2;

public class Customer
{
    // private string customerName;
    //
    // public string CustomerName
    // {
    //     get
    //     {
    //         return customerName;
    //     }
    //     set
    //     {
    //         customerName = value;
    //     }
    // }
    // public Customer(){}

    public Customer(int ID, string name, string email)
    {
        Id = ID;
        CustomerName = name;
        Email = email;
        
    }
    
    public Customer(int ID, string name, string email, string phone)
    {
        Id = ID;
        CustomerName = name;
        Email = email;
        Phone = phone;
        
    }

    public string CustomerName { get; set; }
    private int id;

    public int Id
    {
        get{return id;}
        private set{id = value;}
    }
    
    public string Email { get; set; }
    public string Phone { get; set; }
}