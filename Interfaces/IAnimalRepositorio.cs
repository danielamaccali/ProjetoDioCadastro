using System.Collections.Generic;

namespace PetControl.Interfaces
{
    public interface IAnimalRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
        bool VerificarPorId(int id);
    }
}
