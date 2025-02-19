using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace New_folder__6_.Pages.Products
{
    public class index : PageModel
    {
       

        public List<ProductInfo> ProdList{get; set;}=[];
        private readonly IConfiguration _configuration;
        public index(IConfiguration configuration){
            _configuration=configuration;
        }
        public void OnGet()
        {
            string constring=_configuration.GetValue<string>("ConnectionStrings:constring");
            using(SqlConnection con=new SqlConnection(constring)){
                con.Open();
                string query="SELECT * from products";
                using(SqlCommand c=new SqlCommand(query,con)){
                    using(SqlDataReader r=c.ExecuteReader()){
                        while(r.Read()){
                            ProductInfo prod=new ProductInfo();
                            prod.Id=r.GetInt32(0);
                            prod.Pname=r.GetString(1);
                            prod.price=r.GetInt32(2);

                            ProdList.Add(prod);
                        }
                    }
                }
            }
        }
    }
    public class ProductInfo{
        public string Pname { get; set;}
        public int Id{get; set;}
        public int price{get; set;}
    }
}