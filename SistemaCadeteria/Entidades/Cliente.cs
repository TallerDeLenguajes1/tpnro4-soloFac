using SistemaCadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    class Cliente : Persona
    {
        private List<Pedido> listadoPedidos;

        internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        //CONSTRUCTOR POR DEFECTO
        public Cliente() : base ()
        {
        }

        //CONSTRUCTOR DE CLIENTE
        public Cliente(int ID, string Nombre, string Direccion, string Telefono) : base (ID, Nombre, Direccion, Telefono)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }


        public string DatosCliente()
        {
            return (this.ID + ";" + this.Nombre + ";" + this.Direccion + ";" + this.Telefono);
        }

        public void AgregarPedido(Pedido nPedido)
        {
            ListadoPedidos.Add(nPedido);
        }

        public float PedidosRealizados()
        {

            return 0;
        }
    }
}
