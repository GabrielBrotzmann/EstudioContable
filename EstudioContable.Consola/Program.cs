using System;
using System.Collections.Generic;
using EstudioContable.AccesoDatos;
using EstudioContable.Negocio;
using EstudioContable.Utilidades;

namespace EstudioContable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstudioNegocio negocio = new EstudioNegocio(new EmpleadoDatos(), new EmpresaDatos(), new CategoriaDatos(),
                new LiquidacionDatos());
            Menu menu = new Menu(negocio);
            Dictionary<string, Action> opciones = new Dictionary<string, Action>
            {
                { "1", menu.IngresarEmpleado },
                { "2", menu.ConsultarEmpleado },
                { "3", menu.ConsultarEmpresaPorEmpleado },
                { "4", menu.IngresarEmpresaPorEmpleado },
                { "5", menu.ConsultarLiquidacionesPorEmpleado },
                { "6", menu.IngresarLiquidacionesPorEmpleado },
                { "7", menu.ConsultarCategoriasPorEmpleado },
                { "8", menu.IngresarCategoriasPorEmpleado },
                { "9", menu.ReporteDeEmpleadosPorEmpresa },
                { "10", menu.ReporteDeLiquidacionesPorCategoria }
            };
            do
            {
                Console.WriteLine(Textos.Menu);
                string opcion = Console.ReadLine();
                if (opcion == "0") return;
                if (string.IsNullOrEmpty(opcion) || !opciones.ContainsKey(opcion))
                {
                    Console.WriteLine("Opcion invalida, intente nuevamente");
                    continue;
                }
                opciones[opcion]();
            } while (true);
        }
    }
}