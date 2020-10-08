using System;

namespace ProgramaCadeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadeteria nCadeteria;
            nCadeteria = Helper.GenerarCadeteria();

            Helper.GenerarInforme(nCadeteria);
        }
    }
}
