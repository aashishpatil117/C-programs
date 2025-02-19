using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace New_folder__6_.Pages.Products
{
    public class Delete : PageModel
    {
        private readonly IConfiguration _configuration;
        public Delete(IConfiguration configuration){
            _configuration=configuration;
        }
        public void OnGet()
        {
        }
        public void OnPost(int Id){
            deleteproduct(Id);
            Response.Redirect("/Products/index");
        }
        private void deleteproduct(int Id){
            string constring=_configuration.GetValue<string>("ConnectionStrings:constring");
            //Console.WriteLine(constring);
            using(SqlConnection con=new SqlConnection(constring)){
                con.Open();
                string query="Delete from products where ID=@Id";
                using(SqlCommand cmd=new SqlCommand(query,con)){
                   
                    cmd.Parameters.AddWithValue("@Id", Id);
                   
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}