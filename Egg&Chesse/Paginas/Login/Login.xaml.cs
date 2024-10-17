using Egg_Chesse.Paginas.PaginaInicial.BemVindo;
using Egg_Chesse.Paginas.PaginaInicial;

namespace Egg_Chesse.Paginas.Login;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();

        
	}

    private  void BtnLogin_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new PaginaInicial.PaginaInicial();
    }
}
