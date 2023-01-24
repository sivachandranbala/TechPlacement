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
            IEnumerable<PlacementDetails> placementDetails = _dashBoardRepository.getPlacementDetails(Session["UserId"].ToString());
            return View(placementDetails);
        }
        public ActionResult AddPlacement(string id)
        {
            PlacementDetails placementDetails = _dashBoardRepository.getPlacementDetailsById(Session["UserId"].ToString(), id).FirstOrDefault();
            //return PartialView("PlacementDetailPopup");
            return PartialView("PlacementDetailPopup", placementDetails ?? new PlacementDetails());
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

            //IEnumerable<PlacementDetails> placementDetails = _dashBoardRepository.getPlacementDetails(Session["UserId"].ToString());
            //return View(placementDetails);
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

        public ActionResult CInboxx()
        {
            IEnumerable<InboxModel> inboxDetails = _dashBoardRepository.GetInboxMessages(Session["UserId"].ToString(), Session["Type"].ToString());
            return View(inboxDetails);
        }
        public PartialViewResult SendNewMessageById(int id)
        {
            InboxModel collegeListModel = Session["Type"].ToString() == "COLLEGE" ? _dashBoardRepository.GetCompanyList() : _dashBoardRepository.GetCollegeList();
            return PartialView("NewMessageById", collegeListModel ?? new InboxModel());
        }

    }
    
}