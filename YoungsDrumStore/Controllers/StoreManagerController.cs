using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoungsDrumStore.Models;
using YoungsDrumStoreDAL.Models;
using YoungsDrumStoreDAL;

namespace YoungsDrumStore.Controllers
{
    public class StoreManagerController : Controller
    {
        DALmethods dataMethods = new DALmethods();
        DataMapper dataMapper = new DataMapper();

        // GET: StoreManager
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDrumProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDrumProduct(ProductModel drumModel)
        {
            if (ModelState.IsValid)
            {
                drumModel.aDrum.AccountID = (int)Session["AccountID"];
                DrumDO drumDO = MappingMethods.MapDrumPOtoDO(drumModel.aDrum);
                dataMethods.CreateDrum(drumDO);


                return RedirectToAction("ViewProducts", "StoreManager");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateDrumProduct(int DrumID)
        {
            ProductModel drumModel = new ProductModel();
            drumModel.aDrum = MappingMethods.MapDrumDOtoPO(dataMethods.GetDrumInfoByID(DrumID));
            drumModel.aDrum.DrumID = DrumID;
            return View(drumModel);
        }

        [HttpPost]
        public ActionResult UpdateDrumProduct(ProductModel drumModel)
        {
            if (ModelState.IsValid)
            {
                dataMethods.UpdateDrum(MappingMethods.MapDrumPOtoDO(drumModel.aDrum));
                return RedirectToAction("ViewProducts", "StoreManager");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddCymbalProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCymbalProduct(ProductModel cymbalModel)
        {
            cymbalModel.aCymbal.AccountID = (int)Session["AccountID"];
            CymbalDO cymbalDO = MappingMethods.MapCymbalPOtoDO(cymbalModel.aCymbal);
            dataMethods.CreateCymbal(cymbalDO);

            return RedirectToAction("ViewProducts", "StoreManager");
        }

        [HttpGet]
        public ActionResult UpdateCymbalProduct(int cymbalID)
        {
            ProductModel cymbalModel = new ProductModel();
            cymbalModel.aCymbal = MappingMethods.MapCymbalDOtoPO(dataMethods.GetCymbalInfoByID(cymbalID));
            cymbalModel.aCymbal.CymbalID = cymbalID;
            return View(cymbalModel);
        }

        [HttpPost]
        public ActionResult UpdateCymbalProduct(ProductModel cymbalModel)
        {
            dataMethods.UpdateCymbal(MappingMethods.MapCymbalPOtoDO(cymbalModel.aCymbal));
            return RedirectToAction("ViewProducts", "StoreManager");
        }

        public ActionResult DeleteDrum(int DrumID)
        {
            dataMethods.DeleteDrum(DrumID);
            return RedirectToAction("ViewProducts", "StoreManager");
        }

        public ActionResult DeleteCymbal(int cymbalID)
        {
            dataMethods.DeleteCymbal(cymbalID);
            return RedirectToAction("ViewProducts", "StoreManager");
        }
     
        public ActionResult ViewProducts()
        {
            ProductModel productModel = new ProductModel();
            List<DrumDO> drumDOList = dataMethods.ViewAllDrums();
            foreach (DrumDO drumDO in drumDOList)
            {
                DrumPO drumPO = new DrumPO();
                drumPO = MappingMethods.MapDrumDOtoPO(drumDO);
                productModel.drumList.Add(drumPO);
            }

            List<CymbalDO> cymbalDOList = dataMethods.ViewAllCymbals();
            foreach(CymbalDO cymbalDO in cymbalDOList)
            {
                CymbalPO cymbalPO = new CymbalPO();
                cymbalPO = MappingMethods.MapCymbalDOtoPO(cymbalDO);
                productModel.cymbalList.Add(cymbalPO);
            }
   
   
            return View(productModel);
        }
    }
}