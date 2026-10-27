using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


namespace Sem11

{

    internal class verificator

    {

        public static double ReadDec(string msg)

        {

            double valor = 0;

            while (true)

            {

                Console.Write(msg);

                if (double.TryParse(Console.ReadLine(), out valor))

                {

                    if (valor < 0 || valor > 20)

                    {

                        Console.WriteLine("ERROR: El dígito debe estar en el rango de 0 a 20");

                        continue;

                    }

                    return valor;

                }

                Console.WriteLine("Ingresa un valor entero");

            }

        }


        public static int ReadEnt(string msg)

        {

            int valor = 0;

            while (true)

            {

                Console.Write(msg);

                if (int.TryParse(Console.ReadLine(), out valor))

                {

                    if (valor < 1 || valor > 5)

                    {

                        Console.WriteLine("ERROR: El dígito debe estar en el rango de 1 a 5");

                        continue;

                    }

                    return valor;

                }

                Console.WriteLine("Ingresa un valor entero");

            }

        }

        public static string ReadText(string msg)

        {

            while (true)

            {

                Console.Write(msg);

                string texto = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(texto))

                {

                    return texto;

                }

                Console.WriteLine("ERROR: El valor no puede ser vacío");

            }

        }

    }

}

