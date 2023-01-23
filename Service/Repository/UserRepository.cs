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
    public class UserRepository : IUserRepository
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString;
        public UserInfo GetUserDetails(UserInfo userInfo)
        {
            UserInfo result = new UserInfo();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_CheckLoginCredential", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter usernameparam = new SqlParameter
                {
                    ParameterName = "@Username", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                    Value = userInfo.UName, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd.Parameters.Add(usernameparam);

                SqlParameter passwordparam = new SqlParameter
                {
                    ParameterName = "@Password", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                    Value = userInfo.Password, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd.Parameters.Add(passwordparam);


                SqlParameter type = new SqlParameter
                {
                    ParameterName = "@Type", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                    Value = userInfo.Type, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd.Parameters.Add(type);


                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    result.UserId = sdr["UserId"].ToString();
                }

            }

            return result;
        }
        public int CollegeRegister(CollegeMasterModel collegeMaster)
        {
            int clRegisterId = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[College_INSERT]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter collegeNameparam = new SqlParameter
                {
                    ParameterName = "@CNAME",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.ClName,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(collegeNameparam);

                SqlParameter addressParam = new SqlParameter
                {
                    ParameterName = "@ADDRESS",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.Address,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(addressParam);
                SqlParameter cityParam = new SqlParameter
                {
                    ParameterName = "@CITY",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.City,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(cityParam);
                SqlParameter stateParam = new SqlParameter
                {
                    ParameterName = "@STATE",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.State,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(stateParam);
                SqlParameter pincodeParam = new SqlParameter
                {
                    ParameterName = "@PINCODE",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.Pincode,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(pincodeParam);
                SqlParameter contactPersonParam = new SqlParameter
                {
                    ParameterName = "@CONTACT_PERSON",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.ContactPerson,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(contactPersonParam);

                SqlParameter mobileNoParam = new SqlParameter
                {
                    ParameterName = "@MOBILENO",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.MobileNo,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(mobileNoParam);
                SqlParameter contactNoParam = new SqlParameter
                {
                    ParameterName = "@CONTACT_NO",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.ContactNo,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(contactNoParam);

                SqlParameter clEmailIdParam = new SqlParameter
                {
                    ParameterName = "@EMAILID",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.ClEmailId,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(clEmailIdParam);

                SqlParameter ctEmailIdParam = new SqlParameter
                {
                    ParameterName = "@ContactEMAILID",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.ContactEmailId,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(ctEmailIdParam);
                SqlParameter websiteParam = new SqlParameter
                {
                    ParameterName = "@WEBSITE",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.Website,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(websiteParam);

                SqlParameter userNameParam = new SqlParameter
                {
                    ParameterName = "@USERNAME",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.UName,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(userNameParam);
                SqlParameter pwdParam = new SqlParameter
                {
                    ParameterName = "@PASSWORD",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = collegeMaster.Password,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(pwdParam);

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    clRegisterId = Convert.ToInt32(sdr["ClId"]);
                }

            }
            return clRegisterId;

        }

        public int CompanyRegister(CompanyMasterModel companyModel)
        {
            int clRegisterId = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Company_INSERT]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter collegeNameparam = new SqlParameter
                {
                    ParameterName = "@CNAME",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.CName,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(collegeNameparam);

                SqlParameter addressParam = new SqlParameter
                {
                    ParameterName = "@ADDRESS",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.Address,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(addressParam);
                SqlParameter cityParam = new SqlParameter
                {
                    ParameterName = "@CITY",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.City,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(cityParam);
                SqlParameter stateParam = new SqlParameter
                {
                    ParameterName = "@STATE",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.State,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(stateParam);
                SqlParameter pincodeParam = new SqlParameter
                {
                    ParameterName = "@PINCODE",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.Pincode,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(pincodeParam);
                SqlParameter contactPersonParam = new SqlParameter
                {
                    ParameterName = "@CONTACT_PERSON",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.ContactPerson,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(contactPersonParam);

                SqlParameter mobileNoParam = new SqlParameter
                {
                    ParameterName = "@MOBILENO",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.MobileNo,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(mobileNoParam);
                SqlParameter contactNoParam = new SqlParameter
                {
                    ParameterName = "@CONTACT_NO",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.ContactNo,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(contactNoParam);

                SqlParameter clEmailIdParam = new SqlParameter
                {
                    ParameterName = "@EMAILID",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.CEmailId,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(clEmailIdParam);

                SqlParameter ctEmailIdParam = new SqlParameter
                {
                    ParameterName = "@ContactEMAILID",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.ContactEmailId,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(ctEmailIdParam);
                SqlParameter websiteParam = new SqlParameter
                {
                    ParameterName = "@WEBSITE",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.Website,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(websiteParam);

                SqlParameter userNameParam = new SqlParameter
                {
                    ParameterName = "@USERNAME",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.UName,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(userNameParam);
                SqlParameter pwdParam = new SqlParameter
                {
                    ParameterName = "@PASSWORD",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = companyModel.Password,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(pwdParam);

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    clRegisterId = Convert.ToInt32(sdr["CId"]);
                }

            }
            return clRegisterId;

        }
    }
}