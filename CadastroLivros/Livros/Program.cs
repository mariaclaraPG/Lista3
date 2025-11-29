using System;
namespace CadastroLivros
{
    class Program
    {
        static void addLivro(List<Livro> listaLivros)
        {
            Livro novoLivro = new Livro();
            Console.Write("Título:");
            novoLivro.titulo = Console.ReadLine();
            Console.Write("Autor:");
            novoLivro.autor = Console.ReadLine();
            Console.Write("Ano:");
            novoLivro.ano = int.Parse(Console.ReadLine());
            Console.Write("Prateleira:");
            novoLivro.prateleira = int.Parse(Console.ReadLine());
            listaLivros.Add(novoLivro);
            Console.WriteLine("--------");

        }

        static void mostrarLivros(List<Livro> listaLivros)
        {
            int posicao = 1;
            for (int i = 0; i < listaLivros.Count; i++)
            {
                Console.WriteLine($"*** Livro {posicao}***");
                Console.WriteLine($"{listaLivros[i].titulo} - {listaLivros[i].autor} - {listaLivros[i].ano} - {listaLivros[i].prateleira}");
                posicao++;
            }

        }
        
        static bool buscarLivro(List<Livro> listaLivros, string tituloBusca)
        {
            foreach (Livro b in listaLivros)
            {
                if (b.titulo.ToUpper().Contains(tituloBusca.ToUpper()))
                {
                    Console.WriteLine("*** Dados do Livro ***");
                    Console.WriteLine($"Titulo: {b.titulo}");
                    Console.WriteLine($"Prateleira: {b.prateleira}");
                    return true;
                }

            }// fim foreach
            return false;
        }
		
		  static bool buscarano(List<Livro> listaLivros, int anoLivro)
        {
            foreach (Livro b in listaLivros)
            {
                if (anoLivro < b.ano)
                {
                    Console.WriteLine("*** Dados do Livro ***");
                    Console.WriteLine($"Titulo: {b.titulo}");
                    Console.WriteLine($"Ano: {b.ano}");
                    return true;
                }

            }// fim foreach
            return false;
        }
		
		
		
        static int buscarIndiceLivro(List<Livro> listaLivros, string tituloBusca)
        {
            for (int i = 0; i < listaLivros.Count; i++)
            {
                if (listaLivros[i].titulo.ToUpper().Equals(tituloBusca.ToUpper()))
                {
                    return i;
                }

            }// fim foreach
            return -1;
        }


        static int menu()
        {
            int opcao;
            Console.WriteLine("*** Sistema de Cadastro de Livros 4U***");
            Console.WriteLine("1- Adicionar Livro");
            Console.WriteLine("2- Mostrar Livros");
            Console.WriteLine("3- Buscar Livro");
            Console.WriteLine("4- Buscar ano");
            Console.WriteLine("0- Sair do Sistema");
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        static void salvarDados(List<Livro> listaLivros, string nomeArquivo)
        {

            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (Livro b in listaLivros)
                {
                    writer.WriteLine($"{b.titulo},{b.autor},{b.ano},{b.prateleira}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");


        }

        static void carregarDados(List<Livro> listaLivros, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');
                    Livro novaLivro = new Livro();
                    novaLivro.titulo = campos[0];
                    novaLivro.autor = campos[1];
                    novaLivro.ano = int.Parse(campos[2]);
                    novaLivro.prateleira = int.Parse(campos[3]);
                    listaLivros.Add(novaLivro);
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");

        }

        
        static void Main()
        {
            List<Livro> listaLivros = new List<Livro>();
            int opcao = 0;
            carregarDados(listaLivros, "Livros.txt");
            do
            {
                opcao = menu();
                switch (opcao)
                {
                    case 1:
                        addLivro(listaLivros);
                        break;
                    case 2:
                        mostrarLivros(listaLivros);
                        break;
                    case 3: Console.Write("Titulo do Livro:");
                        string tituloLivro = Console.ReadLine();
                        bool encontrado = buscarLivro(listaLivros, tituloLivro);
                        if (!encontrado)
                            Console.WriteLine("Livro não encontrada :(" );
                        break;
                    case 4: Console.Write("Insira o ano:");
                         int anoLivro = int.Parse(Console.ReadLine());
                         encontrado = buscarano(listaLivros, anoLivro);
                        if (!encontrado)
                            Console.WriteLine("Livro não encontrado" );
                        break;
                    case 0:
                        salvarDados(listaLivros, "Livros.txt");
                        Console.WriteLine("Até mais ;)");
                        break;
                }
                Console.ReadKey();// pausa
                Console.Clear(); // limpa a tela
            } while (opcao != 0);

        }

    }

}

