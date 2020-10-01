using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ProgramaCadeteria
{
    class Cadeteria
    {
        private string nombre;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria()
        {
            //Composicion
            this.ListadoCadetes = new List<Cadete>();
        }

        public Cadeteria(string Nombre, List<Cadete> ListadoCadetes)
        {
            this.Nombre = Nombre;
            //Composicion con Cadetes
            this.ListadoCadetes = new List<Cadete>(ListadoCadetes);
        }

        public void GenerarCadeteria()
        {
            Random aleat = new Random();
            this.Nombre = "Cadeteria Rapida";
            this.ListadoCadetes = this.GenerarListadoCadetes(aleat.Next(aleat.Next(16)));
        }

        /// <summary>
        /// Genera Listado de Cadetedes con sus respectivos valores aleatorios ID, Nombre, Direccion, Telefono, Listado de Pedidos Vacio
        /// </summary>
        /// <returns>void</returns>
        public List<Cadete> GenerarListadoCadetes(int cantCad)
        {
            List<Cadete> listado = new List<Cadete>();
            //Console.WriteLine("Cantidad de Cadetes a Registrar");
            //cantCad = Convert.ToInt32(Console.ReadKey());

            //Cadete nCadete = new Cadete();     CONSULTA: Y si realizo la instanciacion afuera del for?
            for (int i = 0; i < cantCad; i++)
            {
                Cadete nCadete = new Cadete();
                nCadete.GenerarPersona();

                listado.Add(nCadete);
            }
            return listado;
        }


    }
}
