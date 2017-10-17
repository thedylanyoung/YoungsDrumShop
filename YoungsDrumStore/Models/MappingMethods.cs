using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoungsDrumStoreDAL.Models;
using YoungsDrumStoreBLL.Models;

namespace YoungsDrumStore.Models
{
    public class MappingMethods
    {
        public static AccountPO MapAccountDOtoPO(AccountDO from)
        {
            AccountPO to = new AccountPO();

            to.RoleID = from.RoleId;
            to.AccountID = from.AccountID;
            to.UserName = from.UserName;
            to.PassWord = from.PassWord;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Email = from.Email;

            return to;
        }

        public static AccountDO MapAccountPOtoDO(AccountPO from)
        {
            AccountDO to = new AccountDO();

            to.RoleId = from.RoleID;
            to.AccountID = from.AccountID;
            to.UserName = from.UserName;
            to.PassWord = from.PassWord;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Email = from.Email;

            return to;
        }

        public static DrumPO MapDrumDOtoPO(DrumDO from)
        {
            DrumPO to = new DrumPO();

            to.AccountID = from.AccountID;
            to.DrumID = from.DrumID;
            to.BrandName = from.BrandName;
            to.DrumType = from.DrumType;
            to.DrumDescription = from.DrumDescription;
            to.DrumPrice = from.DrumPrice;
            to.DrumQuantity = from.DrumQuantity;
            to.DrumImgURL = from.DrumImgURL;
            

            return to;
        }

        public static DrumDO MapDrumPOtoDO(DrumPO from)
        {
            DrumDO to = new DrumDO();

            to.AccountID = from.AccountID;
            to.DrumID = from.DrumID;
            to.BrandName = from.BrandName;
            to.DrumType = from.DrumType;
            to.DrumDescription = from.DrumDescription;
            to.DrumPrice = from.DrumPrice;
            to.DrumQuantity = from.DrumQuantity;
            to.DrumImgURL = from.DrumImgURL;

            return to;
        }

        public static CymbalPO MapCymbalDOtoPO(CymbalDO from)
        {
            CymbalPO to = new CymbalPO();

            to.AccountID = from.AccountID;
            to.CymbalID = from.CymbalID;
            to.BrandName = from.BrandName;
            to.CymbalDescription = from.CymbalDescription;
            to.CymbalName = from.CymbalName;
            to.CymbalPrice = from.CymbalPrice;
            to.CymbalQuantity = from.CymbalQuantity;
            to.CymbalImgURL = from.CymbalImgURL;

            return to;
        }

        public static CymbalDO MapCymbalPOtoDO(CymbalPO from)
        {
            CymbalDO to = new CymbalDO();

            to.AccountID = from.AccountID;
            to.CymbalID = from.CymbalID;
            to.BrandName = from.BrandName;
            to.CymbalDescription = from.CymbalDescription;
            to.CymbalName = from.CymbalName;
            to.CymbalPrice = from.CymbalPrice;
            to.CymbalQuantity = from.CymbalQuantity;
            to.CymbalImgURL = from.CymbalImgURL;

            return to;
        }

        public static DrumPO MapDrumBOtoPO(DrumBO from)
        {
            DrumPO to = new DrumPO();

            to.AccountID = from.AccountID;
            to.DrumID = from.DrumID;
            to.BrandName = from.BrandName;
            to.DrumDescription = from.DrumDescription;
            to.DrumImgURL = from.DrumImgURL;
            to.DrumType = from.DrumType;
            to.DrumPrice = from.DrumPrice;
            to.DrumQuantity = from.DrumQuantity;
            to.CheckoutQty = from.CheckoutQty;

            return to;
        }

        public static DrumBO MapDrumPOtoBO(DrumPO from)
        {
            DrumBO to = new DrumBO();

            to.AccountID = from.AccountID;
            to.DrumID = from.DrumID;
            to.BrandName = from.BrandName;
            to.DrumDescription = from.DrumDescription;
            to.DrumImgURL = from.DrumImgURL;
            to.DrumType = from.DrumType;
            to.DrumPrice = from.DrumPrice;
            to.DrumQuantity = from.DrumQuantity;
            to.CheckoutQty = from.CheckoutQty;

            return to;
        }

        public static CymbalPO MapCymbalBOtoPO(CymbalBO from)
        {
            CymbalPO to = new CymbalPO();

            to.AccountID = from.AccountID;
            to.CymbalID = from.CymbalID;
            to.CymbalName = from.CymbalName;
            to.BrandName = from.BrandName;
            to.CymbalDescription = from.CymbalDescription;
            to.CymbalImgURL = from.CymbalImgURL;
            to.CymbalPrice = from.CymbalPrice;
            to.CymbalQuantity = from.CymbalQuantity;
            to.CheckoutQty = from.CheckoutQty;

            return to;
        }

        public static CymbalBO MapCymbalPOtoBO(CymbalPO from)
        {
            CymbalBO to = new CymbalBO();

            to.AccountID = from.AccountID;
            to.CymbalID = from.CymbalID;
            to.CymbalName = from.CymbalName;
            to.BrandName = from.BrandName;
            to.CymbalDescription = from.CymbalDescription;
            to.CymbalImgURL = from.CymbalImgURL;
            to.CymbalPrice = from.CymbalPrice;
            to.CymbalQuantity = from.CymbalQuantity;
            to.CheckoutQty = from.CheckoutQty;

            return to;
        }

        public static BusinessModel MapProductModeltoBusinessModel(ProductModel from)
        {
            BusinessModel to = new BusinessModel();

            foreach (DrumPO drum in from.drumList)
            {
                DrumBO drumBO = new DrumBO();
                drumBO = MapDrumPOtoBO(drum);
                to.drumList.Add(drumBO);
            }
            foreach (CymbalPO cymbal in from.cymbalList)
            {
                CymbalBO cymbalBO = new CymbalBO();
                cymbalBO = MapCymbalPOtoBO(cymbal);
                to.cymbalList.Add(cymbalBO);
            }
            from.CartTotal = to.CartTotal;
            return to;
        }

        public static ProductModel MapBusinessModeltoProductModel(BusinessModel from)
        {
            ProductModel to = new ProductModel();
            from.CartTotal = to.CartTotal;
            foreach (DrumBO drum in from.drumList)
            {
                DrumPO drumPO = new DrumPO();
                drumPO = MapDrumBOtoPO(drum);
                to.drumList.Add(drumPO);
            }
            foreach (CymbalBO cymbal in from.cymbalList)
            {
                CymbalPO cymbalPO = new CymbalPO();
                cymbalPO = MapCymbalBOtoPO(cymbal);
                to.cymbalList.Add(cymbalPO);
            }
            from.CartTotal = to.CartTotal;
            return to;
        }
    }
}