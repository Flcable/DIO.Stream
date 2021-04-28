using System.Collections.Generic;

namespace DIO.Stream.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int Id);
        void Insere(T entidade);
        void Exclui(int Id);
        void Atualiza(int Id, T entidade);
        int ProximoId();
    }
}