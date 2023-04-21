using System;
using System.Collections.Generic;
using System.Text;
using ListaDoblementeEnlazada;

namespace ListaDoblementeEnlazada
{
    public class Nodo
    {
        //tipo objeto que almacena cualquier valor
        public object Informacion { get; set; }
        //liga tipo nodo ya que almacena el valor del espacio de memoria de la liga anterior
        public Nodo ligaA { get; set; }
        //Liga para el valor siguiente y guardar la referencia del nodo siguiente
        public Nodo ligaS { get; set; }
        //constructores 
        public Nodo()
        {

            Informacion = null;
            ligaA = null;
            ligaS = null;

        }

        public Nodo(object informacion)
        {
            Informacion = informacion;
            ligaA = null;
            ligaS = null;



        }
        public Nodo(object informacion, Nodo liga, Nodo ligaB)
        {
            Informacion = informacion;
            ligaA = liga;
            ligaS = ligaB;
        }

        //polimorfismo modifica el metodo to string 
        public override string ToString()
        {
            return $"{Informacion}";
        }


    }
}