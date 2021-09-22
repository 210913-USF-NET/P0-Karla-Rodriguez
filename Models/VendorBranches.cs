using System;
using System.Collections.Generic;

namespace Models
{
    public class VendorBranches
    {
        public VendorBranches() {}
        
        public string Name {get; set;}

        public string GrandCompany {get; set;} 

        public List<Inventory> Inventories {get; set;}
    }
}