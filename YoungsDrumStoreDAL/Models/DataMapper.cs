using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoungsDrumStoreDAL.Models;
using System.Data;

namespace YoungsDrumStoreDAL.Models
{
    public class DataMapper
    {
        public List<AccountDO> MapAccountTableToList(DataTable accountTable)
        {
            List<AccountDO> userList = new List<AccountDO>();
            if(accountTable != null && accountTable.Rows.Count > 0)
            {
                foreach(DataRow lRow in accountTable.Rows)
                {
                    userList.Add(MapRowToObjectAccount(lRow));
                }
            }
            return userList;
        }

        public List<RolesDO> MapRolesTableToList(DataTable rolesTable)
        {
            List<RolesDO> rolesList = new List<RolesDO>();
            if(rolesTable != null && rolesTable.Rows.Count > 0)
            {
                foreach(DataRow Row in rolesTable.Rows)
                {
                    rolesList.Add(MapRowToObjectRoles(Row));
                }
            }
            return rolesList;
        }

        public List<DrumDO> MapDrumTableToList(DataTable drumTable)
        {
            List<DrumDO> drumList = new List<DrumDO>();
            if(drumTable != null && drumTable.Rows.Count > 0)
            {
                foreach(DataRow Row in drumTable.Rows)
                {
                    drumList.Add(MapRowToObjectDrum(Row));
                }
            }
            return drumList;
        }

        public List<CymbalDO> MapDCymbalTableToList(DataTable cymbalTable)
        {
            List<CymbalDO> cymbalList = new List<CymbalDO>();
            if(cymbalTable != null && cymbalTable.Rows.Count > 0)
            {
                foreach(DataRow Row in cymbalTable.Rows)
                {
                    cymbalList.Add(MapRowToObjectCymbal(Row));
                }
            }
            return cymbalList;
        }

        public AccountDO MapRowToObjectAccount(DataRow accountTableRow)
        {
            AccountDO accountDO = new AccountDO();

            accountDO.AccountID = Convert.ToInt32(accountTableRow["AccountID"]);
            accountDO.RoleId = Convert.ToInt32(accountTableRow["RoleID"]);
            accountDO.UserName = accountTableRow["UserName"].ToString();
            //accountDO.PassWord = accountTableRow["PassWord"].ToString();
            accountDO.FirstName = accountTableRow["FirstName"].ToString();
            accountDO.LastName = accountTableRow["LastName"].ToString();
            accountDO.Email = accountTableRow["Email"].ToString();

            return accountDO;
        }

        public RolesDO MapRowToObjectRoles(DataRow rolesTableRow)
        {
            RolesDO rolesDO = new RolesDO();

            rolesDO.RoleID = Convert.ToInt32(rolesTableRow["RoleID"]);
            rolesDO.RoleName = rolesTableRow["RoleName"].ToString();

            return rolesDO;
        }

        public DrumDO MapRowToObjectDrum(DataRow drumTableRow)
        {
            DrumDO drumDO = new DrumDO();

            drumDO.AccountID = Convert.ToInt32(drumTableRow["AccountID"]);
            drumDO.BrandName = drumTableRow["BrandName"].ToString();
            drumDO.DrumType = drumTableRow["DrumType"].ToString();
            drumDO.DrumDescription = drumTableRow["DrumDescription"].ToString();
            drumDO.DrumQuantity = Convert.ToInt32(drumTableRow["DrumQuantity"]);
            drumDO.DrumPrice = Convert.ToDecimal(drumTableRow["DrumPrice"]);
            drumDO.DrumImgURL = drumTableRow["DrumImgURL"].ToString();
            drumDO.DrumID = Convert.ToInt32(drumTableRow["DrumID"]);

            return drumDO;
        }

        public CymbalDO MapRowToObjectCymbal(DataRow cymbalTableRow)
        {
            CymbalDO cymbalDO = new CymbalDO();

            cymbalDO.CymbalID = Convert.ToInt32(cymbalTableRow["CymbalID"]);
            cymbalDO.AccountID = Convert.ToInt32(cymbalTableRow["AccountID"]);
            cymbalDO.BrandName = cymbalTableRow["BrandName"].ToString();
            cymbalDO.CymbalName = cymbalTableRow["CymbalName"].ToString();
            cymbalDO.CymbalDescription = cymbalTableRow["CymbalDescription"].ToString();
            cymbalDO.CymbalPrice = Convert.ToDecimal(cymbalTableRow["CymbalPrice"]);
            cymbalDO.CymbalQuantity = Convert.ToInt32(cymbalTableRow["CymbalQuantity"]);
            cymbalDO.CymbalImgURL = cymbalTableRow["CymbalImgURL"].ToString();
            
            return cymbalDO;
        }
    }//end of class DataMapper
}//end of namespace
