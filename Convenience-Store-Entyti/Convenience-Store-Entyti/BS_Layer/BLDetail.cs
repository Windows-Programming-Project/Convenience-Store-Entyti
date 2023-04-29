using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLDetail
    {
        public DataTable TakeDetail()
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            var det = from p in qlstoreEntity.Details select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("iID");
            dt.Columns.Add("pID");
            dt.Columns.Add("dAmount");
            dt.Columns.Add("dPrice");
            foreach (var p in det)
            {
                dt.Rows.Add(p.iID, p.pID, p.dAmount, p.dPrice);
            }
            return dt;
        }
       public bool AddDetail(string iID, string pID, int dAmount, float dPrice, ref string err)
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            Detail det = new Detail();
            det.iID = iID; 
            det.pID = pID; 
            det.dAmount = dAmount;
            det.dPrice = dPrice;
            qlstoreEntity.Details.Add(det);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool DeleteDetail(ref string err, string iID, string pID)
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            Detail det = new Detail();
            det.iID = iID;
            det.pID = pID;
            qlstoreEntity.Details.Attach(det);
            qlstoreEntity.Details.Remove(det);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool UpdateDetail(string iID, string pID, int dAmount, float dPrice, ref string err)
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            var maQuery = (from det in qlstoreEntity.Details
                           where det.iID == iID && det.pID == pID
            select det).SingleOrDefault();
            if (maQuery != null)
            {
                maQuery.dAmount = dAmount;
                maQuery.dPrice = dPrice;
                qlstoreEntity.SaveChanges();
            }
            return true;
        }
    }
}
