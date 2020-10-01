using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    static class Helper
    {
        static Random aleat = new Random();
        //Informe de Entregas realizadas por Cadete
        public static void GenerarInforme(Cadeteria nCadeteria)
        {
            float cantTotalPedidos = 0;
            float cantTotalPedidosEntregados = 0;
            List<Cadete> listaCadetes = nCadeteria.GenerarListadoCadetes(aleat.Next(aleat.Next(16)));
            //Diccionario para guardar los cadetes con sus respectivos cantidades de pedidos entregados
            Dictionary<Cadete, int> dicCadetePedido = new Dictionary<Cadete, int>();
            //Por cada Cadete guardo sus datos, genero su lista de pedidos para realizar el informe
            foreach (Cadete _cadete in listaCadetes)
            {
                string NombreCadete = _cadete.Nombre;
                //A la lista vacia de _cadete le genero una lista de pedidos y luego
                //Determino si la entrega fue realizada o no por ese Cadete
                _cadete.ListadoPedidos = Helper.GenerarListadoPedidos(aleat.Next(aleat.Next(16)));
                List<Pedido> listadoPedidoCadete = _cadete.ListadoPedidos;
                cantTotalPedidos += listadoPedidoCadete.Count;
                listadoPedidoCadete = DeterminarEntregaPedidos(listadoPedidoCadete);

                //int[] Paga_CantPedidosEntregados = Helper.DeterminarPagayPedidosEntregados(listadoPedidoCadete);
                int pagaJornal = Helper.DeterminarPago(listadoPedidoCadete);
                int cantPedidosEntregados = Helper.DeterminarCantidadPedidosEntregados(listadoPedidoCadete);
                cantTotalPedidosEntregados += cantPedidosEntregados;

                MostrarInformeCadete(_cadete, pagaJornal, cantPedidosEntregados);

                dicCadetePedido.Add(_cadete, cantPedidosEntregados);
            }
            Cadete cadeteMayorEntregas = Helper.CadeteMasEntregas(dicCadetePedido);

            MostrarInformeAparte(cadeteMayorEntregas, cantTotalPedidosEntregados, cantTotalPedidos);

            //Nombre del Cadete
            //Cantidad de Pedidos entregados
            //Cuanto debe cobrar de jornal

            //Informe que indique: cual es el cadete que mas pedidos entrego
            //Informe del promedio de pedidos entregados
        }

        //Consulta: que no se puede hacer cuando declaro una clase como static
        public static List<Pedido> GenerarListadoPedidos(int cantPedidos)
        {
            List<Pedido> nListaPedidos = new List<Pedido>(); 
            for (int i = 0; i < cantPedidos; i++)
            {
                Pedido nPedido = new Pedido();
                nPedido.GenerarPedido();
                nListaPedidos.Add(nPedido);
            }
            return nListaPedidos;
        }

        /// <summary>
        /// Recibe un diccionario <Cadete, CantidadPedidos(int)> y devuelve el cadete con mas entregas
        /// </summary>
        /// <param name="dicCadetePedido"></param>
        public static Cadete CadeteMasEntregas(Dictionary<Cadete, int> dicCadetePedido)
        {
            Cadete CadeteMasEntregas = new Cadete();
            int maxCantPedidos = 0;

            //Recorro el diccionario
            foreach (KeyValuePair<Cadete, int> par in dicCadetePedido)  //Es lo unico mas costoso en el ciclo
            {
                //Si el valor entero del diccionario es mayor al valor de la Maxima cantidad de Pedidos
                if (par.Value > maxCantPedidos)
                {
                    CadeteMasEntregas = par.Key;    //Guardo el cadete
                    maxCantPedidos = par.Value;     //Guardo ese valor para compararlo nuevamente
                }
            }

            return CadeteMasEntregas;
        }

        /// <summary>
        /// Determina si el Pedido fue entregado o no
        /// </summary>
        /// <returns>Lista completa con los valores que ya tenia y su Estado de entrega que se detemrino en esta funcion</returns>
        public static List<Pedido> DeterminarEntregaPedidos(List<Pedido> listadoPedidos)
        {
            foreach (Pedido _pedido in listadoPedidos)
            {
                if (aleat.Next(2) == 1)
                {
                    _pedido.Estado = true;
                }
                else
                {
                    _pedido.Estado = false;
                }
            }

            return listadoPedidos;
        }

        //Consulta: Es mas Costoso recorrer una lista completa dos veces si individualizo los metodos, seria mas eficiente 
        //separar los metodos para individualizarlos, o dejar este metodo asi como esta?
        //public static int[] DeterminarPagayPedidosEntregados(List<Pedido> listadoPedidoCadete)
        //{
        //    int[] Paga_PedidosEntregados = new int[2];
        //    int pagaJornal = 0;
        //    int cantPedidosEntregados = 0;

        //    foreach (Pedido _pedido in listadoPedidoCadete)
        //    {
        //        if (_pedido.Estado == true)
        //        {
        //            pagaJornal += 100;
        //            cantPedidosEntregados++;
        //        }
        //    }
        //    Paga_PedidosEntregados[0] = pagaJornal;
        //    Paga_PedidosEntregados[1] = cantPedidosEntregados;

        //    return Paga_PedidosEntregados;
        //}

        /// <summary>
        /// Recibe un Listado de Pedidos y determina el pago total de la jornada del cadete
        /// </summary>
        /// <param name="listadoPedidoCadete"></param>
        /// <returns>Pago del Jornal</returns>
        public static int DeterminarPago(List<Pedido> listadoPedidoCadete)
        {
            int pagaJornal = 0;

            foreach (Pedido _pedido in listadoPedidoCadete)
            {
                if (_pedido.Estado == true)
                {
                    pagaJornal += 100;
                }
            }

            return pagaJornal;
        }

        /// <summary>
        /// Recibe un listado de Pedidos y determina la cantidad de pedidos entregados por el Cadete
        /// </summary>
        /// <param name="listadoPedidoCadete"></param>
        /// <returns>Cantidad de Pedidos Entregados</returns>
        public static int DeterminarCantidadPedidosEntregados(List<Pedido> listadoPedidoCadete)
        {
            int cantPedidosEntregados = 0;

            foreach (Pedido _pedido in listadoPedidoCadete)
            {
                if (_pedido.Estado == true)
                {
                    cantPedidosEntregados++;
                }
            }

            return cantPedidosEntregados;
        }

        public static void MostrarInformeCadete(Cadete _cadete, int pagaJornal, int cantPedidosEntregados)
        {
            Console.WriteLine("\nCadete");
            Console.WriteLine("Nombre: " + _cadete.Nombre);
            Console.WriteLine("Pago Jornal: $" + pagaJornal);
            Console.WriteLine("Cantidad de Pedidos Entregados: " + cantPedidosEntregados);
        }

        /// <summary>
        /// Muestra cual es el cadete con mayor cantidad de pedidos entregados y el promedio de los pedidos entregados
        /// </summary>
        public static void MostrarInformeAparte(Cadete cadeteMasEntregas, float cantTotalPedidosEntregados, float cantTotalPedidos)
        {
            float Promedio = 0;
            Console.WriteLine("\nInforme Aparte: ");
            Console.WriteLine("Cadete con mas entregas realizadas: ");
            cadeteMasEntregas.MostrarDatosCadete();
            Console.WriteLine("\nPromedio de las entregas totales realizadas por todos los cadetes: ");
            Promedio = cantTotalPedidosEntregados / cantTotalPedidos;
            Console.WriteLine("Promedio: " + Promedio);
        }
    }
}
