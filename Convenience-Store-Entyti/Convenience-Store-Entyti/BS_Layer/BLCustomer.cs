using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLLoyalCustomers
    {
        public DataTable TakeLoyalCustomers()
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            var det = from p in qlstoreEntity.LoyalCustomers select p;
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
        public bool AddLoyalCustomers(string cID, string cName, float TotalPay, string cPhone, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();

                // create a new instance of the LoyalCustomers object and set its properties
                LoyalCustomer cust = new LoyalCustomer();
                cust.cID = cID;
                cust.cName = cName;
                cust.cTotalpay = TotalPay;
                cust.cPhoneNum = cPhone;

                // add the new LoyalCustomers to the DbContext object and save changes to the database
                qlstoreEntity.LoyalCustomers.Add(cust);
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
        public bool UpdateLoyalCustomers(string cID, string cName, float TotalPay, string cPhone, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();

                // retrieve the existing LoyalCustomers from the database using the specified cID
                LoyalCustomer cust = qlstoreEntity.LoyalCustomers.FirstOrDefault(c => c.cID == cID);

                if (cust != null)
                {
                    // update the LoyalCustomers's properties with the provided parameters
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
                    // set the "err" parameter to indicate that the LoyalCustomers could not be found
                    err = "LoyalCustomers with cID " + cID + " could not be found.";

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
        public bool DeleteLoyalCustomers(string cID, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();

                // retrieve the LoyalCustomers to be deleted from the database using the specified cID
                LoyalCustomer cust = qlstoreEntity.LoyalCustomers.FirstOrDefault(c => c.cID == cID);

                if (cust != null)
                {
                    // remove the LoyalCustomers from the DbContext
                    qlstoreEntity.LoyalCustomers.Remove(cust);

                    // save changes to the database
                    qlstoreEntity.SaveChanges();

                    // return true to indicate success
                    return true;
                }
                else
                {
                    // set the "err" parameter to indicate that the LoyalCustomers could not be found
                    err = "LoyalCustomers with cID " + cID + " could not be found.";

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
