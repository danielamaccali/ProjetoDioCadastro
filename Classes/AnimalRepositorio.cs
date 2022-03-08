using PetControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetControl.Classes
{
    public class AnimalRepositorio : IAnimalRepositorio<Animal>
    {
        private List<Animal> Animais = new List<Animal>();

        public void Insere(Animal entidade)
        {
            this.Animais.Add(entidade);
        }

        public void Atualiza(int id, Animal entidade)
        {
            this.Animais[id] = entidade;
        }

        public void Exclui(int id)
        {
            this.Animais[id].Excluir();
        }

  

        public List<Animal> Lista()
        {
            return Animais;
        }

        public int ProximoId()
        {
            return this.Animais.Count;
        }

        public Animal RetornaPorId(int id)
        {
            return this.Animais[id];
        }

        public bool VerificarPorId(int id)
        {
            // retorna se o id existe na base
            return this.Animais.Count - 1 >= id;
        }
    }
}
