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
    public class HomeRepository : IHomeRepository
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString;

        public List<Functions> GetFunctionsList(int userId, int functionTypeId)
        {
            List<Functions> functionsList = new List<Functions>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetFunctionsByType", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter usernameparam = new SqlParameter
                {
                    ParameterName = "@UserId", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Int, //Data Type of Parameter
                    Value = userId, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd.Parameters.Add(usernameparam);

                SqlParameter passwordparam = new SqlParameter
                {
                    ParameterName = "@FunctionTypeId", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Int, //Data Type of Parameter
                    Value = functionTypeId, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd.Parameters.Add(passwordparam);


                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Functions functionsDT = new Functions();
                    functionsDT.FunctionId = Convert.ToInt32(sdr["FunctionId"]);
                    functionsDT.FunctionName = sdr["FunctionName"].ToString();
                    functionsDT.FunctionTypeId = Convert.ToInt32(sdr["FunctionTypeId"]);
                    functionsDT.FunctionType = sdr["FunctionType"].ToString();
                    functionsDT.FunctionLink = sdr["FunctionLink"].ToString();
                    functionsDT.ParentFunctionId = ((sdr["ParentFunctionId"].ToString()) == string.Empty) ? 0 : Convert.ToInt32(sdr["ParentFunctionId"]);
                    functionsList.Add(functionsDT);
                }

            }
            return functionsList;
        }
    }
}