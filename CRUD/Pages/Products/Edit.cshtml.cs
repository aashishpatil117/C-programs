using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace New_folder__6_.Pages.Products
{
     public class Edit : PageModel
    { 
    
       [BindProperty]
    [Required(ErrorMessage = "Product Name is required.")]
    public string Pname { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Product Id is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Product Id must be a positive number.")]
    public int Id { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public decimal price { get; set; }       
    private readonly IConfiguration _configuration;
        public Edit(IConfiguration configuration){
            _configuration=configuration;
        }
        public void OnGet(int Id)
        {
             Console.Write("here onget");
             string constring=_configuration.GetValue<string>("ConnectionStrings:constring");
             
             using(SqlConnection con=new SqlConnection(constring)){
                con.Open();
                string query = "Select * from products where Id=@Id";
                using(SqlCommand cmd=new SqlCommand(query,con)){
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using(SqlDataReader r=cmd.ExecuteReader()){
                        if(r.Read()){
                            Id=r.GetInt32(0);
                            price = r.GetInt32(2);
                            Pname=r.GetString(1);
                        }
                        else{
                            Response.Redirect("/Products/Create");
                        }
                    }   
                 }
             }
        }
        public IActionResult OnPost(){
            Console.Write("on post");
            string constring=_configuration.GetValue<string>("ConnectionStrings:constring");
             
             using(SqlConnection con=new SqlConnection(constring)){
                con.Open();
                string query = "UPDATE products SET Pname=@Pname,price=@price Where Id=@Id;";
                using(SqlCommand cmd=new SqlCommand(query,con)){
                    cmd.Parameters.AddWithValue("@Pname", Pname);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@Id",Id);
                    cmd.ExecuteNonQuery();
                    }   
                 }
                 return RedirectToPage("/Products/index");
             }

        }
    }

