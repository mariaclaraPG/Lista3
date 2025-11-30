namespace Fazenda
{
    class Fazenda
    {
        public int codigo;
		public int leite;
		public int alim;
        public string abate;
        
        public Nasc Nasc = new Nasc();
    }
    public class Nasc
    {
       	public int mes;
		public int ano;
    }
}