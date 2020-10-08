using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    class Cliente
    {
        private int iD;
        private string nombre;
        private string direccion;
        private string telefono;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        //CONSTRUCTOR POR DEFECTO
        public Cliente()
        {

        }

        //CONSTRUCTOR DE CLIENTE
        public Cliente(int ID, string Nombre, string Direccion, string Telefono)
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

    }
}
