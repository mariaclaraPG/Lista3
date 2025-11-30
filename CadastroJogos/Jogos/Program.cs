using System;
namespace CadastroJogos
{
    class Program
    {

          static void registrarJogo(List<Jogo> listaJogos)
        {
            Jogo novoJogo = new Jogo();
            Console.Write("Título: ");
            novoJogo.titulo = Console.ReadLine();
            Console.Write("Console: ");
            novoJogo.console = Console.ReadLine();
            Console.Write("Ano: ");
            novoJogo.ano = int.Parse(Console.ReadLine());
            Console.Write("Ranking: ");
            novoJogo.ranking = int.Parse(Console.ReadLine());
            novoJogo.Emprestimo.data = "";
            novoJogo.Emprestimo.nomePessoa = "";
            novoJogo.Emprestimo.emprestado = false;
            listaJogos.Add(novoJogo);
        }
        
        static bool buscarJogo(List<Jogo> listaJogos, string tituloBusca)
        {
            foreach (Jogo j in listaJogos)
            {
                if (j.titulo.ToUpper().Contains(tituloBusca.ToUpper()))
                {
                    Console.WriteLine("*** Dados do Jogo ***");
                    Console.WriteLine($"Titulo: {j.titulo}");
                    Console.WriteLine($"Console: {j.console}");
					Console.WriteLine($"Ano: {j.ano}");
					Console.WriteLine($"Ranking: {j.ranking}");
                    return true;
                }

            }// fim foreach
            return false;
        }
		
		   static void Emprestar(List<Jogo> listaJogos, string tituloBusca)
        {

            foreach (Jogo j in listaJogos)
            {
                if (j.titulo.ToUpper().Contains(tituloBusca.ToUpper()))
                {
                    Console.WriteLine("Insira a data de empréstimo:");
                    j.Emprestimo.data = Console.ReadLine();
                    Console.WriteLine("Insira o nome da pessoa:");
                    j.Emprestimo.nomePessoa = Console.ReadLine();
                    j.Emprestimo.emprestado = true;
                }

            }
        }
		
		  static void Devolver(List<Jogo> listaJogos, string tituloBusca)
        {
            foreach (Jogo j in listaJogos)
            {
                if (j.titulo.ToUpper().Contains(tituloBusca.ToUpper()))
                {
                    j.Emprestimo.emprestado = false;                   
				    j.Emprestimo.data = "";
                    j.Emprestimo.nomePessoa = "";
                }

            }
        }
		
		
		       static bool consultaEmprestimo(List<Jogo> listaJogos)
        {
            bool consulta = false;
            foreach (Jogo j in listaJogos)
            {
                if (j.Emprestimo.emprestado == true)
                {
                    Console.WriteLine($"Título do jogo:{j.titulo}/Nome do mutuário:{j.Emprestimo.nomePessoa}");
                    consulta = true;
                }
            }
            return consulta;
        }
		 static void salvarDados(List<Jogo> listaJogos, string nomeArquivo)
        {

            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (Jogo j in listaJogos)
                {
                  writer.WriteLine($"{j.titulo};{j.console};{j.ano};{j.ranking};{j.Emprestimo.data};{j.Emprestimo.nomePessoa};{j.Emprestimo.emprestado}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");


        }

        static void carregarDados(List<Jogo> listaJogos, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                   string[] campos = linha.Split(',');
                    Jogo novaJogo = new Jogo();
                    novaJogo.titulo = campos[0];
                    novaJogo.console = campos[1];
                    novaJogo.ano = int.Parse(campos[2]);
                    novaJogo.ranking = int.Parse(campos[3]);
                    novaJogo.Emprestimo.data = campos[4];
                    novaJogo.Emprestimo.nomePessoa = campos[5];
                    novaJogo.Emprestimo.emprestado = bool.Parse(campos[6]);
                    listaJogos.Add(novaJogo);
				}
                    Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");

        }

		


        static int menu()
        {
            int opcao;
            Console.WriteLine("*** Sistema de Cadastro de Jogos ***");
            Console.WriteLine("1- Busca de Jogos");
			Console.WriteLine("2 - Registrar empréstimo");
            Console.WriteLine("3 - Devolver Jogo");
			Console.WriteLine("4 - Consulta de jogos emprestados");
			Console.WriteLine("5- Registrar jogo");
            Console.WriteLine("0- Sair do Sistema");
           
           
      
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        
        static void Main()
        {
            List<Jogo> listaJogos = new List<Jogo>();
            int opcao = 0;
            carregarDados(listaJogos, "jogo.txt");
            do
            {
                opcao = menu();
                switch (opcao)
                {
					
                    case 1: Console.Write("Titulo do Jogo:");
                        string tituloBusca = Console.ReadLine();
                        bool encontrado = buscarJogo(listaJogos, tituloBusca);
                        if (!encontrado)
                            Console.WriteLine("Jogo não encontrado" );
                        break;
						
				   case 2:
                        Console.WriteLine("Título: ");
                        tituloBusca = Console.ReadLine();
                        Emprestar(listaJogos, tituloBusca);
                        break;
                    case 3:
                        Console.WriteLine("Título do jogo devolvido:");
                        tituloBusca = Console.ReadLine();
                        Devolver(listaJogos, tituloBusca);
                        break;
                    case 4:
                        bool consulta = consultaEmprestimo(listaJogos);
                        if (!consulta)
                        {
                            Console.WriteLine("Nenhum empréstimo encontrado");                       
							}
                        break;
				     case 5:
                        registrarJogo(listaJogos);
                        break;
                    case 0:
                        salvarDados(listaJogos, "jogo.txt");
                        Console.WriteLine("Até mais ;)");
                        break;
                }
                Console.ReadKey();
                Console.Clear(); 
            } while (opcao != 0);

        }

    }

}

