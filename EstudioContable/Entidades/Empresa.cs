using System;

namespace EstudioContable.Entidades
{
    public class Empresa
    {
        private int _id;
        private string _razonSocial;
        private int _cuit;
        private string _domicilio;
        private DateTime _fechaAlta;
        private int _usuario;

        public Empresa(string razonSocial, int cuit, string domicilio, DateTime fechaAlta)
        {
            
            _razonSocial = razonSocial;
            _cuit = cuit;
            _domicilio = domicilio;
            _fechaAlta = fechaAlta;
            _usuario = 903294;
        }
    }
}