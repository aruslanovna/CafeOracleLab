using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CafeWithOracle.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CafeWithOracle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string mess)
        {
            
                ViewBag.Error = mess ;
            
            
            return View();
        }
        public IActionResult OrderList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from Order_2_19";
            List<Order> o = new List<Order>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order i = new Order();
                i.Order_id = Int32.Parse(reader.GetString(0));
                i.Quantity = Int32.Parse(reader.GetString(1));
                i.Meal_id = Int32.Parse(reader.GetString(2));
                i.order_date = reader.GetString(1);
                o.Add(i);
            }

            return View(o);
        }
        public IActionResult CafeList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from Cafe_2_19";
            List<Order> o = new List<Order>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order i = new Order();
                i.Order_id = Int32.Parse(reader.GetString(0));
                i.Quantity = Int32.Parse(reader.GetString(1));
                i.Meal_id = Int32.Parse(reader.GetString(2));
                i.order_date = reader.GetString(1);
                o.Add(i);
            }

            return View(o);
        }
        public IActionResult CartList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from Cart_2_19";
            List<Order> o = new List<Order>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order i = new Order();
                i.Order_id = Int32.Parse(reader.GetString(0));
                i.Quantity = Int32.Parse(reader.GetString(1));
                i.Meal_id = Int32.Parse(reader.GetString(2));
                i.order_date = reader.GetString(1);
                o.Add(i);
            }

            return View(o);
        }

        public IActionResult WaiterList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from Waiter_2_19";
            List<Waiter> o = new List<Waiter>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Waiter i = new Waiter();
                i.Waiter_id = Int32.Parse(reader.GetString(0));
                i.Name = reader.GetString(1);
                i.Address = reader.GetString(2);
                i.Age = Int32.Parse(reader.GetString(3));
                i.Experience = Int32.Parse(reader.GetString(4));
              
                o.Add(i);
            }

            return View(o);
        }
        public IActionResult MealList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from Meal_2_19";
            List<Meal> o = new List<Meal>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Meal m = new Meal();
                m.Meal_id = Int32.Parse(reader.GetString(0));
                m.Name = reader.GetString(1);
                m.Type = reader.GetString(2);
                m.Best_before = reader.GetString(3);
                m.Description = (string.IsNullOrEmpty(reader.GetString(4))) ? " " : reader.GetString(4);
                m.Price = Int32.Parse(reader.GetString(6));

                o.Add(m);
            }

            return View(o);
        }
        public IActionResult BillList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from get_bill";
            List<Bill> o = new List<Bill>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bill m = new Bill();
                m.Order_id = Int32.Parse(reader.GetString(0));
                m.Quantity = Int32.Parse(reader.GetString(1));
                m.Price = Int32.Parse(reader.GetString(2));
                m.Full_price = Int32.Parse(reader.GetString(3));
               

                o.Add(m);
            }

            return View(o);
        }

        public IActionResult BillDateList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from get_bill_date";
            List<Bill_date> o = new List<Bill_date>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bill_date m = new Bill_date();
                m.Order_id = Int32.Parse(reader.GetString(0));
                m.Quantity = Int32.Parse(reader.GetString(1));
                m.Order_date= reader.GetString(2);
                m.Price = Int32.Parse(reader.GetString(3));
                m.Full_price = Int32.Parse(reader.GetString(4));
                                o.Add(m);
            }

            return View(o);
        }

        public IActionResult FullPriceCartList()
        {
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "select * from full_price_in_cart";
            List<Full_price_in_cart> o = new List<Full_price_in_cart>();
            //execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Full_price_in_cart m = new Full_price_in_cart();
                m.Cart_Name = reader.GetString(0);
                
                m.Price = Int32.Parse(reader.GetString(1));
                m.Name = reader.GetString(2);
                o.Add(m);
            }

            return View(o);
        }

        public  IActionResult ChangePrice()
        {
            // used to return the country name
            string CountryName = "";


            // Create command and parameter objects
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "call change_price()";
            //  cmd.Parameters.Add(":1", OracleDbType.Varchar2, CountryID, ParameterDirection.Input);

            // get a data reader
            OracleDataReader rdr = cmd.ExecuteReader();

            // get the country name from the data reader
            if (rdr.Read())
            {
                CountryName = rdr.GetString(0);
            }

            return RedirectToAction("Index");

        }

        public  IActionResult ChangeQuantity()
        {
            // used to return the country name
            string CountryName = "";


            // Create command and parameter objects
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();
            cmd.CommandText = "call change_quantity()";
           
            // get a data reader
            OracleDataReader rdr = cmd.ExecuteReader();

            // get the country name from the data reader
            if (rdr.Read())
            {
                CountryName = rdr.GetString(0);
            }

            // clean up objects
            rdr.Close();
            cmd.Dispose();
            return RedirectToAction("Index");

        }
        public  IActionResult ChangeMeal(string Name, string discount)
        {
            // used to return the country name
            string CountryName = "";


            // Create command and parameter objects
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();

            cmd.CommandText = $"call UpdateMeal(:1, :2)";
            cmd.Parameters.Add(":1", OracleDbType.Varchar2, Name, ParameterDirection.Input);
            cmd.Parameters.Add(":2", OracleDbType.Int32, Int32.Parse(discount), ParameterDirection.Input);
            // get a data reader
            OracleDataReader rdr = cmd.ExecuteReader();

            // get the country name from the data reader
            if (rdr.Read())
            {
                CountryName = rdr.GetString(0);
            }

            // clean up objects
            rdr.Close();
            cmd.Dispose();
            return RedirectToAction("Index");
        }
        public IActionResult UpdatePrice(string Name, int price)
        {
            // used to return the country name
            string CountryName = "";


            // Create command and parameter objects
            OracleCommand cmd = DatabaseConnection.Connect().CreateCommand();

            cmd.CommandText = $"call UpdatePrice(:1, :2)";
            cmd.Parameters.Add(":1", OracleDbType.Varchar2, Name, ParameterDirection.Input);
            cmd.Parameters.Add(":2", OracleDbType.Int32, price, ParameterDirection.Input);
            // get a data reader
            try
            {
                OracleDataReader rdr = cmd.ExecuteReader();

                // get the country name from the data reader
                if (rdr.Read())
                {
                    CountryName = rdr.GetString(0);
                }
                rdr.Close();
            }
            catch (OracleException ex)
            {
                if (ex.Message.Contains("Price less than zero"))
                {
                    TempData["shortMessage"] = "Price less than zero";
                    return RedirectToAction("Index", new { mess = "New price is higher then previous" });
                }
                else if(ex.Message.Contains("NEwr price is higher then previous"))
                {
                    TempData["shortMessage"] = "New price is higher then previous";
                    return RedirectToAction("Index", new { mess = "New price is higher then previous" });
                    // handle
                }
                else
                {
                    return RedirectToAction("Index");

                }
            }

            // clean up objects

            cmd.Dispose();
            return RedirectToAction("MealList");
        }
    }
}




