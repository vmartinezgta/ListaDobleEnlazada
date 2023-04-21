using System;

namespace ListaDoblementeEnlazada
{
    class Program
    {
        static void Main(string[] args)
        {
            LED list = new LED();
            list.AgregarAlFinal("a");
            list.AgregarAlFinal("b");
            list.AgregarAlFinal("c");
            list.AgregarAlFinal("d");
            list.AgregarAlFinal("e");
            list.AgregarAlFinal("f");
            Console.WriteLine(list.recorrerInicio());
            Console.WriteLine(list.recorrerFinal());
            list.ElDesPos(2);
            Console.WriteLine(list.recorrerInicio());
            Console.WriteLine(list.recorrerFinal());


            Console.ReadKey();

            int op = 0;
            while (op != 7)
            {
                Console.WriteLine("Menu de Opciones");
                Console.WriteLine(" ");
                Console.WriteLine("1- Mostrar Primer Nodo");
                Console.WriteLine("2- Mostrar Ultimo Nodo");
                Console.WriteLine("3- Mostrar Lista");
                Console.WriteLine("4- Eliminar Primer Nodo");
                Console.WriteLine("5- Eliminar Ultimo Nodo");
                Console.WriteLine("6- Eliminar Nodo con un valor X");
                Console.WriteLine("7- Eliminar Nodo Antes de un valor X");
                Console.WriteLine("8- Eliminar Nodo despues de una posicion X");
                Console.WriteLine("9- Eliminar Nodo Antes de una posicion X");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine(list.primerNodo.Informacion);
                        break;
                    case 2:
                        Console.WriteLine(list.ultimoNodo.Informacion);
                        break;
                    case 3:
                        Console.WriteLine(list.recorrerInicio());
                        break;
                    case 4:
                        Console.WriteLine(list.ElInicio());
                        break;
                    case 5:
                        Console.WriteLine(list.ElFinal());
                        break;
                    case 6:
                        Console.WriteLine(list.ElconInfoX("a"));
                        break;



                }



            }
        }
    }
}