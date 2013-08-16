using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public class AccountRepository: RepositoryBase<AccountAtAGlance>, IAccountRepository
    {
        public Customer GetCustomer(string custId)
        {
            using (var context = DataContext)
            {
                return context.Customers
                .Include("BrokerageAccount")
                .Where(c => c.CustomerCode == custId).SingleOrDefault();
                
                
                //return new Customer();
            }
        }

        //could use void, this is a good practice
        public OperationStatus UpdateCustomers()
        {
            var opStatus = new OperationStatus { Status = true };
            //if (localdataonly) return opStatus;

            //blah blah blah

            //insert records
            try
            {
                DataContext.SaveChanges();
            }
            catch (Exception exp)
            {
                //var opstatus = OperationStatus.CreateFromException("Error updating customers", exp);
                //Logger.Log(opStatus);
                //return opstatus;

                return OperationStatus.CreateFromException("Error updating sth", exp);               
            }
            return opStatus;

        }

    }
}
