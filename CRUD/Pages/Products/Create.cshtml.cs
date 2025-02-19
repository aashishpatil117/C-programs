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
    public class Create : PageModel
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
    public Create(IConfiguration configuration){
        _configuration=configuration;
    }
       
        
        public void OnGet(){

        }
        public IActionResult OnPost(){
             string constring=_configuration.GetValue<string>("ConnectionStrings:constring");
             using(SqlConnection con=new SqlConnection(constring)){
                con.Open();
                Console.WriteLine("constring"+constring);
                Console.WriteLine($"Inserting: Id={Id}, Pname={Pname}, Price={price}");
                string query = "INSERT INTO products (Id,Pname, price) VALUES (@Id,@Pname, @price)";
                using(SqlCommand cmd=new SqlCommand(query,con)){
                    cmd.Parameters.AddWithValue("@Pname", Pname);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToPage("/Products/index"); 
            }
        
        }
    }
}