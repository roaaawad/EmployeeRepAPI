using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCRUD.Models
{
    public class Dal
    {

        public Response GetALLEmployees(SqlConnection connection)
        {
            Response Response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DEMOPROJ", connection);
            DataTable dt = new DataTable();
            List<Employee> listEmployee = new List<Employee>();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for(int i =0; i < dt.Rows.Count; i++)
                {
                    Employee Emp = new Employee();
                    Emp.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    Emp.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    Emp.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    Emp.IsActive= Convert.ToInt32(dt.Rows[i]["IsActive"]);


                    listEmployee.Add(Emp);




                }


                if (listEmployee.Count > 0)
                {
                    Response.StatusCode = 200;
                    Response.StatusMassage = "Data is Found";
                    Response.ListEmployee = listEmployee;
                }
                else
                {
                    Response.StatusCode = 100;
                    Response.StatusMassage = "No data is Found";
                    Response.ListEmployee = null;
                }
            }





            return Response;

        }
        public Response GetEmployeeById(SqlConnection connection, int id) 
        {
            Response Response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from DEMOPROJ where ID = '"+id+"' AND IsActive = 1 ", connection);
            DataTable dt = new DataTable();
            Employee Employees = new Employee();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                Employee Emp = new Employee();
                Emp.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                Emp.Name = Convert.ToString(dt.Rows[0]["Name"]);
                Emp.Email = Convert.ToString(dt.Rows[0]["Email"]);
                Emp.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                Response.StatusCode = 200;
                Response.StatusMassage = "Data is Found";
                Response.Employee = Emp;
            }

            else
            {
                Response.StatusCode = 100;
                Response.StatusMassage = "No data is Found";
                Response.Employee = null;
            }
          





            return Response;

        }
        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response Response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO DEMOPROJ(Name, Email, IsActive,CreationOn) VALUES('"+employee.Name+ "' , '" + employee.Email + "' ,'" + employee.IsActive + "' , GETDATE() )" , connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMassage = "Employee Added";
              
            }

            else
            {
                Response.StatusCode = 100;
                Response.StatusMassage = "No data inserted";
               
            }






            return Response;

        }

        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response Response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE DEMOPROJ SET Name = '" + employee.Name + " ' ,Email= '"  + employee.Email + "' where ID = '" + employee.ID + "'  ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMassage = "Employee Update";

            }

            else
            {
                Response.StatusCode = 100;
                Response.StatusMassage = "No data Updated";

            }






            return Response;

        }


        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand(" DELETE FROM DEMOPROJ WHERE ID = '" + id + "' ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >0 )
            {
                response.StatusCode = 200;
                response.StatusMassage = "Employee deleted";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMassage = "Employee is not deleted";
            }





            return response;
        }
    }

}
