using System.Collections.Generic;
using EstudioContable.Entidades;

namespace App.Usecases
{
    public interface IGetEmpresasByUsuarioUseCase
    {
        List<Empresa> Execute(int idUsuario);
    }
    public class GetEmpresasByUsuarioUseCase : IGetEmpresasByUsuarioUseCase
    {
        public GetEmpresasByUsuarioUseCase() {}
        
        public List<Empresa> Execute(int idUsuario)
        {
            return new List<Empresa>();
        }
    }
}