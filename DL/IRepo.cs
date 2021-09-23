using Models;
using System.Collections.Generic;


namespace DL
{
    public interface IRepo
    {
            Customers AddCustomers(Customers custo);
            List<Customers> GetAllCustomers();

            Customers UpdateCustomers(Customers customerToUpdate);
        List<Customers> SearchCustomers(string queryStr);

        Orders AddOrder(Orders order);

        Customers GetOneCustomerById(int id);
    }
}