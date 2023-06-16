using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExamples.Service
{
    internal interface ICustomerService
    {
        void SaveCustomer(int customerId, 
            string customerFirstName, 
            string customerLastName,
            string streetAddress1, 
            string streetAddress2,
            string city, 
            string stateOrProvince,
            string postalCode, 
            string country,
            string homePhone,
            string mobilePhone,
            string primaryEmailAddress, 
            string secondaryEmailAddress);
    }
}
