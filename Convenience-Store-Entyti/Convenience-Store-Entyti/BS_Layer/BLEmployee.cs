using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLEmployee
    {
        public DataTable TakeEmployee()
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            var det = from p in qlstoreEntity.Employees select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("eID");
            dt.Columns.Add("eName");
            dt.Columns.Add("eBirthdate");
            dt.Columns.Add("eGender");
            dt.Columns.Add("ePhone");
            dt.Columns.Add("eAddress");
            dt.Columns.Add("ePosition");
            dt.Columns.Add("eSalary");
            foreach (var p in det)
            {
                dt.Rows.Add(p.eID, p.eName, p.eBirthdate, p.eGender,p.ePhone,p.eAddress,p.ePosition,p.eSalary);
            }
            return dt;
        }
        public bool AddEmployee(string EID, string EName, DateTime EDateOfBirth, bool EGender, string EPhone, string EAddress, string EPosition, float ESalary, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();

                // create a new instance of the Employee object
                Employee emp = new Employee();

                // set the properties of the Employee object
                emp.eID = EID;
                emp.eName = EName;
                emp.eBirthdate = EDateOfBirth;
                emp.eGender = EGender;
                emp.ePhone = EPhone;
                emp.eAddress = EAddress;
                emp.ePosition = EPosition;
                emp.eSalary = ESalary;

                // add the Employee object to the DbContext
                qlstoreEntity.Employees.Add(emp);

                // save changes to the database
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
        public bool UpdateEmployee(string EID, string EName, DateTime EDateOfBirth, bool EGender, string EPhone, string EAddress, string EPosition, float ESalary, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();

                // retrieve the existing employee from the database using the specified EID
                Employee emp = qlstoreEntity.Employees.FirstOrDefault(e => e.eID == EID);

                if (emp != null)
                {
                    // update the properties of the Employee object
                    emp.eName = EName;
                    emp.eBirthdate = EDateOfBirth;
                    emp.eGender = EGender;
                    emp.ePhone = EPhone;
                    emp.eAddress = EAddress;
                    emp.ePosition = EPosition;
                    emp.eSalary = ESalary;

                    // save changes to the database
                    qlstoreEntity.SaveChanges();

                    // return true to indicate success
                    return true;
                }
                else
                {
                    // set the "err" parameter to indicate that the employee could not be found
                    err = "Employee with EID " + EID + " could not be found.";

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
        public bool DeleteEmployee(string eID, ref string err)
        {
            try
            {
                // create a new instance of the DbContext object
                ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();

                // retrieve the existing employee from the database using the specified EID
                Employee emp = qlstoreEntity.Employees.FirstOrDefault(e => e.eID == eID);

                if (emp != null)
                {
                    // remove the employee from the DbContext object and save changes to the database
                    qlstoreEntity.Employees.Remove(emp);
                    qlstoreEntity.SaveChanges();

                    // return true to indicate success
                    return true;
                }
                else
                {
                    // set the "err" parameter to indicate that the employee could not be found
                    err = "Employee with EID " + eID + " could not be found.";

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
