namespace Egg_Chesse.Models
{
    public class Produto  
    {
        public int Id { get; set; }

        public string? NomeDoProduto { get; set; }

        public string? Imagem { get; set; }

        public string? Categoria { get; set; }

        public string? Descricao { get; set; }

        public string? Tempo { get; set; }

        public Chef Chef { get; set; }

        public List<ListaDeIngredientes>? ListaDeIngredientes { get; set; }
    }
}