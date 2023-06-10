using System;

namespace EstudioContable.Entidades
{
    public class Empresa
    {
        private string _razonSocial;
        private long _cuit;
        private string _domicilio;
        private DateTime _fechaAlta;
        private int _usuario;
        private int _id;


        public Empresa(string razonSocial, long cuit, string domicilio, DateTime fechaAlta, int usuario, int id)
        {
            _razonSocial = razonSocial;
            _cuit = cuit;
            _domicilio = domicilio;
            _fechaAlta = fechaAlta;
            _usuario = usuario;
            _id = id;
        }
        public int Id { get { return _id; } set { _id = value; } }
        public string RazonSocial { get { return _razonSocial; } set { _razonSocial = value; } }
        public long Cuit { get { return _cuit; } set { _cuit = value; } }
        public string Domicilio { get { return _domicilio; } set { _domicilio = value; } }

        public int Usuario{ get { return _usuario; } set { _usuario = value; } }
        public DateTime FechaAlta { get { return _fechaAlta; } set { _fechaAlta = value; } }

        public override string ToString()
        {
            if (RazonSocial != "" && RazonSocial != null)
            {
                return "ID: " + Id.ToString() + "  " +
                "RAZÓN SOCIAL: " + RazonSocial.ToString();
            }
            else
            {
                return "ID EMPRESA: " + Id.ToString() + "  ";
            }

        }
    }
}
