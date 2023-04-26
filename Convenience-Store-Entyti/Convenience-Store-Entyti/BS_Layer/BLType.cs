using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_Store_Entyti.BS_Layer
{
    class BLType
    {
        public DataTable TakeType()
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            var tys = from p in qlstoreEntity.Types select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("tID");
            dt.Columns.Add("tName");
            foreach (var p in tys)
            {
                dt.Rows.Add(p.tID, p.tName);
            }
            return dt;
        }
        public bool AddType(string tID, string tName,ref string err)
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            Type ty = new Type();
            ty.tID = tID; ty.tName = tName;
            qlstoreEntity.Types.Add(ty);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool DeleteType(ref string err, string tID)
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            Type ty = new Type();
            ty.tID = tID;
            qlstoreEntity.Types.Attach(ty);
            qlstoreEntity.Types.Remove(ty);
            qlstoreEntity.SaveChanges();
            return true;
        }
        public bool UpdateType(string tID, string tName, ref string err)
        {
            ConvenienceStoreEntityNew qlstoreEntity = new ConvenienceStoreEntityNew();
            var tyQuery = (from ty in qlstoreEntity.Types
                           where ty.tID == tID
                           select ty).SingleOrDefault();
            if (tyQuery != null)
            {
                tyQuery.tName = tName;
                qlstoreEntity.SaveChanges();
            }
            return true;
        }
    }
}
