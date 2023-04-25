using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLManuafacture
    {
        public DataTable TakeManuafacture()
        {
            ConvenienceStoreEntities qlstoreEntity = new ConvenienceStoreEntities();
            var mas = from p in qlstoreEntity.Manuafactures select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("mID");
            dt.Columns.Add("mName");
            dt.Columns.Add("mLocation");
            foreach (var p in mas)
            {
                dt.Rows.Add(p.mID, p.mName,p.mLocation);
            }
            return dt;
        }
        public bool AddManuafacture(string mID, string mName,string mLocation, ref string err)
        {
            ConvenienceStoreEntities qlstoreEntity = new ConvenienceStoreEntities();
            Manuafacture ma = new Manuafacture();
            ma.mID = mID; ma.mName = mName;ma.mLocation = mLocation;
            qlstoreEntity.Manuafactures.Add(ma);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool DeleteManuafacture(ref string err, string mID)
        {
            ConvenienceStoreEntities qlstoreEntity = new ConvenienceStoreEntities();
            Manuafacture ma = new Manuafacture();
            ma.mID = mID;
            qlstoreEntity.Manuafactures.Attach(ma);
            qlstoreEntity.Manuafactures.Remove(ma);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool UpdateManuafacture(string mID, string mName,string mLocation, ref string err)
        {
            ConvenienceStoreEntities qlstoreEntity = new ConvenienceStoreEntities();
            var maQuery = (from ma in qlstoreEntity.Manuafactures
                           where ma.mID == mID
                           select ma).SingleOrDefault();
            if (maQuery != null)
            {
                maQuery.mName = mName;
                maQuery.mLocation = mLocation;
                qlstoreEntity.SaveChanges();
            }
            return true;
        }
    }
}
