using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechPlacement.Common;
using TechPlacement.Model;
using TechPlacement.Model.Builders;
using TechPlacement.Service.Interface;


namespace TechPlacement.Controllers
{
    [CheckSession]
    public class DashboardController : Controller
    {
        private IDashBoardRepository _dashBoardRepository;

        public DashboardController(IDashBoardRepository dashBoardRepository)
        {
            _dashBoardRepository = dashBoardRepository;
        }
        public ActionResult Index()
        {
            IEnumerable<DashboardMain> dashboardTransactionMains = _dashBoardRepository.getDasboard(Session["UserId"].ToString(), Session["Type"].ToString());
            return View(dashboardTransactionMains);
        }


        public ActionResult RequsetPlacement()
        {
            IEnumerable<DashboardMain> dashboardTransactionMains = _dashBoardRepository.getDasboard(Session["UserId"].ToString(), Session["Type"].ToString());
            return View(dashboardTransactionMains);
        }

        public ActionResult CollegeIndex()
        {
            IEnumerable<DashboardMain> dashboardTransactionMains = _dashBoardRepository.getDasboard(Session["UserId"].ToString(), Session["Type"].ToString());
            return View(dashboardTransactionMains);
        }

        public PartialViewResult GetStudentById(int studentId)
        {
            StudentModel studentModel = _dashBoardRepository.GetAllStudentDetail(studentId)?.FirstOrDefault();


            return PartialView("StudentDetailPopup", studentModel ?? new StudentModel());
        }


    }
    
}