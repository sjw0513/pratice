using project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace project.Controllers
{
    
    public class ChickenController : Controller
    {        
        
        public IActionResult Index(string s1) {
            string gu = s1;
            string connStr = "Server=3.37.147.49;Database=project;Uid=root;Pwd=admin0513;";            
            List<Data> list = new List<Data>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM chichken WHERE address LIKE '%" + gu + "%'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Data()
                    {
                        name = rdr["name"].ToString(),
                        address = rdr["address"].ToString(),
                        X = Convert.ToDouble(rdr["X"]),
                        Y = Convert.ToDouble(rdr["Y"]),
                        number = rdr["number"].ToString()
                    });
                }
                rdr.Close();
            } 
            return View(list);
        }
    }
}