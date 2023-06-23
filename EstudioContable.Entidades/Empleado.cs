using System;

namespace EstudioContable.Entidades
{
    public class Empleado : Persona
    {
   
        private int _idEmpresa;
        private int _idCategoria;
        private long _cuil;
        private string _fechaNacimiento;
        private DateTime _fechaAlta;
        private bool _activo;

        public Empleado(int id, int idEmpresa,string nombre,string apellido, int idCategoria, long cuil, string fechaNacimiento, DateTime fechaAlta, bool activo) :  base (id,  nombre,  apellido )
        {
            _idEmpresa = idEmpresa;
            _idCategoria = idCategoria;
            _cuil = cuil;
            _fechaNacimiento = fechaNacimiento;
            _fechaAlta = fechaAlta;
            _activo = activo;
        }

        public int IdEmpresa { get { return _idEmpresa; } set { _idEmpresa = value; } }
        public int IdCategoria { get { return _idCategoria; } set { _idCategoria = value; } }
        public long Cuil { get { return _cuil; } set { _cuil = value; } }
        public string FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public DateTime FechaAlta { get { return _fechaAlta; } set { _fechaAlta = value; } }
        public bool Activo { get { return _activo; } set { _activo = value; } }
        
        public bool EsCategoria(int idCategoria)
        {
            return _idCategoria == idCategoria;
        }

        public override string ToString()
        {
            return "ID: " + Id + "  " +
                "NOMBRE: " + Nombre + "  " +
                "APELLIDO " + Apellido + "  " +
                "FECHA DE ALTA: " + FechaAlta.ToString("dd - MM - yyyy");
        }
    }
}
