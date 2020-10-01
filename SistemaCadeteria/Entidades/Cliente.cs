using SistemaCadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    class Cliente : Persona
    {
        static string[] Nombres = { "Fernando", "Lucia", "Juan", "Armando", "Selena", "Jose", "Lucia", "Nahuel", "Mariana", "Nicolas" };
        static string[] Direcciones = {"Av Roca 990", "Gral Paz 589", "25 de Mayo 89", "Buenos Aires 1282", "Laprida 150", "Cordoba 785", "Santiago 850", "Bernabe Araoz 584", "Av. Mitre 587", "Pje Padilla 897"};
        static string[] Telefonos = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        //CONSTRUCTOR POR DEFECTO
        public Cliente() : base ()
        {

        }

        //CONSTRUCTOR DE CLIENTE
        public Cliente(int ID, string Nombre, string Direccion, string Telefono) : base(ID, Nombre, Direccion, Telefono)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }

        //public static Cliente GenerarCliente()
        //{
        //    Cliente nCliente = new Cliente();
        //    Random aleat = new Random();

        //    nCliente.ID = aleat.Next(550);
        //    nCliente.Nombre = Nombres[aleat.Next(Nombres.Length + 1)];
        //    nCliente.Direccion = Direcciones[aleat.Next(Direcciones.Length + 1)];
        //    nCliente.Telefono = Telefonos[aleat.Next(Telefonos.Length + 1)];

        //    return nCliente;
        //}

        public void GenerarCliente()
        {
            Random aleat = new Random();

            this.ID = aleat.Next(550);
            this.Nombre = Nombres[aleat.Next(Nombres.Length)];
            this.Direccion = Direcciones[aleat.Next(Direcciones.Length)];
            this.Telefono = Telefonos[aleat.Next(Telefonos.Length)];
        }

        public string DatosCliente()
        {
            return (this.ID + " " + this.Nombre + " " + this.Direccion + " " + this.Telefono);
        }

        public void MostrarDatosCliente()
        {
            //string[] Datos = this.DatosCliente().Split(" ");
            Console.WriteLine("Datos del Cliente: ");
            Console.WriteLine("ID: " + this.ID);
            Console.WriteLine("Nombre: " + this.Nombre);
            Console.WriteLine("Direccion" + this.Direccion);
            Console.WriteLine("Telefono " + this.Telefono);
        }
    }
}
