using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CRUDDemo.Models
{
    public class EmployeeDAL
    {
        string connectionString = "Data Source=DESKTOP-TG1HMOC;Initial Catalog = EMPLOYEEDB;Persist Security Info = False;User ID=sa;password=123;";

        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Nombre = dr["Nombre"].ToString();
                    emp.Genero = dr["Genero"].ToString();
                    emp.Compañia = dr["Compañia"].ToString();
                    emp.Departamento = dr["Departamento"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
        }

        //To Insert Employee
        public void AddEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Genero", emp.Genero);
                cmd.Parameters.AddWithValue("@Compañia", emp.Compañia);
                cmd.Parameters.AddWithValue("@Departamento", emp.Departamento);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update Employee
        public void UpdateEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", emp.ID);
                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Genero", emp.Genero);
                cmd.Parameters.AddWithValue("@Compañia", emp.Compañia);
                cmd.Parameters.AddWithValue("@Departamento", emp.Departamento);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Delete Employee
        public void DeleteEmployee(int? empId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);
          
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get Employee By ID
        public EmployeeInfo GetEmployeeById(int? empId)
        {
            EmployeeInfo emp = new EmployeeInfo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", empId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Nombre = dr["Nombre"].ToString();
                    emp.Genero = dr["Genero"].ToString();
                    emp.Compañia = dr["Compañia"].ToString();
                    emp.Departamento = dr["Departamento"].ToString();
                   
                }
                con.Close();
            }
            return emp;
        }
    }
}
