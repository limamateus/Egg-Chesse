using Egg_Chesse.Paginas.Login;
using Egg_Chesse.Paginas.Produto;

namespace Egg_Chesse
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }
    }
}
