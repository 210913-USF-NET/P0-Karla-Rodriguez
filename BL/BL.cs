using System.Collections.Generic;
using Models;
using DL;
using System;

namespace BL
{
    public class BL : IBL
    {
        
            private IRepo _repo;
            //you are using dependency injection here
            public BL(IRepo repo)
            {
                _repo = repo;
            }
            public List<VendorBranches> GetAllVendorBranches()
            {
            return _repo.GetAllVendorBranches();
            }
    }
}