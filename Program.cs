using PetControl.Classes;
using System;

namespace PetControl
{
	class Program
	{
		static AnimalRepositorio repositorio = new AnimalRepositorio();

		static void Main(string[] args)
		{
			string opcaoSelecionada = ObterOpcaoUsuario();


			while (opcaoSelecionada != "X")
			{
				switch (opcaoSelecionada)
				{
					case "1":
						ListarAnimal();
						break;
					case "2":
						InserirAnimal();
						break;
					case "3":
						AtualizarAnimal();
						break;
					case "4":
						ExcluirAnimal();
						break;
					case "5":
						VisualizarAnimal();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}


				opcaoSelecionada = ObterOpcaoUsuario();
			}
		}

        private static void VisualizarAnimal()
        {
			Console.Write("Digite o id do animal: ");
			int idAnimal = int.Parse(Console.ReadLine());

			if (!repositorio.VerificarPorId(idAnimal) || idAnimal < 0)
			{
				Console.Write("\n **** O id do animal não existe ou é inválido: ***\n");
				return;
			}

			var animal = repositorio.RetornaPorId(idAnimal);

			Console.WriteLine(animal);
		}

        private static void ExcluirAnimal()
        {
			Console.Write("Digite o id o animal a ser excluido: ");
			int idAnimal = int.Parse(Console.ReadLine());

			if (!repositorio.VerificarPorId(idAnimal) || idAnimal < 0)
            {
				Console.Write("\n **** O id do animal não existe ou é inválido: ***\n");
				return;
			}

			repositorio.Exclui(idAnimal);
		}

        private static void AtualizarAnimal()
        {
			Console.Write("Digite o id do animal: ");
			int idAnimal = int.Parse(Console.ReadLine());

			if (!repositorio.VerificarPorId(idAnimal) || idAnimal < 0)
            {
				Console.Write("\n **** O id do animal não existe ou é inválido: ***\n");
				return;
			}
				
			// tipo animal
			foreach (int i in Enum.GetValues(typeof(TipoAnimal)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAnimal), i));
			}
			Console.Write("Digite o tipo de animal entre as opções acima: ");
			int tipoAnimal = int.Parse(Console.ReadLine());


			// sexo animal
			foreach (int i in Enum.GetValues(typeof(SexoAnimal)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(SexoAnimal), i));
			}
			Console.Write("Digite o sexo do animal entre as opções acima: ");
			int sexoAnimal = int.Parse(Console.ReadLine());

			// nome
			Console.Write("Digite o nome do animal: ");
			string nomeAnimal = Console.ReadLine();

			// idade
			Console.Write("Digite a idade do animal: ");
			int idadeAnimal = int.Parse(Console.ReadLine());


			Animal atualizadoAnimal = new Animal(id: repositorio.ProximoId(),
										TipoAnimal: (TipoAnimal)tipoAnimal,
										Nome: nomeAnimal,
										Idade: idadeAnimal,
										Sexo: (SexoAnimal)sexoAnimal);

			repositorio.Atualiza(idAnimal, atualizadoAnimal);
		}

        private static void InserirAnimal()
        {
			Console.WriteLine("Inserir novo animal");

			// tipo animal
			foreach (int i in Enum.GetValues(typeof(TipoAnimal)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAnimal), i));
			}
			Console.Write("Digite o tipo de animal entre as opções acima: ");
			int tipoAnimal = int.Parse(Console.ReadLine());


			// sexo animal
			foreach (int i in Enum.GetValues(typeof(SexoAnimal)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(SexoAnimal), i));
			}
			Console.Write("Digite o sexo do animal entre as opções acima: ");
			int sexoAnimal = int.Parse(Console.ReadLine());

			// nome
			Console.Write("Digite o nome do animal: ");
			string nomeAnimal = Console.ReadLine();

			// idade
			Console.Write("Digite a idade do animal: ");
			int idadeAnimal = int.Parse(Console.ReadLine());


			Animal novoAnimal = new Animal(id: repositorio.ProximoId(),
										TipoAnimal: (TipoAnimal)tipoAnimal,
										Nome: nomeAnimal,
										Idade: idadeAnimal,
										Sexo: (SexoAnimal) sexoAnimal);

			repositorio.Insere(novoAnimal);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("PetControl - Cadastro PetShop!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar animais");
			Console.WriteLine("2- Inserir novo animal");
			Console.WriteLine("3- Atualizar animal");
			Console.WriteLine("4- Excluir animal");
			Console.WriteLine("5- Visualizar animal");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;

		}

		private static void ListarAnimal()
		{
			Console.WriteLine("Listar animais");

			var listaAnimais = repositorio.Lista();

			if (listaAnimais.Count == 0)
			{
				Console.WriteLine("Nenhum animal cadastrado.");
				return;
			}

			foreach (var animal in listaAnimais)
			{
				var excluido = animal.retornaExcluido();

				Console.WriteLine($"{animal.ToString()}");
			}
		}
	}
}
