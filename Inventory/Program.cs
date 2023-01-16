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
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5));
                            }

                        }

                        reader.Close();

                        //OTRAS FUNCIONES CRUD C-U-D

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();


                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa id de producto");
                            var ID_PRODUCT = Console.ReadLine();

                            Console.WriteLine("Ingresa id de empleado");
                            var ID_EMPLOYEE = Console.ReadLine();

                            Console.WriteLine("Ingresa id de cliente");
                            var ID_CUSTOMER = Console.ReadLine();

                            Console.WriteLine("Ingresa la fecha actual en el formato solamente AAAA-MM-DD  ");
                            var PURCHASE_DATE = Console.ReadLine();

                            Console.WriteLine("Ingresa la cantidad de productos a comprar ");
                            var QTY_PRODUCT = Console.ReadLine();



                            if (ID_PRODUCT != null && ID_EMPLOYEE != null)
                            {
                                //Conversor
                                var PRODUCT = int.Parse(ID_PRODUCT);
                                var EMPLOYEE = int.Parse(ID_EMPLOYEE);
                                var CUSTOMER = int.Parse(ID_CUSTOMER);
                                var DATE = DateTime.Parse(PURCHASE_DATE);
                                var CANT_PRODUCT = int.Parse(QTY_PRODUCT);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR_PURCHASE";
                                cmd.Parameters.AddWithValue("@ID_PRODUCT", PRODUCT);
                                cmd.Parameters.AddWithValue("@ID_EMPLOYEE", EMPLOYEE);
                                cmd.Parameters.AddWithValue("@ID_CUSTOMER", CUSTOMER);
                                cmd.Parameters.AddWithValue("@PURCHASE_DATE", DATE);
                                cmd.Parameters.AddWithValue("@QTY_PRODUCT", CANT_PRODUCT);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa tus nuevos datos");
                            //Entrada de usuario
                            //Entrada de usuario
                            Console.WriteLine("Ingresa id de producto");
                            var ID_PRODUCT = Console.ReadLine();

                            Console.WriteLine("Ingresa id de empleado");
                            var ID_EMPLOYEE = Console.ReadLine();

                            Console.WriteLine("Ingresa id de cliente");
                            var ID_CUSTOMER = Console.ReadLine();

                            Console.WriteLine("Ingresa la fecha de compra en el siguiente formato solamente AAAA-MM-DD  ");
                            var PURCHASE_DATE = Console.ReadLine();


                            if (ID_PRODUCT != null && ID_EMPLOYEE != null)
                            {
                                //Conversor
                                var PRODUCT = int.Parse(ID_PRODUCT);
                                var EMPLOYEE = int.Parse(ID_EMPLOYEE);
                                var CUSTOMER = int.Parse(ID_CUSTOMER);
                                var DATE = DateTime.Parse(PURCHASE_DATE);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR_PURCHASE";
                                cmd.Parameters.AddWithValue("@ID_PRODUCT", PRODUCT);
                                cmd.Parameters.AddWithValue("@ID_EMPLOYEE", EMPLOYEE);
                                cmd.Parameters.AddWithValue("@ID_CUSTOMER ", CUSTOMER);
                                cmd.Parameters.AddWithValue("@PURCHASE_DATE", DATE);
                                cmd.Parameters.AddWithValue("@ID_PURCHASE", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR_PURCHASE";
                            cmd.Parameters.AddWithValue("@ID_PURCHASE", Id);
                            Console.WriteLine("Datos eliminados");

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }




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

                        //OTRAS FUNCIONES CRUD C-U-D

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();
                        

                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre");
                            var FIRST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa apellido");
                            var LAST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa email");
                            var EMAIL = Console.ReadLine();

                            Console.WriteLine("Ingresa numero");
                            var PHONE_NUMBER = Console.ReadLine();

                            Console.WriteLine("Ingresa codigo de ubicacion");
                            var ID_LOCATION = Console.ReadLine();



                            if (FIRST_NAME != null && PHONE_NUMBER != null)
                            {
                                var LOCATION = int.Parse(ID_LOCATION);

                                //modo medio automatico
                               
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR";
                                cmd.Parameters.AddWithValue("@FIRST_NAME", FIRST_NAME);
                                cmd.Parameters.AddWithValue("@LAST_NAME", LAST_NAME);
                                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", LOCATION);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa tus nuevos datos");
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre");
                            var FIRST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa apellido");
                            var LAST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa email");
                            var EMAIL = Console.ReadLine();

                            Console.WriteLine("Ingresa numero");
                            var PHONE_NUMBER = Console.ReadLine();

                            Console.WriteLine("Ingresa codigo de ubicacion");
                            var ID_LOCATION = Console.ReadLine();

                            if (FIRST_NAME != null && PHONE_NUMBER != null)
                            {
                                var LOCATION = int.Parse(ID_LOCATION);
                          
                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR";
                                cmd.Parameters.AddWithValue("@FIRST_NAME", FIRST_NAME);
                                cmd.Parameters.AddWithValue("@LAST_NAME", LAST_NAME);
                                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", LOCATION);
                                cmd.Parameters.AddWithValue("@ID_EMPLOYEE", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR";
                            cmd.Parameters.AddWithValue("@ID_EMPLOYEE", Id);

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }




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

                        //OTRAS FUNCIONES CRUD C-U-D

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();


                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre");
                            var FIRST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa apellido");
                            var LAST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa email");
                            var EMAIL = Console.ReadLine();

                            Console.WriteLine("Ingresa numero");
                            var PHONE_NUMBER = Console.ReadLine();

                            Console.WriteLine("Ingresa codigo de ubicacion");
                            var ID_LOCATION = Console.ReadLine();



                            if (FIRST_NAME != null && PHONE_NUMBER != null)
                            {
                                var LOCATION = int.Parse(ID_LOCATION);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR_CUSTOMER";
                                cmd.Parameters.AddWithValue("@FIRST_NAME", FIRST_NAME);
                                cmd.Parameters.AddWithValue("@LAST_NAME", LAST_NAME);
                                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", LOCATION);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa tus nuevos datos");
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre");
                            var FIRST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa apellido");
                            var LAST_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa email");
                            var EMAIL = Console.ReadLine();

                            Console.WriteLine("Ingresa numero");
                            var PHONE_NUMBER = Console.ReadLine();

                            Console.WriteLine("Ingresa codigo de ubicacion");
                            var ID_LOCATION = Console.ReadLine();

                            if (FIRST_NAME != null && PHONE_NUMBER != null)
                            {
                                var LOCATION = int.Parse(ID_LOCATION);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR_CUSTOMER";
                                cmd.Parameters.AddWithValue("@FIRST_NAME", FIRST_NAME);
                                cmd.Parameters.AddWithValue("@LAST_NAME", LAST_NAME);
                                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", LOCATION);
                                cmd.Parameters.AddWithValue("@ID_CUSTOMER", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR_CUSTOMER";
                            cmd.Parameters.AddWithValue("@ID_CUSTOMER", Id);
                            Console.WriteLine("Datos eliminados");

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }



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
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();


                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nueva categoria");
                            var NAME_CATEGORY = Console.ReadLine();

                            Console.WriteLine("Ingresa descripcion");
                            var DESCRIPTION_CATEGORY = Console.ReadLine();


                            if (NAME_CATEGORY != null)
                            {
                         
                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR_CATEGORY";
                                cmd.Parameters.AddWithValue("@NAME_CATEGORY", NAME_CATEGORY);
                                cmd.Parameters.AddWithValue("@DESCRIPTION_CATEGORY", DESCRIPTION_CATEGORY);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar usuario");
                            Console.WriteLine("Por favor, ingresa ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa tus nuevos datos");
                            //Entrada de usuario
                            Console.WriteLine("Ingresa categoria");
                            var NAME_CATEGORY = Console.ReadLine();

                            Console.WriteLine("Ingresa descripcion");
                            var DESCRIPTION_CATEGORY = Console.ReadLine();


                            if (NAME_CATEGORY != null)
                            {

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR_CATEGORY";
                                cmd.Parameters.AddWithValue("@NAME_CATEGORY", NAME_CATEGORY);
                                cmd.Parameters.AddWithValue("@DESCRIPTION_CATEGORY", DESCRIPTION_CATEGORY);
                                cmd.Parameters.AddWithValue("@ID_CATEGORY", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar categoria");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR_CATEGORY";
                            cmd.Parameters.AddWithValue("@ID_CATEGORY", Id);
                            Console.WriteLine("Datos eliminados");

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }




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
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();


                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nueva ubicacion");
                            var CITY = Console.ReadLine();

                            Console.WriteLine("Ingresa la calle");
                            var STREET = Console.ReadLine();


                            if (CITY != null && STREET != null)
                            {

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR_LOCATION";
                                cmd.Parameters.AddWithValue("@CITY", CITY);
                                cmd.Parameters.AddWithValue("@STREET", STREET);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar ubicacion");
                            Console.WriteLine("Por favor, ingresa ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa nuevos datos");
                            //Entrada de usuario
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nueva ubicacion");
                            var CITY = Console.ReadLine();

                            Console.WriteLine("Ingresa la calle");
                            var STREET = Console.ReadLine();


                            if (CITY != null && STREET != null)
                            {

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR_LOCATION";
                                cmd.Parameters.AddWithValue("@CITY", CITY);
                                cmd.Parameters.AddWithValue("@STREET", STREET);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar categoria");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR_LOCATION";
                            cmd.Parameters.AddWithValue("@ID_LOCATION", Id);
                            Console.WriteLine("Datos eliminados");

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }




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


                        //OTRAS FUNCIONES CRUD C-U-D

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();


                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre de producto");
                            var NAME_PRODUCT = Console.ReadLine();

                            Console.WriteLine("Ingresa descripcion");
                            var DESCRIPTION_PRODUCT = Console.ReadLine();

                            Console.WriteLine("Ingresa cantidad actual");
                            var QTY_STOCK = Console.ReadLine();

                            Console.WriteLine("Ingresa precio");
                            var PRICE = Console.ReadLine();

                            Console.WriteLine("Ingresa el id de categoria perteneciente");
                            var ID_CATEGORY = Console.ReadLine();

                            Console.WriteLine("Ingresa el id de suplidor perteneciente");
                            var ID_SUPPLIER = Console.ReadLine();



                            if (NAME_PRODUCT != null && ID_CATEGORY != null)
                            {
                                //Conversor
                                var STOCK = int.Parse(QTY_STOCK);
                                var PRECIO = int.Parse(PRICE);
                                var CATEGORY = int.Parse(ID_CATEGORY);
                                var SUPPLIER = int.Parse(ID_SUPPLIER);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR_PRODUCT";
                                cmd.Parameters.AddWithValue("@NAME_PRODUCT", NAME_PRODUCT);
                                cmd.Parameters.AddWithValue("@DESCRIPTION_PRODUCT", DESCRIPTION_PRODUCT);
                                cmd.Parameters.AddWithValue("@QTY_STOCK", STOCK);
                                cmd.Parameters.AddWithValue("@PRICE", PRECIO);
                                cmd.Parameters.AddWithValue("@ID_CATEGORY", CATEGORY);
                                cmd.Parameters.AddWithValue("@ID_SUPPLIER", SUPPLIER);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa tus nuevos datos");
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre de producto");
                            var NAME_PRODUCT = Console.ReadLine();

                            Console.WriteLine("Ingresa descripcion");
                            var DESCRIPTION_PRODUCT = Console.ReadLine();

                            Console.WriteLine("Ingresa cantidad actual");
                            var QTY_STOCK = Console.ReadLine();

                            Console.WriteLine("Ingresa precio");
                            var PRICE = Console.ReadLine();

                            Console.WriteLine("Ingresa el id de categoria perteneciente");
                            var ID_CATEGORY = Console.ReadLine();

                            Console.WriteLine("Ingresa el id de suplidor perteneciente");
                            var ID_SUPPLIER = Console.ReadLine();



                            if (NAME_PRODUCT != null && ID_CATEGORY != null)
                            {
                                //Conversor
                                var STOCK = int.Parse(QTY_STOCK);
                                var PRECIO = int.Parse(PRICE);
                                var CATEGORY = int.Parse(ID_CATEGORY);
                                var SUPPLIER = int.Parse(ID_SUPPLIER);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR_PRODUCT";
                                cmd.Parameters.AddWithValue("@NAME_PRODUCT", NAME_PRODUCT);
                                cmd.Parameters.AddWithValue("@DESCRIPTION_PRODUCT", DESCRIPTION_PRODUCT);
                                cmd.Parameters.AddWithValue("@QTY_STOCK", STOCK);
                                cmd.Parameters.AddWithValue("@PRICE", PRECIO);
                                cmd.Parameters.AddWithValue("@ID_CATEGORY", CATEGORY);
                                cmd.Parameters.AddWithValue("@ID_SUPPLIER", SUPPLIER);
                                cmd.Parameters.AddWithValue("@ID_PRODUCT", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR_PRODUCT";
                            cmd.Parameters.AddWithValue("@ID_PRODUCT", Id);
                            Console.WriteLine("Datos eliminados");

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }




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

                        //OTRAS FUNCIONES CRUD C-U-D

                        //Otro menu
                        Console.WriteLine("Que desas hacer? 1. Crear nuevo registro (C), 2. Actualizar nuevo registro (U) 3. Eliminar registro (D)");
                        Console.WriteLine("Responder con las letras");
                        var respuesta = Console.ReadLine();


                        //Entrada CRUD
                        if (respuesta == "C" || respuesta == "c")
                        {
                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre de suplidor");
                            var COMPANY_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa codigo de ubicacion");
                            var ID_LOCATION = Console.ReadLine();

                            Console.WriteLine("Ingresa numero");
                            var PHONE_NUMBER = Console.ReadLine();





                            if (COMPANY_NAME != null && PHONE_NUMBER != null)
                            {
                                var LOCATION = int.Parse(ID_LOCATION);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "CREAR_SUPPLIER";
                                cmd.Parameters.AddWithValue("@COMPANY_NAME", COMPANY_NAME);
                                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", LOCATION);
                                Console.WriteLine("Datos ingresados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();
                            }


                        }
                        else if (respuesta == "U" || respuesta == "u")
                        {
                            Console.WriteLine("Actualizar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();

                            Console.WriteLine("Ahora ingresa tus nuevos datos");

                            //Entrada de usuario
                            Console.WriteLine("Ingresa nombre de suplidor");
                            var COMPANY_NAME = Console.ReadLine();

                            Console.WriteLine("Ingresa codigo de ubicacion");
                            var ID_LOCATION = Console.ReadLine();

                            Console.WriteLine("Ingresa numero");
                            var PHONE_NUMBER = Console.ReadLine();

                            if (COMPANY_NAME != null && PHONE_NUMBER != null)
                            {
                                var LOCATION = int.Parse(ID_LOCATION);

                                //modo medio automatico

                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.CommandText = "EDITAR_SUPPLIER";
                                cmd.Parameters.AddWithValue("@COMPANY_NAME", COMPANY_NAME);
                                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                                cmd.Parameters.AddWithValue("@ID_LOCATION", LOCATION);
                                cmd.Parameters.AddWithValue("@ID_SUPPLIER", Id);
                                Console.WriteLine("Datos actualizados");

                                //Muy importante 
                                cmd.ExecuteNonQuery();

                            }
                        }
                        else if (respuesta == "D" || respuesta == "d")
                        {
                            Console.WriteLine("Eliminar usuario");
                            Console.WriteLine("Por favor, ingresa tu ID");
                            var Id = Console.ReadLine();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "ELIMINAR_SUPPLIER";
                            cmd.Parameters.AddWithValue("@ID_SUPPLIER", Id);
                            Console.WriteLine("Datos eliminados");

                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            Console.WriteLine("Mmm parece su respuesta no esta dentro de las opciones");
                        }




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
