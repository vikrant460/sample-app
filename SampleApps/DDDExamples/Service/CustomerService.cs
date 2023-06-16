using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExamples.Service
{
    internal class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();     
        }
        public void SaveCustomer(int customerId, string customerFirstName, string customerLastName, string streetAddress1, string streetAddress2, string city, string stateOrProvince, string postalCode, string country, string homePhone, string mobilePhone, string primaryEmailAddress, string secondaryEmailAddress)
        {
            var customer = _customerRepository.GetCustomer(customerId);
        }
    }
}
