namespace WebApp_DS.Entidades
{
    public class Produtos
    {
        public int ID { get; set; }
        public string DESCRICAO { get; set; }
        public decimal VALOR { get; set; }
        public bool ATIVO { get; set; }

        public int CATEGORIAID { get; set; }
        public Categoria CATEGORIA { get; set;}
    }
}
