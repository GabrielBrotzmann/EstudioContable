using System;
using System.Collections.Generic;
using EstudioContable.AccesoDatos;
using EstudioContable.Entidades;

namespace EstudioContable.Negocio
{
    public class EmpresaNegocio
    {
        private readonly EmpresaDatos _empresaDatos;

        public EmpresaNegocio(EmpresaDatos empresaDatos)
        {
            _empresaDatos = empresaDatos;
        }

        public List<Empresa> GetListaEmpresa()
        {
            List<Empresa> list = _empresaDatos.TraerTodosEmpresa();

            return list;
        }

        public Empresa GetByIdEmpresa(int idEmpresa)
        {
            foreach (var item in GetListaEmpresa())
            {
                if (idEmpresa == item.Id)
                    return item;
            }

            return null;
        }

        public void AltaEmpresa(string razonSocial, long cuit, string domicilio, DateTime fechaAlta, int usuario,
            int id)
        {
            Empresa empresa = new Empresa(razonSocial, cuit, domicilio, fechaAlta, usuario, id);

            _empresaDatos.InsertarEmpresa(empresa);
        }

        public bool ValidarEmpresaExistente(int id)
        {
            bool resultado = false;
            List<Empresa> listadoEmpresas = GetListaEmpresa();

            foreach (Empresa emp in listadoEmpresas)
            {
                if (emp.Id == id)
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }
    }
}