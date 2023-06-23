using System.Collections.Generic;
using EstudioContable.AccesoDatos;
using EstudioContable.Entidades;

namespace EstudioContable.Negocio
{
    public class CategoriaNegocio
    {
        private readonly CategoriaDatos _categoriaDatos;

        public CategoriaNegocio(CategoriaDatos categoriaDatos)
        {
            _categoriaDatos = categoriaDatos;
        }

        public List<Categoria> GetListaCategoria()
        {
            List<Categoria> list = _categoriaDatos.TraerTodos();

            return list;
        }

        public Categoria GetByIdCategoria(int idCategoria)
        {
            foreach (var item in GetListaCategoria())
            {
                if (idCategoria == item.Id)
                    return item;
            }

            return null;
        }


        public Categoria TraerCategoria(Categoria categoria)
        {
            return _categoriaDatos.TraerPorIdCategoria(categoria.Id);
        }

        public void AltaCategoria(string nombre, string convenio, double sueldoBasico, int id)
        {
            Categoria categoria = new Categoria(nombre, convenio, sueldoBasico, id);

            _categoriaDatos.InsertarCategoria(categoria);
        }

        public bool ValidarCategoriaExistente(int id)
        {
            bool resultado = false;
            List<Categoria> listadoCategorias = GetListaCategoria();

            foreach (Categoria categoria in listadoCategorias)
            {
                if (categoria.Id == id)
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }
    }
}