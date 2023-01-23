using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TechPlacement.Model;
using TechPlacement.Service.Interface;

namespace TechPlacement.Service.Repository
{
    public class DashBoardRepository : IDashBoardRepository
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString;



        public List<DashboardMain> getDasboard(string userId, string loginType)
        {
            List<DashboardMain> dashboardDetails = new List<DashboardMain>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("getDashBoardDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter useridparam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = Convert.ToInt32(userId),
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(useridparam);
                SqlParameter idTypeparam = new SqlParameter
                {
                    ParameterName = "@Type",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = loginType,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(idTypeparam);

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardMain dashboard = new DashboardMain();
                    dashboard.StudentId = sdr["SID"].ToString();
                    dashboard.Name = sdr["Name"].ToString();
                    dashboard.EnrollNo = sdr["EnrollNo"].ToString();
                    dashboard.Education = sdr["Education"].ToString();
                    dashboard.PassYear = sdr["PassYear"].ToString();
                    dashboard.Department = sdr["Department"].ToString();
                    dashboard.CGPA = sdr["CGPA"].ToString();
                    dashboard.Skill = sdr["Skill"].ToString();
                    dashboard.Address = sdr["Address"].ToString();
                    dashboard.PersonName = sdr["PersonName"].ToString();
                    dashboard.ContactEmail = sdr["ContactEmail"].ToString();
                    dashboard.MobileNo = sdr["MobileNo"].ToString();
                    dashboardDetails.Add(dashboard);
                }

            }

            return dashboardDetails;

        }

        public List<PlacementDetails> getPlacementDetails(string clId)
        {
            List<PlacementDetails> placementDetails = new List<PlacementDetails>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("getPlacementDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter useridparam = new SqlParameter
                {
                    ParameterName = "@CID",
                    SqlDbType = SqlDbType.Int,
                    Value = Convert.ToInt32(clId),
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(useridparam);


                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    PlacementDetails placement = new PlacementDetails();
                    placement.LastDate = sdr["LastDate"].ToString();
                    placement.JobCategory = sdr["JobCategory"].ToString();
                    placement.RequiredSkill = sdr["RequiredSkill"].ToString();
                    placement.Role = sdr["Role"].ToString();
                    placement.Min_Qualification = sdr["Min_Qualification"].ToString();
                    placement.Extra_Skill = sdr["Extra_Skill"].ToString();
                    placement.MaxAge = sdr["MaxAge"].ToString();
                    placement.JobLocation = sdr["JobLocation"].ToString();
                    placementDetails.Add(placement);

                }

                return placementDetails;

            }

        }

        
        public List<StudentModel> GetAllStudentDetail(int? studentId = 0)
        {
            List<StudentModel> studentDetails = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.getStudentDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter rfTagSerialparam = new SqlParameter
                {
                    ParameterName = "@StudentId", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Int, //Data Type of Parameter
                    Value = studentId, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd.Parameters.Add(rfTagSerialparam);

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    StudentModel studentModel = new StudentModel();
                    studentModel.SId = Convert.ToInt32(sdr["SId"].ToString());
                    studentModel.EnrollNo = sdr["EnrollNo"].ToString();
                    studentModel.FName = sdr["FName"].ToString();
                    studentModel.LName = sdr["LName"].ToString();
                    studentModel.Address = sdr["Address"].ToString();
                    studentModel.City = sdr["City"].ToString();
                    studentModel.State = sdr["State"].ToString();
                    studentModel.Pincode = sdr["Pincode"].ToString();
                    studentModel.Dob = Convert.ToDateTime(sdr["Dob"]);
                    studentModel.Gender = Convert.ToString(sdr["Gender"]);
                    studentModel.MobileNo = sdr["MobileNo"].ToString();
                    studentModel.EmailId = Convert.ToString(sdr["EmailId"]);
                    studentModel.IsActive = Convert.ToBoolean(sdr["IsActive"]);

                    studentDetails.Add(studentModel);
                }

            }

            return studentDetails;
        }
    }
}