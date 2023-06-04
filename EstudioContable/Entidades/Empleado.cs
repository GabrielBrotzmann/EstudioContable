using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioContable.Entidades
{
    public class Empleado : Persona
    {
        private int _idEmpleado;

        private int _idEmpresa;

        private int _categoriaEmpleado;

        private int _cuil;

        private DateTime _fechaAltaEmpleado;

        private List<Liquidacion> _liquidaciones;


        public int idEmpleado { get => _idEmpleado; set => _idEmpleado = value; }

        public int idEmpresa { get => _idEmpresa; set => _idEmpresa = value; }

        public int categoriaEmpleado { get => _categoriaEmpleado; set => _categoriaEmpleado = value; }

        public int cuil { get => _cuil; set => _cuil = value; }

        public DateTime fechaAltaEmpleado { get => _fechaAltaEmpleado; set => _fechaAltaEmpleado = value; }

        public List<Liquidacion> liquidaciones { get => _liquidaciones; set => _liquidaciones = value; }


        public Empleado() {
           
        }




        public void ingresarLiquidacion()
        {

        }

        public Liquidacion consultaLiquidacionEmpleado ()
        {

            return new Liquidacion();
        }




        







    }
}
