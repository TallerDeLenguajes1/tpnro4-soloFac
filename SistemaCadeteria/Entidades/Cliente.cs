using SistemaCadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    class Cliente : Persona
    {
        private int cantPedidosRealizados;

        public int CantPedidosRealizados { get => cantPedidosRealizados; set => cantPedidosRealizados = value; }

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

        public void AumentarCantidadPedidoRealizados()
        {
            this.CantPedidosRealizados++;
        }

        public float PedidosRealizados()
        {
            return this.CantPedidosRealizados;
        }
    }
}
