
namespace ExamenParcial2.Views;

public partial class LoginPage: ContentPage
{
    public LoginPage(Encuesta loginPageViewModel)
    {
        BindingContext = loginPageViewModel;
    }
}