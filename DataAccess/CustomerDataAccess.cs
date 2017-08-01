using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceEntityFramework;
using BusinessObjects;




namespace DataAccess
{
    public class CustomerDataAccess
    {
        SampaldbEntities db = new SampaldbEntities();

        public bool CreateCustomer(Customer customer)
        {
            bool success = false;
            try
            {
                tblCustomer objtblCustomer = new tblCustomer();
                objtblCustomer.CustomerName = customer.CustomerName;
                objtblCustomer.CustomerAddress = customer.CustomerAddress;
                objtblCustomer.Nic = customer.Nic;
                objtblCustomer.EmailAddress = customer.Email;
                objtblCustomer.MobileNo = customer.MobileNo;

                db.tblCustomers.Add(objtblCustomer);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public List<Customer> GetAllCustomers()
        {
            var customerList = new List<Customer>();

            try
            {
                var entities = db.tblCustomers.ToList();

                foreach (var item in entities)
                {
                    Customer customer = new Customer();
                    customer.CustomerName = item.CustomerName;
                    customer.CustomerAddress = item.CustomerAddress;
                    customer.Nic = item.Nic;
                    customer.Email = item.EmailAddress;
                    customer.MobileNo = item.MobileNo;

                    customerList.Add(customer);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return customerList;
        }


        public Customer GetCustomer(string id)
        {
            Customer customer = new Customer();
            try
            {
                var entity = db.tblCustomers.Where(x => x.Nic == id).FirstOrDefault();
                customer.CustomerName = entity.CustomerName;
                customer.CustomerAddress = entity.CustomerAddress;
                customer.Email = entity.EmailAddress;
                customer.MobileNo = entity.MobileNo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return customer;
        }


        public bool UpdateCustomer(string id,Customer customer)
        {
            bool success = false;
            try
            {
                var entity = db.tblCustomers.Where(x => x.Nic == id).FirstOrDefault();
                if(entity!=null)
                {
                    entity.CustomerAddress = customer.CustomerAddress;
                    entity.CustomerName = customer.CustomerName;
                    entity.EmailAddress = customer.Email;
                    entity.MobileNo = customer.MobileNo;
                    db.SaveChanges();
                    success = true;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return success;
        }



    }
}
