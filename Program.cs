using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetSpike2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from [SalesLT].[Customer] where CustomerID=@id";

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@id";
                    parameter.Value = 1;
                    command.Parameters.Add(parameter);

                    var reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        Console.WriteLine("No data found");
                    }
                    else
                    {
                        Console.WriteLine("Data found");
                    }

                    var firstName = reader.GetString(3);
                    Console.WriteLine("First name: {0}", firstName);
                }
            }
        }
    }
}
