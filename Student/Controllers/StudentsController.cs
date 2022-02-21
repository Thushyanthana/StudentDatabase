using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Student.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Student.Controllers
{
    public class StudentsController : ApiController
    {
        //Get Method
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            //select query for sql databse
            //if you want to do another table in same database you want to change only the sql command
            string query = @"select StudentID ,StudentName  from dbo.Students";

            //Before connection in web.config
            //connection
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))

           //The output from the select query will be available in the data adapter
           //Which will fill the data to the datatable
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        //Post Method
 public string Post(Students st)
        {
            try
            {
                DataTable table = new DataTable();
                //select query for sql databse
                //if you want to do another table in same database you want to change only the sql command
                string query = @"insert into  dbo.Students values('" + st.StudentName+@"')";

                //Before connection in web.config
                //connection
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                //The output from the select query will be available in the data adapter
                //Which will fill the data to the datatable
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch(Exception)
            {
                return "Failed to add";
            }

        }


        //Put Method
        public string Put(Students st)
        {
            try
            {
                DataTable table = new DataTable();
                //select query for sql databse
                //if you want to do another table in same database you want to change only the sql command
                string query = @"update  dbo.Students  set StudentName= '" + st.StudentName + @"'
                                                            where StudentID=" + st.StudentID + @" ";

                //Before connection in web.config
                //connection
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                //The output from the select query will be available in the data adapter
                //Which will fill the data to the datatable
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed to update";
            }

        }


        //Delete method
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                //select query for sql databse
                //if you want to do another table in same database you want to change only the sql command
                string query = @"delete from  dbo.Students where StudentID="+id;


                //Before connection in web.config
                //connection
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                //The output from the select query will be available in the data adapter
                //Which will fill the data to the datatable
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Deleted to update";
            }

        }


    }
}
