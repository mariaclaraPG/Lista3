namespace CadastroJogos
{
    class Jogo
    {
        public string titulo;
        public string console;
        public int ano;
        public int ranking;
        
        public Emprestimo Emprestimo = new Emprestimo();
    }
    public class Emprestimo
    {
        public string data;
        public string nomePessoa;
        public bool emprestado;
    }
}