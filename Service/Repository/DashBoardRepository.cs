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


        /// <summary>
        /// Get Selected Candidate Results
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        public List<CandidateResults> SelectedCandidateResults(int? companyId = 0)
        {
            List<CandidateResults> candidateResults = new List<CandidateResults>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetSelectedCandidateResults", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@CompanyId", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = companyId, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(param);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CandidateResults candidate = new CandidateResults();
                        candidate.RID = Convert.ToInt32(reader["RID"].ToString());
                        candidate.SId = (Int32)reader["SId"];
                        candidate.CId = (Int32)reader["CId"];
                        candidate.Name = reader["Name"].ToString();
                        candidate.CName = reader["CName"].ToString();
                        candidate.RoundName = reader["RoundName"].ToString();
                        candidate.RoundResult = (Int32)reader["RoundResult"];
                        candidate.OfferLetter = reader["OfferLetter"].ToString();
                        candidate.RoundText = reader["RoundText"].ToString();
                        candidate.Status = reader["Status"].ToString();
                        candidateResults.Add(candidate);
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return candidateResults;
        }



        /// <summary>
        /// Add/Update CandidateResults
        /// </summary>
        /// <param name="resultId"></param>
        /// <param name="studId"></param>
        /// <param name="CompanyId"></param>
        /// <param name="roundId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateCandidateResults(string resultId, string studId, string CompanyId, string roundId, string status)
        {
            List<CandidateResults> candidateResults = new List<CandidateResults>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.AddUpdateCandidateResults", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@resultId", SqlDbType.Int).Value = Convert.ToInt32(resultId);
                    cmd.Parameters.Add("@studId", SqlDbType.Int).Value = Convert.ToInt32(studId);
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = Convert.ToInt32(CompanyId);
                    cmd.Parameters.Add("@roundId", SqlDbType.Int).Value = Convert.ToInt32(roundId);
                    cmd.Parameters.Add("@statusId", SqlDbType.Int).Value = Convert.ToInt32(status);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;
        }

        public List<PlacementDetails> getPlacementDetails(string cId)
        {
            List<PlacementDetails> placementDetails = new List<PlacementDetails>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("getPlacementDetailsMasterForCollege", connection)
                {
                    CommandType = CommandType.StoredProcedure
                }; SqlParameter useridparam = new SqlParameter
                {
                    ParameterName = "@ClID",
                    SqlDbType = SqlDbType.Int,
                    Value = Convert.ToInt32(cId),
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
                    placement.NumberOfPositions = Convert.ToInt32(sdr["NumberOfPositions"]);
                    placement.InterviewDate = Convert.ToDateTime(sdr["InterviewDate"]);
                    placement.Status = sdr["Status"].ToString();
                    placementDetails.Add(placement);
                }
                return placementDetails;
            }
        }
        public List<PlacementDetails> getPlacementDetailsById(string cId, string pId)
        {
            List<PlacementDetails> placementDetails = new List<PlacementDetails>(); using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("getPlacementDetailsMaster", connection)
                {
                    CommandType = CommandType.StoredProcedure
                }; SqlParameter useridparam = new SqlParameter
                {
                    ParameterName = "@CID",
                    SqlDbType = SqlDbType.Int,
                    Value = Convert.ToInt32(cId),
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(useridparam);
                SqlParameter pidparam = new SqlParameter
                {
                    ParameterName = "@PID",
                    SqlDbType = SqlDbType.Int,
                    Value = Convert.ToInt32(pId),
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(pidparam);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    PlacementDetails placement = new PlacementDetails(); placement.JobCategory = sdr["JobCategory"].ToString();
                    placement.Min_CGPA = sdr["Min_CGPA"].ToString();
                    placement.NumberOfPositions = Convert.ToInt32(sdr["NumberOfPositions"]);
                    placement.InterviewDate = Convert.ToDateTime(sdr["InterviewDate"]);
                    placement.Status = sdr["Status"].ToString(); placementDetails.Add(placement);
                }
                return placementDetails;
            }
        }

        public List<InboxModel> GetInboxMessages(string userId, string loginType)
        {
            List<InboxModel> inboxDetails = new List<InboxModel>(); using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(loginType == "COLLEGE" ? "getCLInboxDetails" : "getCInboxDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure
                }; SqlParameter useridparam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = Convert.ToInt32(userId),
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(useridparam); connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    InboxModel inboxObj = new InboxModel();
                    inboxObj.Id = sdr["ID"].ToString();
                    inboxObj.Name = sdr["Name"].ToString();
                    inboxObj.FromName = sdr["FromName"].ToString();
                    inboxObj.From = sdr["From"].ToString();
                    inboxObj.To = sdr["To"].ToString();
                    inboxObj.Message = sdr["Message"].ToString();
                    inboxObj.EntryDate = sdr["EntryDate"].ToString();
                    inboxObj.MessageType = sdr["MessageType"].ToString();
                    inboxDetails.Add(inboxObj);
                }
                sdr.Close();
                SqlCommand cmnd = new SqlCommand(loginType == "COLLEGE" ? "[dbo].[COLLEGE_SELECT]" : "[dbo].[COMPANY_SELECT]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sdr = cmnd.ExecuteReader();
                List<string> cList = new List<string>();
                while (sdr.Read())
                {
                    cList.Add(Convert.ToString(sdr.GetValue(1)));
                }
                InboxModel inboxObj1 = new InboxModel();
                inboxObj1.Clist = cList; inboxDetails.Add(inboxObj1);
                sdr.Close();
                connection.Close();
            }
            return inboxDetails;
        }
        public InboxModel GetCompanyList()
        {
            InboxModel companyList = new InboxModel();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmdd = new SqlCommand("[dbo].[COMPANY_SELECT]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sdrr = cmdd.ExecuteReader();
                List<string> cList = new List<string>();
                while (sdrr.Read())
                {
                    cList.Add(Convert.ToString(sdrr.GetValue(1)));
                }
                companyList.Id = "-1";
                companyList.Name = "";
                companyList.Clist = cList;
                connection.Close();
                sdrr.Close();
            }
            return companyList;
        }
        public InboxModel GetCollegeList()
        {
            InboxModel collegeList = new InboxModel();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[College_SELECT]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sdr = cmd.ExecuteReader(); List<string> cList = new List<string>();
                while (sdr.Read())
                {
                    cList.Add(Convert.ToString(sdr.GetValue(1)));
                }
                collegeList.Id = "-1";
                collegeList.Clist = cList;
                connection.Close();
                sdr.Close();
            }
            return collegeList;
        }
    }
}