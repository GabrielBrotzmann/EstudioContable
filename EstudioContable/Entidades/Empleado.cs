using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioContable.Entidades
{
    public class Empleado : Persona
    {
        private int idEmpleado { get; set; }
        
        private int idEmpresa { get; set; }

        private int categoriaEmpleado {get;set;}

        private int cuil { get; set; }

        public DateTime fechaAltaEmpleado;

        public List<Liquidacion> liquidaciones;

        public Empleado() { }


        public void ingresarLiquidacion()
        {

        }

        public Liquidacion consultaLiquidacionEmpleado ()
        {

            return new Liquidacion();
        }




        







    }
}
