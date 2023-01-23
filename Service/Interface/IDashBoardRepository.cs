using System;
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
        List<PlacementDetails> getPlacementDetails(string clId);
        List<StudentModel> GetAllStudentDetail(int? studentId = 0);

        int AddOrUpdateStudent(StudentModel studentModel, string clID);
    }
}
