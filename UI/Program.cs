using System;
using Models;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Chocobo Square!");
            
            VendorBranches myVendors = new VendorBranches() {
                Name = "Rowena",
                GrandCompany = "Twin Adders, Gridania"
            };

            Console.WriteLine(myVendors.Name);
            Console.WriteLine(myVendors.GrandCompany);
            
        }
    }
}
