using DDDExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExamples.Service
{
    internal class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int customerId)
        {
            return new Customer();
        }
    }
}
