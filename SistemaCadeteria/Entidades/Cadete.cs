using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProgramaCadeteria
{
    class Cadete
    {
        int iD;
        string nombre;
        string direccion;
        string telefono;
        List<Pedido> listadoPedidos;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        

        //CONSTRUCTOR POR DEFECTO
        public Cadete()
        {
            this.ListadoPedidos = new List<Pedido>();
        }

        //CONSTRUCTOR DE CADETE
        public Cadete(int ID, string Nombre, string Direccion, string Telefono)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            //Agregacion
            this.ListadoPedidos = new List<Pedido>();
        }

        
        //Agregacion
        public void AgregarPedido(Pedido nPedido)
        {
            this.ListadoPedidos.Add(nPedido);
        }

        /// <summary>
        /// Recibe un Listado de Pedidos y determina el pago total de la jornada del Cadete
        /// </summary>
        /// <param name="listadoPedidoCadete"></param>
        /// <returns>Pago del Jornal</returns>
        public float DeterminarPago()
        {
            float pagaJornal = 0;

            foreach (Pedido _pedido in this.ListadoPedidos)
            {
                if (_pedido.Estado == true)
                {
                    pagaJornal += 100;
                }
            }

            return pagaJornal;
        }

        public float PromedioEntregasRealizadas(){ return (this.DeterminarCantidadPedidosEntregados() / this.CantidadTotalPedidos()); }

        /// <summary>
        /// Recibe un listado de Pedidos y determina la cantidad de pedidos entregados por el Cadete
        /// </summary>
        /// <param name="listadoPedidoCadete"></param>
        /// <returns>Cantidad de Pedidos Entregados</returns>
        public float DeterminarCantidadPedidosEntregados()
        {
            int cantPedidosEntregados = 0;

            foreach (Pedido _pedido in this.ListadoPedidos)
            {
                if (_pedido.Estado == true)
                {
                    cantPedidosEntregados++;
                }
            }

            return cantPedidosEntregados;
        }

        /// <summary>
        /// Recibe un cadete y retorna la Cantidad Total de Pedidos (suma de pedidos entregados y no entregados)
        /// </summary>
        /// <returns>Cantidad total de pedidos</returns>
        public float CantidadTotalPedidos()
        {
            return this.listadoPedidos.Count;
        }

        public string DatosCadete()
        {
            return (this.ID + ";" + this.Nombre + ";" + this.Direccion + ";" + this.Telefono);
        }


    }
}
