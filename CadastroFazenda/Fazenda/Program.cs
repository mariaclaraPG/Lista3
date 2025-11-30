using System;
namespace Fazenda
{
    class Program
    {

          static void registrarGado(List<Fazenda> listaGado)
        {
            Fazenda novoGado = new Fazenda();
            Console.Write("Código: ");
            novoGado.codigo = int.Parse(Console.ReadLine());
            Console.Write("Leite em litros: ");
            novoGado.leite = int.Parse(Console.ReadLine());
            Console.Write("alim: ");
            novoGado.alim = int.Parse(Console.ReadLine());
			novoGado.abate = "N";
            novoGado.Nasc.mes = 0;
            novoGado.Nasc.ano = 0;
            listaGado.Add(novoGado);
        }
		
		 static void salvarDados(List<Fazenda> listaGado, string nomeArquivo)
        {

            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (Fazenda g in listaGado)
                {
                  writer.WriteLine($"{g.codigo};{g.leite};{g.alim};{g.abate};{g.Nasc.mes};{g.Nasc.ano}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");


        }
		
		
		  static void mostrarGado(List<Fazenda> listaGado)
        {
            int posicao = 1;
            for (int i = 0; i < listaGado.Count; i++)
            {
                Console.WriteLine($"*** Cabeça de gado {posicao}***");
                Console.WriteLine($"{listaGado[i].codigo};{listaGado[i].leite};{listaGado[i].alim};{listaGado[i].Nasc.mes};{listaGado[i].Nasc.ano}");
                posicao++;
            }

        }
		
		
		 static void prodLeite(List<Fazenda> listaGado)
         {
            double soma=0;
            foreach (Fazenda g in listaGado)
            {
                soma+=g.leite;
            }
            Console.WriteLine($"Produção semanal de leite: {soma*7}");
        }
		
		 static void consumoAlim(List<Fazenda> listaGado)
           {
            double soma=0;
            foreach (Fazenda g in listaGado)
            {
                soma+=g.alim;
            }
            Console.WriteLine($"Gasto semanal de alimento: {soma*7}");
        }

		 static bool consultaAbate(List<Fazenda> listaGado)
        {
            bool confirma = false;
            foreach (Fazenda g in listaGado)
            {
                if (g.abate == "S")
                {
                    Console.WriteLine($"Código {g.codigo}");
                    confirma = true;
                }
            }
            return confirma;
        }
		

        static void carregarDados(List<Fazenda> listaGado, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                   string[] campos = linha.Split(',');
                    Fazenda novoGado = new Fazenda();
                    novoGado.codigo = int.Parse(campos[0]);
                    novoGado.leite = int.Parse(campos[1]);
                    novoGado.alim = int.Parse(campos[2]);
                    novoGado.abate = campos[3];
                    novoGado.Nasc.mes = int.Parse(campos[4]);
                    novoGado.Nasc.ano = int.Parse(campos[5]);
					if(((2025 - novoGado.Nasc.ano) > 5) || (novoGado.leite < 40))
					{
						novoGado.abate = "S";
					}
					else{
						novoGado.abate = "N";
					}
				
                    listaGado.Add(novoGado);
				}
                    Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");

        }

		

//////////////////////////////////////////////////////////////////////////////////
        static int menu()
        {
            int opcao;
            Console.WriteLine("*** Sistema de Cadastro de Jogos ***");
            Console.WriteLine("1- Registrar cabeça de gado");
			Console.WriteLine("2- Mostrar cabeças de gado");
			Console.WriteLine("3- Mostrar produção de leite semanal");
			Console.WriteLine("4- Mostrar gasto de alimento semanal");
			Console.WriteLine("4- Mostrar animais para o abate");
            Console.WriteLine("0- Sair do Sistema");
           
      
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        
        static void Main()
        {
            List<Fazenda> listaGado = new List<Fazenda>();
            int opcao = 0;
            carregarDados(listaGado, "fazenda.txt");
            do
            {
                opcao = menu();
                switch (opcao)
                {
					
                    case 1:
                        registrarGado(listaGado);
                        break;
					case 2:
                        mostrarGado(listaGado);
                        break;
					case 3:
                        prodLeite(listaGado);
                        break;
					case 4:
                        consumoAlim(listaGado);
                        break;
					case 5:
                        consultaAbate(listaGado);
                        break;
                    case 0:
                        salvarDados(listaGado, "fazenda.txt");
                        Console.WriteLine("Até mais ;)");
                        break;
                }
                Console.ReadKey();
                Console.Clear(); 
            } while (opcao != 0);

        }

    }

}

