using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoungsDrumStore.Models;
using YoungsDrumStoreDAL.Models;
using YoungsDrumStoreDAL;
using YoungsDrumStoreBLL;




namespace YoungsDrumStore.Controllers
{
    public class HomeController : Controller
    {
        private MappingMethods mappingPO = new MappingMethods();
        private DALmethods dataMethods = new DALmethods();
        private BLLmethods bllMethods = new BLLmethods();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterAccount(AccountModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.aAccount.PassWord = bllMethods.PassWordHash(viewModel.aAccount.PassWord);
                AccountDO accountDO = MappingMethods.MapAccountPOtoDO(viewModel.aAccount);
                dataMethods.CreateAccount(accountDO);
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel accountModel)
        {
            if (accountModel.aAccount.UserName != null)
            {
                accountModel.aAccount.PassWord = bllMethods.PassWordHash(accountModel.aAccount.PassWord);
                AccountDO accountDO = dataMethods.GetAccountInfoByUserName(accountModel.aAccount.UserName);
                

                if (ModelState.IsValid)
                {
                    if (accountModel.aAccount.PassWord == accountDO.PassWord)
                    {
                        accountModel.aAccount = MappingMethods.MapAccountDOtoPO(accountDO);
                        Session["RoleID"] = accountModel.aAccount.RoleID;
                        Session["AccountID"] = accountModel.aAccount.AccountID;
                        Session["FirstName"] = accountModel.aAccount.FirstName;
                        Session["LastName"] = accountModel.aAccount.LastName;
                        Session["Email"] = accountModel.aAccount.Email;

                        
                        return View("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is invalid.");
                    }
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();

            return View("Index");
        }
    }
}