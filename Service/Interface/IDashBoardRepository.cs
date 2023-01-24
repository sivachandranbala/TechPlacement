﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPlacement.Model;

namespace TechPlacement.Service.Interface
{
    public interface IDashBoardRepository
    {
        List<DashboardMain> getDasboard(string userId);
        List<PlacementDetails> getPlacementDetails(string cId);
        List<StudentModel> GetAllStudentDetail(int? studentId = 0);
        List<CandidateResults> SelectedCandidateResults(int? companyId = 0);
        int UpdateCandidateResults(string resultId, string studId, string companyId, string roundId, string status);

        int AddOrUpdateStudent(StudentModel studentModel, string clID);
        List<PlacementDetails> getPlacementDetailsById(string cId, string pId);
        List<InboxModel> GetInboxMessages(string userId, string loginType);
        InboxModel GetCompanyList();
        InboxModel GetCollegeList();
    }
}
