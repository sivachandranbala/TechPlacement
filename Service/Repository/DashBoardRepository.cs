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



        public List<DashboardMain> getDasboard(string userId)
        {
            List<DashboardMain> dashboardDetails = new List<DashboardMain>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[getStudentDashboardDetails]", connection)
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
             

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardMain dashboard = new DashboardMain();
                    dashboard.StudentId = sdr["SID"].ToString();
                    dashboard.Name = sdr["Name"].ToString();
                    dashboard.EnrollNo = sdr["EnrollNo"].ToString();
                    dashboard.PassYear = sdr["PassYear"].ToString();
                    dashboard.Department = sdr["Department"].ToString();
                    dashboard.CGPA = sdr["CGPA"].ToString();
                    dashboard.Skill = sdr["Skill"].ToString();
                    dashboard.Address = sdr["Address"].ToString();
                    dashboard.ContactEmail = sdr["ContactEmail"].ToString();
                    dashboard.MobileNo = sdr["MobileNo"].ToString();
                    dashboard.PassYear = sdr["Passyear"].ToString();
                    dashboard.OfferLetter = sdr["OfferLetter"].ToString();
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
                SqlCommand cmd = new SqlCommand("[dbo].[getPlacementDetailsById]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter useridparam = new SqlParameter
                {
                    ParameterName = "@ClgID",
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
                    placement.JobCategory = sdr["JobCategory"].ToString();
                    placement.Min_CGPA = sdr["Min_CGPA"].ToString();
                    placement.NumberOfPositions = sdr["NumberOfPositions"].ToString();
                    placement.InterviewDate = sdr["InterviewDate"].ToString();
                    placement.Status = sdr["Status"].ToString();
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
                    studentModel.Department = Convert.ToString(sdr["Department"]);
                    studentModel.PassYear = Convert.ToString(sdr["PassYear"]);
                    studentModel.CGPA = Convert.ToString(sdr["CGPA"]);
                    studentModel.Skill = Convert.ToString(sdr["Skill"]);
                    studentModel.IsActive = Convert.ToBoolean(sdr["IsActive"]);

                    studentDetails.Add(studentModel);
                }

            }

            return studentDetails;
        }

        public int AddOrUpdateStudent(StudentModel studentModel, string clID)
        {
            int studentId = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[AddorUpdateStudentDetail]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sIdparam = new SqlParameter
                {
                    ParameterName = "@StudentId", 
                    SqlDbType = SqlDbType.Int,
                    Value = studentModel.SId, 
                    Direction = ParameterDirection.Input 
                };
                cmd.Parameters.Add(sIdparam);
                SqlParameter fNameparam = new SqlParameter
                {
                    ParameterName = "@FName", 
                    SqlDbType = SqlDbType.NVarChar, 
                    Value = studentModel.FName,
                    Direction = ParameterDirection.Input 
                };
                cmd.Parameters.Add(fNameparam);

                SqlParameter lNameparam = new SqlParameter
                {
                    ParameterName = "@LName", 
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.LName, 
                    Direction = ParameterDirection.Input 
                };
                cmd.Parameters.Add(lNameparam);
                SqlParameter addrparam = new SqlParameter
                {
                    ParameterName = "@Address",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.Address,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(addrparam);
                SqlParameter cityparam = new SqlParameter
                {
                    ParameterName = "@City",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.City,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(cityparam);
                SqlParameter stateparam = new SqlParameter
                {
                    ParameterName = "@State",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.State,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(stateparam);

                SqlParameter pincodeparam = new SqlParameter
                {
                    ParameterName = "@Pincode",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.Pincode,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(pincodeparam);

                SqlParameter dobparam = new SqlParameter
                {
                    ParameterName = "@Dob",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.Dob,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(dobparam);
               
                SqlParameter genderparam = new SqlParameter
                {
                    ParameterName = "@Gender",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.Gender,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(genderparam);
                SqlParameter mnoparam = new SqlParameter
                {
                    ParameterName = "@MobileNo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.MobileNo,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(mnoparam);
           
                SqlParameter isActiveparam = new SqlParameter
                {
                    ParameterName = "@IsActive",
                    SqlDbType = SqlDbType.Bit,
                    Value = studentModel.IsActive,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(isActiveparam);



                SqlParameter departparam = new SqlParameter
                {
                    ParameterName = "@Department",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.Department,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(departparam);

                SqlParameter passyearparam = new SqlParameter
                {
                    ParameterName = "@PassYear",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.PassYear,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(passyearparam);
                SqlParameter cgpaparam = new SqlParameter
                {
                    ParameterName = "@CGPA",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.CGPA,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(cgpaparam);

                SqlParameter skillparam = new SqlParameter
                {
                    ParameterName = "@Skill",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.Skill,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(skillparam);


                SqlParameter enrollparam = new SqlParameter
                {
                    ParameterName = "@EnrollNo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = studentModel.EnrollNo,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(enrollparam);

                SqlParameter clIdparam = new SqlParameter
                {
                    ParameterName = "@ClId",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = clID,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(clIdparam);

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    studentId = Convert.ToInt32(sdr["StudentId"]);
                }

            }
            return studentId;
        }
    }
}