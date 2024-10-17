using Egg_Chesse.Models;
using Egg_Chesse.Paginas.Produto;
using Microsoft.Maui.Controls;

using System.Collections.ObjectModel;
using System.Text.Json;

namespace Egg_Chesse.Paginas.PaginaInicial.BemVindo;

public partial class BemVindo : ContentPage
{
    public class CarouselItem
    {
        public string Imagem { get; set; }

    }

    public class Botao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public Color BorderColor { get; set; } = Colors.Transparent;

        public bool Selecionado { get; set; }

    }

   

   

    public ObservableCollection<Botao> botaos = new ObservableCollection<Botao>()
        {
            new Botao{ Id = 1 ,Titulo = "Todos" , Selecionado = true},
            new Botao{Id= 2 ,Titulo = "Lanches" , Selecionado = false},
            new Botao{Id= 3 ,Titulo = "Nossos Pratos" , Selecionado = false},
            new Botao{ Id =4 ,Titulo = "Café da manha" , Selecionado = false},
        };

    // Definindo os itens do carrossel
    public ObservableCollection<CarouselItem> items = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { Imagem = "propaganda.svg" },
                new CarouselItem { Imagem = "egg.svg" },
                new CarouselItem { Imagem = "propaganda.svg" },
                new CarouselItem { Imagem = "egg.svg" },
            };

    
    //public  ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();
    ////{
    ////    new Produto { Id = 1 , NomeDoProduto = "Lanche café da manha com queijo e ovos.", Categoria="Lanches", Tempo="01-04 Minutos" , Imagem="ovocomqueijo.svg"},
    ////    new Produto { Id = 2 , NomeDoProduto = "Lanche com ovos mexidos.", Categoria="Lanches", Tempo="05-10 Minutos", Imagem = "ovosmexidos.svg"},
    ////    new Produto { Id = 3 , NomeDoProduto = "Macarrão com Queijo no Café da Manhã", Categoria="Nossos Pratos", Tempo="15-20 Minutos" , Imagem = "macarrao.svg"},
    ////    new Produto { Id = 4 , NomeDoProduto = "Ovo e queijo na caneca!", Categoria="Café da manha", Tempo="01-03 Minutos", Imagem = "ovoqueijonacaneca.svg" }
    ////};
    public BemVindo()
    {
        InitializeComponent();
        CarregarImagem();
        CarregaBotoes();
        CarregarProdutos();

    }




    private void CarregarImagem()
    {


        // Associe a lista ao binding no XAML
        BindingContext = new { Items = items };

        // Vinculando o IndicatorView ao CarouselView
        carousel.IndicatorView = indicatorView;




    }
    /// <summary>
    /// Função para Trocar a cor do botão
    /// </summary>
    /// <param name="botaoId"></param>
    public void AlternarSelecao(int botaoId)
    {
        // Iterar por todos os botões e desmarcar os que estão selecionados
        foreach (var botao in botaos)
        {
            if (botao.Selecionado)
            {
                botao.Selecionado = false;  // Desmarca o botão atualmente selecionado
                botao.BorderColor = Colors.Transparent;  // Reseta a borda
            }
        }

        // Agora marcar o botão que foi clicado (com base no Id)
        var botaoSelecionado = botaos.FirstOrDefault(b => b.Id == botaoId);
        if (botaoSelecionado != null)
        {
            botaoSelecionado.Selecionado = true;  // Marca o novo botão como selecionado
            botaoSelecionado.BorderColor = Color.FromHex("3D051B");  // Define a cor da borda do botão selecionado
        }

        // Atualiza a interface de usuário
        CVbotoes.ItemsSource = null;
        CVbotoes.ItemsSource = botaos;
    }


    private void CarregaBotoes()
    {


        CVbotoes.ItemsSource = botaos;


    }

    private async void CarregarProdutos()
    {
        using var localJson = await FileSystem.OpenAppPackageFileAsync("produtos.json"); // Pego local do arquivo

        var stream = new StreamReader(localJson);

        var conteudo = await stream.ReadToEndAsync();

        var listaDeProdutos = JsonSerializer.Deserialize<ListaDeProduto>(conteudo);


        CVProdutos.ItemsSource = listaDeProdutos.Produtos.ToList();
    }
    private void carouselBotoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Botao;
        if (selectedItem != null)
        {
            AlternarSelecao(selectedItem.Id);
        }
        // Deixar fixo no centro ao selecionar

        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var item = e.CurrentSelection[0];
            CVbotoes.ScrollTo(item, position: ScrollToPosition.Center, animate: true);
        }

    }



  
   

    private void CVProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var produtoSelecionado = CVProdutos.SelectedItem as Models.Produto;

          Navigation.PushAsync(new DetalhesProduto(produtoSelecionado.Id));
    }
}