

namespace PetControl.Classes
{
    public class Animal : EntidadeBase
    {
        private TipoAnimal TipoAnimal;
        private string Nome;
        private int Idade;
        private SexoAnimal Sexo;
        private bool Excluido;

        public Animal(int id, TipoAnimal TipoAnimal, string Nome, int Idade, SexoAnimal Sexo)
        {
            this.Id = id;
            this.TipoAnimal = TipoAnimal;
            this.Nome = Nome;
            this.Idade = Idade;
            this.Sexo = Sexo;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = 
                $"Id: {Id} " +
                $"TipoAnimal: {TipoAnimal} " +
                $"Nome: {Nome} " +
                $"Idade: {Idade} " +
                $"Sexo: {Sexo} " +
                $"excluido: {(Excluido?"Sim":"Não")}";

            return retorno;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}
