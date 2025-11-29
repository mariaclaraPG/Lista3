using System; 
namespace CadastroEletro 
{ 
    class Program 
    { 
        static void addEletro(List<Eletro> listaEletros) 
        { 
            Eletro novoEletro = new Eletro(); 
            Console.Write("Entre com o nome:"); 
            novoEletro.nome = Console.ReadLine(); 
            Console.Write("Entre com a potencia:"); 
            novoEletro.potencia = double.Parse(Console.ReadLine()); 
            Console.Write("Entre com a tempo medio de uso diario:"); 
            novoEletro.tempoMedioUsoDiario = 
double.Parse(Console.ReadLine()); 
            listaEletros.Add(novoEletro); 
        } 
 
        static void mostrarEletros(List<Eletro> listaEletros) 
        { 
            foreach (Eletro e in listaEletros) 
            { 
                Console.WriteLine("Nome: " + e.nome); 
                Console.WriteLine("Potencia: " + e.potencia); 
                Console.WriteLine("Tempo Medio de Uso Diario: " + e.tempoMedioUsoDiario); 
                Console.WriteLine("-----------------------------"); 
            } 
        } 
     
 
        static bool buscarEletro(List<Eletro> listaEletros, string nomeBusca) 
        { 
            foreach(Eletro e in listaEletros) 
            { 
                if(e.nome.ToUpper().Contains(nomeBusca.ToUpper())) 
                { 
                    Console.WriteLine("*** Eletrodomestico ***"); 
                    Console.WriteLine($"Nome:{e.nome}"); 
                    Console.WriteLine($"Potência:{e.potencia}"); 
                    Console.WriteLine($"Tempo médio:{e.tempoMedioUsoDiario}"); 
                    return true; 
                } 
            } 
            return false; 
        } 
 
        static bool buscarPotencia(List<Eletro> listaEletros, double potenciaBusca) 
        { 
            bool encontrou = false; 
            foreach(Eletro e in listaEletros) 
            { 
                if(e.potencia>=potenciaBusca) 
                { 
                    Console.WriteLine("*** Eletrodomestico ***"); 
                    Console.WriteLine($"Nome:{e.nome}"); 
                    Console.WriteLine($"Potência:{e.potencia}"); 
                    Console.WriteLine($"Tempo médio:{e.tempoMedioUsoDiario}"); 
                    encontrou = true; 
                } 
            } 
            return encontrou; 
        } 
        
        static double consumoTotalKwDia(List<Eletro> listaEletros) 
        { 
            double total = 0; 
            foreach(Eletro e in listaEletros) 
            { 
                total+= e.potencia * e.tempoMedioUsoDiario; 
            } 
            return total; 
        } 
 
        static void salvarEletros(List<Eletro> listaEletros) 
        { 
            using (StreamWriter sw = new StreamWriter("eletros.txt")) 
            { 
                foreach (Eletro e in listaEletros) 
                { 
                    sw.WriteLine(e.nome + ";" + e.potencia + ";" + e.tempoMedioUsoDiario); 
                } 
            } 
        } 
 
        static void carregarEletros(List<Eletro> listaEletros) 
        { 
            if (File.Exists("eletros.txt")) 
            { 
                using (StreamReader sr = new StreamReader("eletros.txt")) 
                { 
                    string line; 
                    while ((line = sr.ReadLine()) != null) 
                    { 
                        string[] parts = line.Split(';'); 
                        Console.WriteLine(parts.Length); 
                        Eletro e = new Eletro(); 
                        e.nome = parts[0]; 
                        e.potencia = double.Parse(parts[1]); 
                        e.tempoMedioUsoDiario = double.Parse(parts[2]); 
                        listaEletros.Add(e); 
                    } 
                } 
            } 
        } 
 
        static int menu() 
        { 
            Console.WriteLine("1 - Adicionar Eletrodomestico"); 
            Console.WriteLine("2 - Mostrar Eletrodomesticos"); 
            Console.WriteLine("3 - Buscar pelo nome"); 
            Console.WriteLine("4 - Calcular Consumo diário e mensal"); 
            Console.WriteLine("5 - Calcular Custo total por eletrodomestico"); 
            Console.WriteLine("0 - Sair"); 
            Console.Write("Escolha uma opcao: "); 
            return int.Parse(Console.ReadLine()); 
        } 
 
        static void Main() 
        { 
            List<Eletro> listaEletros = new List<Eletro>(); 
            carregarEletros(listaEletros); 
            int opcao; 
            do 
            { 
                opcao = menu(); 
                switch (opcao) 
                { 
                    case 1: 
                        addEletro(listaEletros); 
                        break; 
                    case 2: 
                        mostrarEletros(listaEletros); 
                        break; 
                    case 3: Console.Write("Eletrodomestico para busca:"); 
                            string nomeEletro = Console.ReadLine(); 
                        bool encontrou = buscarEletro(listaEletros, nomeEletro); 
                        if(encontrou==false) //(!encontrou) 
                            Console.WriteLine("Eletrodomestico não encontrado!"); 
                        break; 
                    case 4: Console.Write("Potência para busca:"); 
                        double potenciaBusca = double.Parse(Console.ReadLine()); 
                          encontrou = buscarPotencia(listaEletros, potenciaBusca); 
                          if (!encontrou) //(encontrou==false) 
                            Console.WriteLine("Eletrodomestico que atende ao criterio não encontrado:("); 
                        break;   
                    case 5: Console.Write("Valor do Kw/h em R$:"); 
                            double valorKw = double.Parse(Console.ReadLine()); 
                            double consumoKw = consumoTotalKwDia(listaEletros); 
                            Console.WriteLine($"Consumo diário em Kw:{consumoKw:F2}"); 
                            Console.WriteLine($"Consumo diário em R$:{(valorKw * consumoKw):F2}"); 
                        break; 
                    case 0: Console.WriteLine("Saindo..."); 
                        salvarEletros(listaEletros); 
                        break;     
                } 
 
 
                Console.ReadKey(); 
                Console.Clear(); 
            } while (opcao != 0); 
		}
			}
}
