using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountAtAGlance.Model;
using AccountAtAGlance.Repository;
using Microsoft.Practices.Unity;

namespace AccountAtAGlance.Controllers
{  

    //MVC MORE CLEAN
    public class DataServiceController : Controller
    {
        IAccountRepository _AccountRepository;
        ISecurityRepository _SecurityRepository;        

        public DataServiceController(IAccountRepository acctRepo, ISecurityRepository secRepo)
        { 
            _AccountRepository = acctRepo;
            _SecurityRepository = secRepo;
        }

        public ActionResult GetCustomer(string custId)
        {
            var acct = _AccountRepository.GetCustomer(custId);
            return Json(acct, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTickerQuotes()
        {
            return Json(new { Markets = "good", News = "Morning news" }, JsonRequestBehavior.AllowGet); //Json don't care about object name, only care properties
        }

        public ActionResult GetAccount(string acctName)
        {
            return null;
        }

        public ActionResult GetQuote(string symbol)
        {
            return View();
        }

    }
   
    
    /* THIS OKAY
    public class DataServiceController : Controller
    {
        IAccountRepository _AccountRepository;
        ISecurityRepository _SecurityRepository;

        public DataServiceController(): this(null,null)
        {
        }

        public DataServiceController(IAccountRepository acctRepo, ISecurityRepository secRepo)
        {
            //also this can get job done if you do not use Ioc
            //_AccountRepository = acctRepo ?? new AccountRepository();

            //very loose coupled, everything are interface
            _AccountRepository = acctRepo ?? ModelContainer.Instance.Resolve<IAccountRepository>();           
            _SecurityRepository = secRepo ?? ModelContainer.Instance.Resolve<ISecurityRepository>();
        }

        public ActionResult GetCustomer(string custId)
        {
            var acct=_AccountRepository.GetCustomer(custId);
            return Json(acct, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTickerQuotes()
        {
            return Json(new { Markets = "good", News = "Morning news" }, JsonRequestBehavior.AllowGet); //Json don't care about object name, only care properties
        }

        public ActionResult GetAccount(string acctName)
        {
            return null;
        }

        public ActionResult GetQuote(string symbol)
        {
            return View();
        }       

    }
    */
}
