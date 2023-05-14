using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLProduct
    {
        public DataTable TakeProduct()
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            var pro = from p in qlstoreEntity.Products select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("pID");
            dt.Columns.Add("pName");
            dt.Columns.Add("pPrice");
            dt.Columns.Add("tID");
            dt.Columns.Add("batchID");
            foreach (var p in pro)
            {
                dt.Rows.Add(p.pID, p.pName, p.pPrice, p.tID, p.batchID);
            }
            return dt;
        }
        public bool AddProduct(string pID, string pName, float pPrice, string tID, string batchID, ref string err)
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            Product det = new Product();
            det.pID = pID;
            det.pName = pName;
            det.pPrice = pPrice;
            det.tID = tID;
            det.batchID = batchID;
            qlstoreEntity.Products.Add(det);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool DeleteProduct(ref string err, string pID, string tID, string batchID)
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            Product det = new Product();
            det.pID = pID;
            det.tID = tID;
            det.batchID = batchID;
            qlstoreEntity.Products.Attach(det);
            qlstoreEntity.Products.Remove(det);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool UpdateProduct(string pID, string pName, float pPrice, string tID, string batchID, ref string err)
        {
            ConvenienceStoreManagementEntities qlstoreEntity = new ConvenienceStoreManagementEntities();
            var maQuery = (from det in qlstoreEntity.Products
                           where det.pID == pID
                           select det).SingleOrDefault();
            if (maQuery != null)
            {
                maQuery.pName = pName;
                maQuery.pPrice = pPrice;
                maQuery.tID = tID;
                maQuery.batchID = batchID;
                qlstoreEntity.SaveChanges();
            }
            return true;
        }
    }
}
