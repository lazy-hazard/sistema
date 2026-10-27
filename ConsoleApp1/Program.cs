using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Runtime.InteropServices;

using System.Text;

using System.Threading.Tasks;


namespace Sem11

{

    internal class Program

    {

        static int max_students = 40;

        static int max_cursos = 4;

        static string[] cursos = { "Mate", "Programacion", "Fisica", "Base de Datos" };

        static string[] estudiante = new string[max_students];

        static double[,] MatrizNotas = new double[max_students, max_cursos];

        static int totalstu = 0;

        static string route = "CURSONOTAS.txt";


        public static void RegistroStu()

        {

            Console.WriteLine("REGISTRO DE ESTUDIANTE");

            if (totalstu >= max_students)

            {

                Console.WriteLine("Ya está al máximo");

                return;

            }

            string name = verificator.ReadText("Ingresar nombres y apellidos");

            estudiante[totalstu] = name;

            Console.WriteLine("Ingresar nota [0 a 20]:");

            for (int i = 0; i < cursos.Length; i++)

            {

                MatrizNotas[totalstu, i] = verificator.ReadDec($"Ingresa la nota del curso de {cursos[i]}");

            }

            totalstu++;

            Console.WriteLine("Estudiante registrao"); Console.ReadKey();

        }

        public static void Wardar()

        {

            Console.WriteLine("Guardado");

            if (totalstu == 0)

            {

                Console.WriteLine("No hay que guardar"); return;

            }

            using (StreamWriter escritor = new StreamWriter(route))

            {

                for (int i = 0; i < totalstu; i++)

                {

                    string linea = estudiante[i];

                    for (int j = 0; j < max_cursos; j++)

                    {

                        linea += "," + MatrizNotas[i, j];

                    }

                    escritor.WriteLine(linea);

                }

            }

            Console.WriteLine("wardado");

        }

        public static void Cargar()

        {

            Console.WriteLine("Cargandou");

            if (!File.Exists(route))

            {

                Console.WriteLine("No existeees"); return;

            }

            totalstu = 0;

            using (StreamReader lector = new StreamReader(route))

            {

                string linea;

                while ((linea = lector.ReadLine()) != null && totalstu < max_students)

                {

                    string[] partes = linea.Split(',');

                    if (partes.Length == max_cursos + 1)

                    {

                        estudiante[totalstu] = partes[0];

                        for (int i = 0; i < max_cursos; i++)

                        {

                            MatrizNotas[totalstu, i] = Convert.ToDouble(partes[i + 1]);

                        }

                        totalstu++;

                    }

                }

            }

            Console.WriteLine("Cargao");

        }

        public static void Mostra()

        {

            Console.WriteLine(new string('=', 100));

            Console.WriteLine("\t\tMostrada");

            Console.WriteLine(new string('=', 100));

            if (totalstu == 0)

            {

                Console.WriteLine("No hay na");

                return;

            }




            for (int i = 0; i < totalstu; i++)

            {

                for (int j = 0; j < max_cursos; j++)

                    Console.WriteLine(MatrizNotas[i, j]);

            }





        }

        static void Main(string[] args)

        {

            int opc = 0;

            while (opc != 5)

            {

                Console.Clear();

                Console.WriteLine("[1] REGISTRAR\n[2]GUARDAR\n[3]CARGAR\n[4]MOSTRAR\n[5]SALIR");

                opc = verificator.ReadEnt("Seleccione la opción: ");

                switch (opc)

                {

                    case 1:

                        RegistroStu();

                        break;

                    case 2:

                        Wardar();

                        break;

                    case 3:

                        Cargar();

                        break;

                    case 4:

                        Mostra();

                        break;

                    case 5:

                        Console.WriteLine("Adieu"); break;

                }

                Console.ReadKey();

            }

        }

    }

}