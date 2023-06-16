using DDDExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExamples.Service
{
    internal interface ICustomerRepository
    {
        Customer GetCustomer(int customerId);
    }
}
