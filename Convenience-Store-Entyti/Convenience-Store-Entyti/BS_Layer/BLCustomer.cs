using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLCustomer
    {
        public DataTable TakeCustomer()
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            var det = from p in qlstoreEntity.Customers select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("cID");
            dt.Columns.Add("cName");
            dt.Columns.Add("cTotalpay");
            dt.Columns.Add("cPhoneNum");
            foreach (var p in det)
            {
                dt.Rows.Add(p.cID, p.cName,p.cTotalpay, p.cPhoneNum);
            }
            return dt;
        }
        public bool AddCustomer(string cID, string cName, float TotalPay, string cPhone, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();

                // create a new instance of the Customer object and set its properties
                Customer cust = new Customer();
                cust.cID = cID;
                cust.cName = cName;
                cust.cTotalpay = TotalPay;
                cust.cPhoneNum = cPhone;

                // add the new customer to the DbContext object and save changes to the database
                qlstoreEntity.Customers.Add(cust);
                qlstoreEntity.SaveChanges();

                // return true to indicate success
                return true;
            }
            catch (Exception ex)
            {
                // set the "err" parameter to the error message
                err = ex.Message;

                // return false to indicate failure
                return false;
            }
        }
        public bool UpdateCustomer(string cID, string cName, float TotalPay, string cPhone, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();

                // retrieve the existing customer from the database using the specified cID
                Customer cust = qlstoreEntity.Customers.FirstOrDefault(c => c.cID == cID);

                if (cust != null)
                {
                    // update the customer's properties with the provided parameters
                    cust.cName = cName;
                    cust.cTotalpay = TotalPay;
                    cust.cPhoneNum = cPhone;

                    // save changes to the database
                    qlstoreEntity.SaveChanges();

                    // return true to indicate success
                    return true;
                }
                else
                {
                    // set the "err" parameter to indicate that the customer could not be found
                    err = "Customer with cID " + cID + " could not be found.";

                    // return false to indicate failure
                    return false;
                }
            }
            catch (Exception ex)
            {
                // set the "err" parameter to the error message
                err = ex.Message;

                // return false to indicate failure
                return false;
            }
        }
        public bool DeleteCustomer(string cID, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();

                // retrieve the customer to be deleted from the database using the specified cID
                Customer cust = qlstoreEntity.Customers.FirstOrDefault(c => c.cID == cID);

                if (cust != null)
                {
                    // remove the customer from the DbContext
                    qlstoreEntity.Customers.Remove(cust);

                    // save changes to the database
                    qlstoreEntity.SaveChanges();

                    // return true to indicate success
                    return true;
                }
                else
                {
                    // set the "err" parameter to indicate that the customer could not be found
                    err = "Customer with cID " + cID + " could not be found.";

                    // return false to indicate failure
                    return false;
                }
            }
            catch (Exception ex)
            {
                // set the "err" parameter to the error message
                err = ex.Message;

                // return false to indicate failure
                return false;
            }
        }


    }
}
