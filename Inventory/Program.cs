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
                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
                    {

                        Console.WriteLine("COMPRAS");
                        SqlCommand cmd = connection.CreateCommand();

                        cmd.CommandText = "SELECT * FROM PURCHASE_VIEW;";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4));
                            }

                        }

                        reader.Close();

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }


                }
                else if (numberAnswer == 2)
                {
                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
                    {

                        Console.WriteLine("EMPLEADOS");
                        SqlCommand cmd = connection.CreateCommand();

                        cmd.CommandText = "SELECT * FROM EMPLOYEE_VIEW";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            }

                        }

                        reader.Close();

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }


                }

                else if (numberAnswer == 3)
                {
                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
                    {

                        Console.WriteLine("CLIENTES");
                        SqlCommand cmd = connection.CreateCommand();

                        cmd.CommandText = "SELECT * FROM CUSTOMER_VIEW";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            }

                        }

                        reader.Close();

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }
                }
                else if (numberAnswer == 4)
                {
                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
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

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }
                }
                else if (numberAnswer == 5)
                {
                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
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

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }
                }
                else if (numberAnswer == 6)
                {
                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
                    {

                        Console.WriteLine("PRODUCTOS");
                        SqlCommand cmd = connection.CreateCommand();

                        cmd.CommandText = "SELECT * FROM PRODUCT_VIEW";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows){
                            while(reader.Read()){
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
                            }
                        }

                        reader.Close();


                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }


                }
                else if (numberAnswer == 7)
                {

                    bool continuarSecondMenu = true;
                    while (continuarSecondMenu)
                    {

                        Console.WriteLine("SUPLIDORES");
                        SqlCommand cmd = connection.CreateCommand();

                        cmd.CommandText = "SELECT * FROM SUPPLIER_VIEW";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                            }

                        }

                        reader.Close();

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        var crudAnswer = Console.ReadLine();

                        //Entrada de datos



                        Console.WriteLine("Desea continuar? (Y/n) ");
                        var secondMenuAnswer = Console.ReadLine();

                        if (secondMenuAnswer == "Y")
                        {
                            continuarSecondMenu = true;
                        }
                        else if (secondMenuAnswer == "n")
                        {
                            continuarSecondMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("Letra equivocada");
                            continuarSecondMenu = false;
                        }
                    }


                }

                else
                {
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
