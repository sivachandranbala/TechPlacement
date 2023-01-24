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
            IEnumerable<DashboardMain> dashboardTransactionMains = _dashBoardRepository.getDasboard(Session["UserId"].ToString());
            return View(dashboardTransactionMains);
        }


       
        public ActionResult CollegeIndex()
        {
            IEnumerable<DashboardMain> studentDetails = _dashBoardRepository.getDasboard(Session["UserId"].ToString());
            return View(studentDetails);
        }

        public ActionResult PlacementReceive()
        {
            IEnumerable<PlacementDetails> placementDetails = _dashBoardRepository.getPlacementDetails(Session["UserId"].ToString());
            return View(placementDetails);
        }


        public PartialViewResult GetStudentById(int studentId)
        {
            StudentModel studentModel = _dashBoardRepository.GetAllStudentDetail(studentId)?.FirstOrDefault();


            return PartialView("StudentDetailPopup", studentModel ?? new StudentModel());
        }

        [HttpPost]
        public ActionResult AddStudentInformation(StudentModel studentModel)
        {


            int returnUserId = _dashBoardRepository.AddOrUpdateStudent(studentModel, Session["UserId"].ToString());

            if (returnUserId > 0)
            {
                return Json(new { success = true, message = "Student Added Successfully" });
            }

            else
            {
                return Json(new { success = false, message = "Student Added.Please Contact System Administrator." });

            }
        }

        [HttpPost]
        public ActionResult DeleteStudent(int studentId)
        {

            StudentModel studentModel = _dashBoardRepository.GetAllStudentDetail(studentId)?.FirstOrDefault();
            studentModel.IsActive = false;

            int returnUserId = _dashBoardRepository.AddOrUpdateStudent(studentModel, Session["UserId"].ToString());

            if (returnUserId > 0)
            {
                return Json(new { success = true, message = "Student Deleted Successfully" });
            }

            else
            {
                return Json(new { success = false, message = "Student deleted.Please Contact System Administrator." });

            }
        }


    }
    
}