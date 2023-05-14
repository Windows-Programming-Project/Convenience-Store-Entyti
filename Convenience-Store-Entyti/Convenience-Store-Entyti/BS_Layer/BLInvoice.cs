using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Convenience_Store_Entyti.BS_Layer
{
    class BLInvoice
    {
        public DataTable TakeInvoice()
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            var inv = from p in qlstoreEntity.Invoices select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("iID");
            dt.Columns.Add("eID");
            dt.Columns.Add("cID");
            dt.Columns.Add("iDate");
            dt.Columns.Add("iTotalpay");
            foreach (var p in inv)
            {
                dt.Rows.Add(p.iID, p.eID, p.cID, p.iDate, p.iTotalpay);
            }
            return dt;
        }
        public bool AddInvoice(string iID, string eID, string cID, DateTime iDate, float iTotal, ref string err)
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            Invoice inv = new Invoice();
            inv.iID = iID; 
            inv.eID = eID; 
            inv.cID = cID;
            inv.iDate = iDate;
            inv.iTotalpay = iTotal; 
            qlstoreEntity.Invoices.Add(inv);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool DeleteInvoice(ref string err, string iID, string eID, string cID)
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            Invoice inv = new Invoice();
            inv.iID = iID;
            inv.eID = eID;
            inv.cID = cID;
            qlstoreEntity.Invoices.Attach(inv);
            qlstoreEntity.Invoices.Remove(inv);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool UpdateInvoice(string iID, string eID, string cID, DateTime iDate, float iTotal, ref string err)
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            var maQuery = (from inv in qlstoreEntity.Invoices
                           where inv.iID == iID
                           select inv).SingleOrDefault();
            if (maQuery != null)
            {
                maQuery.eID = eID;
                maQuery.cID = cID;
                maQuery.iDate = iDate;
                maQuery.iTotalpay = iTotal;
                qlstoreEntity.SaveChanges();
            }
            return true;
        }
    }
}
