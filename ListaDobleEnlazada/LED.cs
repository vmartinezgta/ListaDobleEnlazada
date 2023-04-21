using ListaDoblementeEnlazada;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDoblementeEnlazada
{
    class LED
    {
        //nodo para almacenar la posicion del nodo en la primera prosicion 
        public Nodo primerNodo { get; set; }
        //almacena o apunta al nodo en la ultima posicion 
        public Nodo ultimoNodo { get; set; }
        //contador de nodos 
        public int Tnodos { get; set; }

        public LED()
        {
            primerNodo = null;
            ultimoNodo = null;
            Tnodos = 0;

        }
        //----------------------------------------------------------------------------metodo de validacion de la lista 
        bool listaVacia()
        {
            if (primerNodo == null) { return true; } else { return false; }
        }
        //metodo de agregar al final
        public string AgregarAlFinal(object informacion)
        {
            //Agregar un nodo asignando el dato al nodo
            Nodo nnodo = new Nodo(informacion);
            //verificar si la lista esta vacia 
            if (listaVacia())
            {
                primerNodo = ultimoNodo = nnodo; // en caso que este vacia se le asigna al primer nodo el nuevo valor   
            }
            else
            {
                ultimoNodo.ligaS = nnodo;  //liga siguiente almacena referencia del nuevo nodo
                nnodo.ligaA = ultimoNodo;//liga anterior del nuevo nodo almacena referencia del nodo anterior
                ultimoNodo = nnodo;//cambia posicion de ultimo nodo al nuevo nodo agregadp
            }
            Tnodos += 1;
            return "nodo agregado";

        }
        //-------------------------------------------------------------------------------------------------mostrar el nodo siguiente 

        public string mostrarNS()
        {
            Nodo nodoActual = primerNodo;
            if (listaVacia())
            { return "No hay elementos"; }
            else
            {
                if (nodoActual.ligaS != null)
                {
                    nodoActual = nodoActual.ligaS;
                    return "Dato siguiente: " + nodoActual.Informacion;
                }
                else
                {
                    return "Esta en el ultimo nodo";
                }
            }
        }
        //----------------------------------------------------------------------------------------------------metodo de agregar al inicio
        public string AgregarAlInicio(object informacion)
        {
            //Agregar un nodo asignando el dato al nodo
            Nodo nnodo = new Nodo(informacion);
            //verificar si la lista esta vacia 
            if (listaVacia())
            {
                primerNodo = ultimoNodo = nnodo; // en caso que este vacia se le asigna al primer nodo el nuevo valor   
            }
            else
            {
                primerNodo.ligaA = nnodo;  //liga anterior de pirmer nodo almacena el nuevo
                nnodo.ligaS = primerNodo;//la liga siguiente del nuevo nodo almacena el primer nodo que sera el segundo
                primerNodo = nnodo;//cambia posicion del primer nodo al nuevo 
            }
            Tnodos += 1;
            return "nodo agregado";

        }
        //-----------------------------------------------------------------------------------------------Metodo de recorrer la lista 
        public string recorrerInicio()
        {
            //verificar si la lista esta vacia 
            if (listaVacia()) { return "lista vacia"; }
            else
            {
                Nodo aux; // nodo temporal para almacenar los valores 
                aux = primerNodo; // almacena el valor del primer nodo para iniciar el recorrido 
                string lista = string.Empty; //string vacio para almacenar la cadena de valores 
                while (aux != null)
                {
                    lista += $"{aux.ToString()} ->"; //muestra el valor del nodo
                    aux = aux.ligaS; //se mueve a la siguiente referencia
                }
                return lista; //devuelve la lista para mostrar en pantalla 
            }

        }
        //------------------------------------------------------------------------------------------Metodo de recorrer la lista al final 
        public string recorrerFinal()
        {
            //verificar si la lista esta vacia 
            if (listaVacia()) { return "lista vacia"; }
            else
            {
                Nodo aux; // nodo temporal para almacenar los valores 
                aux = ultimoNodo; // almacena el valor del primer nodo para iniciar el recorrido 
                string lista = string.Empty; //string vacio para almacenar la cadena de valores 
                while (aux != null)
                {
                    lista += $"{aux.ToString()} <-"; //muestra el valor del nodo
                    aux = aux.ligaA; //se mueve a la siguiente referencia
                }
                return lista; //devuelve la lista para mostrar en pantalla 
            }

        }
        //------------------------------------------------------------------------------------ Eliminar el nodo del inicio
        public string ElInicio()
        {
            //verificar si la lista esta vacia 
            if (listaVacia()) return "lista vacia";
            //verficar que la lista tenga mas de un elemento 
            if (primerNodo == ultimoNodo)
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //si contiene mas de un nodo 
                primerNodo = primerNodo.ligaS; //se le asigna la direccion del siguiente nodo 
                primerNodo.ligaA = null; //se elimina la liga del nodo anterior (primer nodo)

            }
            return "eliminado";

        }
        //-------------------------------------------------------------------------------Eliminar al final de la lista 
        public string ElFinal()
        {
            //verificar si la lista esta vacia 
            if (listaVacia()) return "lista vacia";
            if (primerNodo == ultimoNodo)
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //si contiene mas de un nodo 
                ultimoNodo = ultimoNodo.ligaA; //se le asigna la direccion del nodo anterior
                ultimoNodo.ligaS = null; //se elimina la liga del nodo siguiente (ultimo)

            }
            return "eliminado";

        }
        //-------------------------------------------------------------------------------Eliminar con informacion X
        public string ElconInfoX(object valor)
        {
            //verificar si la lista esta vacia 
            if (listaVacia()) return "lista vacia";
            if (primerNodo == ultimoNodo)
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //definir nodos auxiliares 
                Nodo nActual = primerNodo;
                Nodo nAnterior = primerNodo;

                //recorrer lista para encontrar el valor 
                while (nActual != null && !nActual.Informacion.Equals(valor))//si el nodo actual es diferente de null y diferente del valor a buscar, continua el recorrido
                {

                    nAnterior = nActual; //almacena el valor del nodo anterior
                    nActual = nActual.ligaS; //almacena el valor del nodo siguiente 

                }

                if (nActual != null)//mientras el nodo actual sea diferente de null
                {
                    if (nActual == primerNodo)//si el valor es igual al orimer nodo
                    {
                        ElInicio(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else if (nActual == ultimoNodo)
                    { //su el valor coincide con el ultimo nodo

                        ElFinal(); //llamamos al metodo para eliminar el ultimo nodo
                    }
                    else
                    {
                        nAnterior.ligaS = nActual.ligaS; //nodo anterior almacena la liga del nodo siguiente del que se eliminara
                        nActual.ligaS.ligaA = nAnterior; //almacena la referencia del siguiente para mantener el doble enlace 

                    }
                }

            }
            return "Eliminado";
        }
        //-----------------------------------------------------------------------------------------------Eliminar nodo antes de un dato X
        public string ElAntX(object valor)
        {
            //verificar si la lista esta vacia
            if (listaVacia()) return "lista vacia";
            if (primerNodo == ultimoNodo) //en caso de que solo contenga un nodo 
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //definir nodos auxiliares 
                Nodo nActual = primerNodo;
                Nodo nAnterior = primerNodo;
                Nodo nAux = null; //auxiliar para ir almacenando el primer valor (anterior del anterior)

                //recorrer lista para encontrar el valor 
                while (nActual != null && !nActual.Informacion.Equals(valor))//si el nodo actual es diferente de null y diferente del valor a buscar, continua el recorrido
                {

                    nAnterior = nActual; //almacena el valor del nodo anterior
                    nActual = nActual.ligaS; //almacena el valor del nodo siguiente
                    nAux = nAnterior.ligaA; //almacena la liga inicial (anterior del anterior)

                }

                if (nActual != null)//mientras el nodo actual sea diferente de null
                {

                    if (nAnterior == primerNodo)//si el valor es igual al orimer nodo
                    {
                        ElInicio(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else
                    {
                        nAux.ligaS = nActual; //nodo anterior almacena la liga del nodo siguiente del que se eliminara
                        nActual.ligaA = nAux; //almacena la referencia del anterior para eliminarlo 

                    }
                }
            }
            return "Eliminado";
        }
        //---------------------------------------------------------------------------------Metodo Eliminar depues de un valor X
        public string ElDesX(object valor)
        {
            //verificar si la lista esta vacia
            if (listaVacia()) return "lista vacia";
            if (primerNodo == ultimoNodo) //en caso de que solo contenga un nodo 
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //definir nodos auxiliares 
                Nodo nActual = primerNodo;
                Nodo nAnterior = primerNodo;
                Nodo nSigui = primerNodo; //auxiliar para ir almacenando el siguiente valor

                //recorrer lista para encontrar el valor 
                while (nActual != null && !nActual.Informacion.Equals(valor))//si el nodo actual es diferente de null y diferente del valor a buscar, continua el recorrido
                {

                    nAnterior = nActual; //almacena el valor del nodo anterior
                    nActual = nActual.ligaS; //almacena el valor del nodo siguiente
                    nSigui = nActual.ligaS;


                }

                if (nActual != null)//mientras el nodo actual sea diferente de null
                {

                    if (nSigui == ultimoNodo)//si el valor es igual al orimer nodo
                    {
                        ElFinal(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else if (nActual == ultimoNodo)
                    {
                        ElFinal(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else
                    {
                        
                        nActual.ligaS = nSigui.ligaS; //nodo anterior almacena la liga del nodo siguiente del que se eliminara
                        nSigui.ligaS.ligaA = nActual; //almacena la referencia del siguiente para eliminarlo 



                    }
                }
            }
            return "Eliminado";
        }
        //---------------------------------------------------------------------------------------------Eliminar Nodo despues de una posicion X
        public string ElDesPos(int a)
        {
            //verificar si la lista esta vacia
            if (listaVacia()) return "lista vacia";
            if (primerNodo == ultimoNodo) //en caso de que solo contenga un nodo 
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //definir nodos auxiliares 
                Nodo nActual = primerNodo;
                Nodo nAnterior = primerNodo;
                Nodo nSigui = primerNodo; //auxiliar para ir almacenando el siguiente valor

                //recorrer la lista con un for para usar un contador 
                for(int i = 1; i <= a&&i!=null; i++)
                {
                    nAnterior = nActual; //almacena el valor del nodo anterior
                    nActual = nActual.ligaS; //almacena el valor del nodo siguiente
                    nSigui = nActual.ligaS;

                }
                if (nActual != null)//mientras el nodo actual sea diferente de null
                {

                    if (nSigui == ultimoNodo)//si el valor es igual al orimer nodo
                    {
                        ElFinal(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else if (nActual == ultimoNodo)
                    {
                        ElFinal(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else
                    {

                        nActual.ligaS = nSigui.ligaS; //nodo anterior almacena la liga del nodo siguiente del que se eliminara
                        nSigui.ligaS.ligaA = nActual; //almacena la referencia del siguiente para eliminarlo 



                    }
                }

                }
            return "Eliminado";
           
        }
        //---------------------------------------------------------------------------------------------Eliminar Nodo antes de una posicion X
        public int ElAntPos(int a)
        {
            //verificar si la lista esta vacia
            if (listaVacia()) return 0;
            if (primerNodo == ultimoNodo) //en caso de que solo contenga un nodo 
            {
                //ambos se vuelven null para vaciar la lista
                primerNodo = null;
                ultimoNodo = null;
            }
            else
            {
                //definir nodos auxiliares 
                Nodo nActual = primerNodo;
                Nodo nAnterior = primerNodo;
                Nodo nAux = null; //auxiliar para ir almacenando el primer valor (anterior del anterior)

                //recorrer la lista con un for para usar un contador 
                for (int i = 1; i <= a && i != null; i++)
                {
                    nAnterior = nActual; //almacena el valor del nodo anterior
                    nActual = nActual.ligaS; //almacena el valor del nodo siguiente
                    nAux = nAnterior.ligaA; //almacena la liga inicial (anterior del anterior)

                }
                if (nActual != null)//mientras el nodo actual sea diferente de null
                {

                    if (nAnterior == primerNodo)//si el valor es igual al orimer nodo
                    {
                        ElInicio(); //llamamos al metodo para eliminar el primer nodo 

                    }
                    else
                    {
                        nAux.ligaS = nActual; //nodo anterior almacena la liga del nodo siguiente del que se eliminara
                        nActual.ligaA = nAux; //almacena la referencia del anterior para eliminarlo 

                    }
                }

            }
            return 1;
        }

    }
}
