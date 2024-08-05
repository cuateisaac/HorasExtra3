using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HorasExtra.Data;
using System.Configuration;
using HorasExtra.Utilities;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace HorasExtra.Models
{
    public class Sp
    {
        string conexion = string.Empty;
        public Sp()
        {
            conexion = Connection.Instance.DB;
        }
        public string GetEmpData(int EmpNum)
        {
            DataTable data = null;
            using (var cnn = new SqlConnection(conexion))
            {
                cnn.Open();
                using (var cmd = new SqlCommand("GetEmployeeData", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmpNum", SqlDbType.Int).Value = EmpNum;
                    data = new DataTable();
                    var dataTable = new DataTable();
                    dataTable.Load(cmd.ExecuteReader());
                    string JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(dataTable);
                    return JSONString;

                }
            }
        }
        public string SaveRequest(Request req)
        {
            string json;
            using (var cnn = new SqlConnection(conexion))
            {
                cnn.Open();
                using (var cmd = new SqlCommand("SaveNewRequest", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Operation", SqlDbType.NChar).Value = req.Operation;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = req.Department;
                    cmd.Parameters.Add("@WorkSchedule", SqlDbType.NVarChar).Value = req.WorkSchedule;
                    cmd.Parameters.Add("@ManagerSignature", SqlDbType.VarChar).Value = req.ManagerSignature;
                    cmd.Parameters.Add("@SupervisorSignature", SqlDbType.VarChar).Value = req.SupervisorSignature;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = req.CreatedDate;
                    cmd.Parameters.Add("@UpdatedAt", SqlDbType.Date).Value = req.UpdatedAt;
                    int i = cmd.ExecuteNonQuery();
                    return json = JsonConvert.SerializeObject(Convert.ToBoolean(i));
                }
            }
        }
    }
}
