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
    public class AdminController : Controller
    {
        private MappingMethods mappingPO = new MappingMethods();
        private DALmethods dataMethods = new DALmethods();
        private BLLmethods bllMethods = new BLLmethods();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAccounts()
        {
            AccountModel viewModel = new AccountModel();
            List<AccountDO> accountDOList = dataMethods.ViewAllAccounts();
            foreach(AccountDO accountDO in accountDOList)
            {
                AccountPO accountPO = new AccountPO();
                accountPO = MappingMethods.MapAccountDOtoPO(accountDO);
                viewModel.accountList.Add(accountPO);
            }
            return View(viewModel);
        }

        public ActionResult DeleteAccount(int AccountID)
        {
            dataMethods.DeleteAccount(AccountID);
            return RedirectToAction("ViewAccounts", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateAccount(int AccountID)
        {
            AccountModel viewModel = new AccountModel();
            viewModel.aAccount = MappingMethods.MapAccountDOtoPO(dataMethods.GetAccountInfoByID(AccountID));
            viewModel.aAccount.AccountID = AccountID;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateAccount(AccountModel viewModel)
        {
            viewModel.aAccount.PassWord = bllMethods.PassWordHash(viewModel.aAccount.PassWord);
            dataMethods.UpdateAccountAdmin(MappingMethods.MapAccountPOtoDO(viewModel.aAccount));
            return RedirectToAction("ViewAccounts", "Admin");
        }
    }
}