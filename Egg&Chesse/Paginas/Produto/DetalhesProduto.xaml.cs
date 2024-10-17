using System.Collections.ObjectModel;
using System.Text.Json;
using Egg_Chesse.Models;
namespace Egg_Chesse.Paginas.Produto;

public partial class DetalhesProduto : ContentPage
{
    public int Id { get; set; }

   
    public DetalhesProduto(int id)
	{
        this.Id = id;

        CarregarDados();

        InitializeComponent();

    }




	private async void CarregarDados()
	{

        using var localJson = await FileSystem.OpenAppPackageFileAsync("produtos.json"); // Pego local do arquivo

        var stream = new StreamReader(localJson);

        var conteudo = await stream.ReadToEndAsync();

        var listaDeProdutos = JsonSerializer.Deserialize<ListaDeProduto>(conteudo);

        var xProduto =  listaDeProdutos?.Produtos.FirstOrDefault(x => x.Id == Id);

        CVIngredientes.ItemsSource = xProduto?.ListaDeIngredientes?.ToList();

        BindingContext = xProduto;

        LbChefNome.Text = xProduto.Chef.Nome;

        LbDescricao.Text = xProduto.Chef.Descricao;
       
        
    }
}