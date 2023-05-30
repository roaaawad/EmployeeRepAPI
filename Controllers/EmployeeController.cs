using DemoCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DemoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetALLEmployees")]

        public Response GetALLEmployees()
        {
            Response Response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DemoCRUDConnection").ToString());

            Dal dal = new Dal();
            Response = dal.GetALLEmployees(connection);
            return Response;

        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]

        public Response GetEmployeeById(int id)
        {
            Response Response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DemoCRUDConnection").ToString());

            Dal dal = new Dal();
            Response = dal.GetEmployeeById(connection, id);
            return Response;

        }

        [HttpPost]
        [Route("AddEmployee")]

        public Response AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DemoCRUDConnection").ToString());
            Response response = new Response();
            Dal dal = new Dal();
            response = dal.AddEmployee(connection,employee);




            return response;


        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DemoCRUDConnection").ToString());
            Response response = new Response();
            Dal dal = new Dal();
            response = dal.UpdateEmployee(connection, employee);




            return response;


        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]

        public Response DeleteEmployee(int id )

{
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DemoCRUDConnection").ToString());
            Response response = new Response();
            Dal dal = new Dal();
            response = dal.DeleteEmployee(connection, id);



            return response;
        }



    }
}
