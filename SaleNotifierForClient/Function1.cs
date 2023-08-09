using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SaleNotifierForClient
{
    public static class Function1
    {
        [Function("Function1")]
        public static string Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext, string PName)
        {
            
            
           //string PName = req.ToString();

            string strResult = "No Result";

            //Define Connection String to Connect to SQL Database
            string strConn = "Server=citizen.manukautech.info,6305;Database=CCQ3_Team1_Project;UID=CCQ3_Team1;PWD=fBit$66285;encrypt=true;trustservercertificate=true;";
            
            try
            {
                //Create SQL Connection object
                using (SqlConnection SQLConn = new SqlConnection(strConn))
                {
                    SQLConn.Open(); // Open the Connection (Test to makesure it works)
                    var sqlQuery = "Select * from Product where ProductName Like '" + PName + "%'"; // Define a query for data retrival
                    var sqlCommand = new SqlCommand(sqlQuery, SQLConn); // Use Command for executing the query

                    //check the connection is alreay open if so close before opening it again.
                    if (sqlCommand.Connection.State == System.Data.ConnectionState.Open)
                    {
                        sqlCommand.Connection.Close();
                    }
                    sqlCommand.Connection.Open();  //open the  connection to execute the command
                    SqlDataReader SQLReader = sqlCommand.ExecuteReader(); // retrive the results from database into a reader
                    var dtProducts = new DataTable();  //create a data table to populate the products
                    dtProducts.Load(SQLReader); //load the data into data table
                    foreach (DataRow row in dtProducts.Rows)
                    {
                        strResult = "The product you selected is " + row["ProductName"] + " and total amount is " + row["UnitPrice"].ToString() + " On Sale = " + row["OnSale"];
                        //if (row["OnSale"].ToString().Equals("false"))
                        //    row["OnSale"].ToString() = "Not";
                        //else
                        //    row["OnSale"].ToString() = "Yes";
                    }
                    //strResult = JsonConvert.SerializeObject(dtProducts);


                }


            }

            catch (Exception e)
            {
                strResult = e.Message; //result error message to the caller 
            }
            //var logger = executionContext.GetLogger("Function1");
            //logger.LogInformation("C# HTTP trigger function processed a request.");

            //var response = req.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            //response.WriteString("Welcome to Azure Functions!");

            return strResult;
        }
    }
}
