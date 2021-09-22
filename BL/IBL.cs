using System;
using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IBL
    {
        List<VendorBranches> GetVendorBranches();
    }
}
