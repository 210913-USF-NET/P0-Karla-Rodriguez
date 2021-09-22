using Models;
using System.Collections.Generic;


namespace DL
{
    public interface IRepo
    {
            Customers AddCustomers(Customers custo);
            List<Customers> GetAllCustomers();

            Customers UpdateCustomers(Customers customerToUpdate);
    }
}