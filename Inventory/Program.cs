using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=STORE_INVENTORY;Integrated Security=True");
            //OPEN
            connection.Open();
            //Ciclo de operaciones
            bool continuar = true;

            while (continuar == true)
            {

                Console.WriteLine("Bienvenido al sistema de Inventario...");
                Console.WriteLine("Que desea hacer?");
                Console.WriteLine("Ver informacion de 1. COMPRAS, 2. EMPLEADOS, 3. CLIENTES, 4. CATEGORIA, 5. LOCALIDADES, 6. PRODUCTOS, 7. SUPLIDORES ");
                var answer = Console.ReadLine();
                int numberAnswer = int.Parse(answer);
                if (numberAnswer == 1)
                {

                    Console.WriteLine("COMPRAS");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM PURCHASE";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4));
                        }

                    }

                    reader.Close();

                }
                else if (numberAnswer == 2)
                {
                    Console.WriteLine("EMPLEADOS");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM EMPLOYEES";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                        }

                    }

                    reader.Close();

                }
                else if (numberAnswer == 3)
                {
                    Console.WriteLine("CLIENTES");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM CUSTOMER";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                        }

                    }

                    reader.Close();
                }
                else if (numberAnswer == 4)
                {
                    Console.WriteLine("CATEGORIA");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM CATEGORY";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }

                    }

                    reader.Close();
                }
                else if (numberAnswer == 5)
                {
                    Console.WriteLine("LOCALIDADES");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM LOCATION_TABLE";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }

                    }

                    reader.Close();
                }
                else if (numberAnswer == 6)
                {
                    Console.WriteLine("PRODUCTOS");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM PRODUCT";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetInt32(5), reader.GetInt32(6));
                        }

                    }

                    reader.Close();

                }
                else if (numberAnswer == 7)
                {
                    Console.WriteLine("SUPLIDORES");
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM SUPPLIER";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(4));
                        }

                    }

                    reader.Close();
                }
                else {
                    Console.WriteLine("Mmm al parecer tu seleccion no se encuentra en el menu");
                }

                Console.WriteLine("Desea continuar? (Y/n) ");
                var aswer = Console.ReadLine();

                if (aswer == "Y")
                {
                    continuar = true;
                }
                else if (aswer == "n")
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("Letra equivocada");
                    continuar = false;
                }
            }
            connection.Close();
        }
    }
}
