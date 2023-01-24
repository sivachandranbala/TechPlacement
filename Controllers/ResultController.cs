using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechPlacement.Model;
using TechPlacement.Service.Interface;

namespace TechPlacement.Controllers
{
    public class ResultController : Controller
    {
        private IDashBoardRepository _dashBoardRepository;

        public ResultController(IDashBoardRepository dashBoardRepository)
        {
            _dashBoardRepository = dashBoardRepository;
        }
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // [Route("Candidate")]
        public ActionResult CandidateResults()
        {
            int cmpId = Convert.ToInt32(Session["UserId"].ToString());
            List<CandidateResults> candidateResults = _dashBoardRepository.SelectedCandidateResults(cmpId)?.ToList();
            return View("Result" ,candidateResults.ToList());
        }

        [HttpPost]
        public bool UpdateDetails(string resultId, string studId,string companyId, string roundId,string status)
        {

           int statusresult = _dashBoardRepository.UpdateCandidateResults(resultId, studId, companyId, roundId, status);
            //return RedirectToAction("CandidateResults");
            return true;
        }
    }
}