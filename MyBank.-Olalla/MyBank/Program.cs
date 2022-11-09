using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MyBank
{
    class Program
    {
        
        public static void menu()
        {
            //VARIABLES
            string userName;
            decimal initialBalance;
            decimal dinerosAdd;
            string motivoAdd;
            decimal dinerosNoAdd;
            string motivoNoAdd;
            //BankAccount cuenta1;

            var cuenta1 = new BankAccount("cuenta1", 300);
            Console.WriteLine($"Cuenta nº {cuenta1.Number} con titular {cuenta1.Owner} y con {cuenta1.Balance} dinero inicial.");
            List<BankAccount> cuentas = new List<BankAccount>();
            cuentas.Add(cuenta1);
           
            Console.WriteLine($"----------------------------------------------------------------------");
            Console.WriteLine($"¿Que quieres hacer?");
            Console.WriteLine($"1.Hacer ingreso en una cuenta");
            Console.WriteLine($"2.Sacar dinero de una cuenta");
            Console.WriteLine($"3.Crear una cuenta nueva");
            Console.WriteLine($"4.Mirar el historial de la cuenta");
            Console.WriteLine($"5.Nada duh");
            Console.WriteLine($"----------------------------------------------------------------------");

            decimal opciones = Convert.ToDecimal(Console.ReadLine());
            switch (opciones)
            {
                case 1:
                    //HACER UN DEPOSITO

                    Console.WriteLine($"¿Cuantos dineros quieres añadir? Introduce cantidad: ");
                    //Leer datos sobre el dinero que vamos a ingresar y guardarlos
                     dinerosAdd = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine($"Introduce el motivo del ingreso:");
                    //Leer datos sobre motivo del ingreso y guardarlos
                    motivoAdd = Console.ReadLine();
                    //cuentas.Add(cuenta1);
                    //Llamar al método de hacer deposito y ponerle las variables que hemos recogido
                    cuenta1.MakeDeposit(dinerosAdd, DateTime.Today, motivoAdd);
                    //Imprimir datos por pantalla
                    Console.WriteLine(cuenta1.GetAccountHistory());
                    Console.WriteLine($"----------------------------------------------------------------------");
                    Console.WriteLine($"¿Quieres hacer algo mas? (y/n)");
                    string continuar = Console.ReadLine();
                    if (continuar == "y")
                    {
                        menu();
                    }
                    else if (continuar == "n")
                    {
                        Console.WriteLine("adios");
                    }
                    break;

                case 2:
                    //SACAR DINEROS

                    Console.WriteLine($"¿Cuantos dineros quieres retirar de la cuenta? Introduce cantidad: ");
                    //Leer datos sobre el dinero que vamos a retirar y guardarlos
                     dinerosNoAdd = Convert.ToDecimal(Console.ReadLine());
                    //Leer datos sobre el motivo de la retirada de dinero y guardarlos
                    Console.WriteLine($"Introduce el motivo de la retirada:");
                     motivoNoAdd = Console.ReadLine();
                    cuentas.Add(cuenta1);
                    //Llamar al método de hacer la retirada y ponerle las variables que hemos recogido
                    cuenta1.MakeWithdrawal(dinerosNoAdd, DateTime.Now, motivoNoAdd);
                    //Imprimir datos por pantalla
                    Console.WriteLine(cuenta1.GetAccountHistory());
                    Console.WriteLine($"----------------------------------------------------------------------");
                    Console.WriteLine($"¿Quieres hacer algo mas? (y/n)");
                    string continuar2 = Console.ReadLine();
                    if (continuar2 == "y")
                    {
                        menu();
                    }
                    else if (continuar2 == "n")
                    {
                        Console.WriteLine("adios");
                    }
                    break;

                case 3:
                    //CREAR CUENTA CON DATOS METIDOS POR PANTALLA

                    Console.WriteLine($"Introduce titular de la cuenta:");
                    //Leer datos sobre nombre y guardarlos
                    userName = Console.ReadLine();
                    
                    Console.WriteLine($"Introduce balance inicial de la cuenta:");
                    //Leer datos sobre dinero inicial, convertirlos a decimal y guardarlos
                     initialBalance = Convert.ToDecimal(Console.ReadLine());
                   
                    //Crear cuenta con los datos recogidos
                    var cuenta2 = new BankAccount(userName, initialBalance);
                    cuentas.Add(cuenta2);
                    cuentas.ToArray();
                    Console.WriteLine($"Cuenta nº {cuenta2.Number} con titular {cuenta2.Owner} y con {cuenta2.Balance} dinero inicial.");
                    Console.WriteLine($"----------------------------------------------------------------------");
                    Console.WriteLine($"¿Quieres hacer algo mas? (y/n)");
                    string continuar3 = Console.ReadLine();
                    if (continuar3 == "y")
                    {
                        menu();
                    }
                    else if (continuar3 == "n")
                    {
                        Console.WriteLine("Adios");
                    }
                    break;

                case 4:
                    //Ver historial
                    Console.WriteLine($"Datos de la cuenta");
                    Console.WriteLine(cuenta1.GetAccountHistory());
                    Console.WriteLine($"----------------------------------------------------------------------");
                    Console.WriteLine($"¿Quieres hacer algo mas? (y/n)");
                    string continuar4 = Console.ReadLine();
                    if (continuar4 == "y")
                    {
                        menu();
                    }
                    else if (continuar4 == "n")
                    {
                        Console.WriteLine("Adios");
                    }
                    break;
       
                case 5:
                    //Salir
                    Console.WriteLine("Pues ahi esta la puerta. (ojo no te de en el culo al salir)");
                    break;

            }

                //Serializamos las cuentas que tenemos en el banco
                string mijson = JsonSerializer.Serialize(cuentas);
                File.WriteAllText("PasamosAJson.txt", mijson);

          

        }

       
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a NGB");
            List<BankAccount> cuentas = new List<BankAccount>();
           
            try
            {
               
                menu();

                //string mijson = JsonSerializer.Serialize(cuenta1);
                //File.WriteAllText("mijson.txt", mijson);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }

        }
    }
}
