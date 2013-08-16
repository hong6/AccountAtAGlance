using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public interface IAccountRepository
    {
        Customer GetCustomer(string custId);
        OperationStatus UpdateCustomers();
    }
}
