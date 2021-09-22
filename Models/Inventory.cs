using System;
namespace Models
{
public class Inventory
{
    public Products Item {get; set;} 

    public int Quantity {get; set;}
}
}
 //public override string ToString()
//return $"Vendor Name: {this.Name} \nGrandCompany: {this.GrandCompany}"; <-- you can use this when you need to have 
