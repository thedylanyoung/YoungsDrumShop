using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoungsDrumStore.Models;
using YoungsDrumStoreDAL.Models;
using YoungsDrumStoreDAL;
using YoungsDrumStoreBLL.Models;
using YoungsDrumStoreBLL;

namespace YoungsDrumStore.Controllers
{
    public class StoreController : Controller
    {
        DALmethods dataMethods = new DALmethods();
        //DataMapper dataMapper = new DataMapper();
        BLLmethods bllMethods = new BLLmethods();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrowseDrums()
        {
            ProductModel productModel = new ProductModel();
            List<DrumDO> drumDOList = dataMethods.ViewAllDrums();
            foreach (DrumDO drumDO in drumDOList)
            {
                DrumPO drumPO = new DrumPO();
                drumPO = MappingMethods.MapDrumDOtoPO(drumDO);
                productModel.drumList.Add(drumPO);
            }

            return View(productModel.drumList);
        }

        public ActionResult BrowseCymbals()
        {
            ProductModel productModel = new ProductModel();
            List<CymbalDO> cymbalDOList = dataMethods.ViewAllCymbals();
            foreach (CymbalDO cymbalDO in cymbalDOList)
            {
                CymbalPO cymbalPO = new CymbalPO();
                cymbalPO = MappingMethods.MapCymbalDOtoPO(cymbalDO);
                productModel.cymbalList.Add(cymbalPO);
            }

            return View(productModel.cymbalList);
        }

        public ActionResult AddDrumToCart(List<DrumPO> drumList)
        {
            if (Session["AccountID"] != null)
            {
                ProductModel cart = new ProductModel();
                ProductModel productModel = new ProductModel();
                if (Session["ShoppingCart"] == null)
                {
                    Session["ShoppingCart"] = cart;

                }
                cart = (ProductModel)Session["ShoppingCart"];
                foreach (DrumPO drum in drumList)
                {
                    DrumPO drumPO = new DrumPO();
                    drumPO = MappingMethods.MapDrumDOtoPO(dataMethods.GetDrumInfoByID(drum.DrumID));
                    drumPO.CheckoutQty = drum.CheckoutQty;

                    if (drum.CheckoutQty > 0 && drum.CheckoutQty <= drum.DrumQuantity)
                    {
                        cart.drumList.Add(drumPO);
                    }
                    else
                    {

                    }
                }

                //productModel.aDrum = MappingMethods.MapDrumDOtoPO(dataMethods.GetDrumInfoByID(drumID));
                //productModel.aDrum.DrumID = drumID;

                Session["ShoppingCart"] = cart;

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("BrowseDrums", "Store");
        }

        public ActionResult RemoveDrumFromCart(int drumID)
        {
            if (Session["ShoppingCart"] != null)
            {
                ProductModel cart = new ProductModel();
                ProductModel productModel = new ProductModel();
                productModel.aDrum = MappingMethods.MapDrumDOtoPO(dataMethods.GetDrumInfoByID(drumID));
                cart = (ProductModel)Session["ShoppingCart"];
                cart.drumList.RemoveAll(x => x.DrumID == productModel.aDrum.DrumID);
                Session["ShoppingCart"] = cart;
            }
            return RedirectToAction("ViewCart", "Store");
        }

        public ActionResult AddCymbalToCart(List<CymbalPO> cymbalList)
        {
            if (Session["AccountID"] != null)
            {
                ProductModel cart = new ProductModel();
                ProductModel productModel = new ProductModel();
                if (Session["ShoppingCart"] == null)
                {
                    Session["ShoppingCart"] = cart;
                }
                cart = (ProductModel)Session["ShoppingCart"];
                foreach (CymbalPO cymbal in cymbalList)
                {
                    CymbalPO cymbalPO = new CymbalPO();
                    cymbalPO = MappingMethods.MapCymbalDOtoPO(dataMethods.GetCymbalInfoByID(cymbal.CymbalID));
                    cymbalPO.CheckoutQty = cymbal.CheckoutQty;

                    if (cymbal.CheckoutQty > 0 && cymbal.CheckoutQty <= cymbal.CymbalQuantity)
                    {
                        cart.cymbalList.Add(cymbalPO);
                    }
                    else
                    {

                    }
                }

                Session["ShoppingCart"] = cart;
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("BrowseCymbals", "Store");
        }

        public ActionResult RemoveCymbalFromCart(int cymbalID)
        {
            if (Session["ShoppingCart"] != null)
            {
                ProductModel cart = new ProductModel();
                ProductModel productModel = new ProductModel();
                productModel.aCymbal = MappingMethods.MapCymbalDOtoPO(dataMethods.GetCymbalInfoByID(cymbalID));
                cart = (ProductModel)Session["ShoppingCart"];
                cart.cymbalList.RemoveAll(x => x.CymbalID == productModel.aCymbal.CymbalID);
                Session["ShoppingCart"] = cart;
            }
            return RedirectToAction("ViewCart", "Store");
        }


        public ActionResult ViewCart()
        {
            ProductModel productModel = new ProductModel();

            if (Session["ShoppingCart"] != null)
            {
                productModel = (ProductModel)Session["ShoppingCart"];
                BusinessModel businessModel = MappingMethods.MapProductModeltoBusinessModel(productModel);
                productModel = MappingMethods.MapBusinessModeltoProductModel(businessModel);
                productModel.CartTotal = bllMethods.CalculateTotalPrice(businessModel);
            }
            else if (Session["AccountID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View(productModel);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            if (Session["AccountID"] != null && Session["ShoppingCart"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Checkout(Checkout checkoutModel)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("PlaceOrder", "Store");
            }
            else
            {
                return View();
            }
        }

        public ActionResult PlaceOrder()
        {

            ProductModel cart = new ProductModel();
            cart = (ProductModel)Session["ShoppingCart"];
            foreach (DrumPO drum in cart.drumList)
            {
                DrumDO drumDO = new DrumDO();
                drumDO = MappingMethods.MapDrumPOtoDO(drum);
                dataMethods.UpdateDrumQuantity(drum.DrumID, drum.CheckoutQty);
                DrumPO drumPO = MappingMethods.MapDrumDOtoPO(drumDO);
            }
            foreach (CymbalPO cymbal in cart.cymbalList)
            {
                CymbalDO cymbalDO = new CymbalDO();
                cymbalDO = MappingMethods.MapCymbalPOtoDO(cymbal);
                dataMethods.UpdateCymbalQty(cymbal.CymbalID, cymbal.CheckoutQty);
                CymbalPO cymbalPO = MappingMethods.MapCymbalDOtoPO(cymbalDO);
            }
            cart.cymbalList.Clear();
            cart.drumList.Clear();
            return View();
        }

    }
}