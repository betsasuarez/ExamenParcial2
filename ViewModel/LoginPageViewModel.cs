using CommunityToolkit.Maui.Alerts;
using ExamenParcial2.Models;
using ExamenParcial2.Views;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ExamenParcial2.ViewModel;

public class LoginPageViewModel : INotifyPropertyChanged
{

    #region "Properties"

    public UsuarioRegistro Usuario { get; set; }

    public Command LoginCommand { get; set; }

    #endregion

    public LoginPageViewModel()
    {
        Usuario = new UsuarioRegistro();
        LoginCommand = new Command(LoginAsync);
    }

    #region "Logic"

    private async void LoginAsync()
    {
        if (string.IsNullOrEmpty(Usuario.Email) || !IsAValidEmail(Usuario.Email.ToLower()))
        {
            await Util.ShowToastAsync("Ingrese un Email Válido");
            return;
        }

        if (string.IsNullOrEmpty(Usuario.Password))
        {
            await Util.ShowToastAsync("Ingrese una Contraseña Válida");
            return;
        }

        var loginData = GetLoginData();

        if (loginData != null && !loginData.Any())
        {
            await Util.ShowToastAsync("Configure usuarios");
            return;
        }

        var loginDataEmail = loginData.FirstOrDefault(x => x.Key == Usuario.Email);

        if (loginDataEmail.Equals(default(KeyValuePair<string, string>)))
        {
            await Util.ShowToastAsync($"El correo {Usuario.Email} no existe");
            return;
        }

        if (loginDataEmail.Value != Usuario.Password)
        {
            await Util.ShowToastAsync($"Contraseña Incorrecta");
            return;
        }

        Settings.IsAuthenticated = true;
        Settings.Email = Usuario.Email;

        await Shell.Current.GoToAsync($"///{nameof(EncuestaPage)}");
    }

    private List<KeyValuePair<string, string>> GetLoginData()
    {
        return new List<KeyValuePair<string, string>>
            {
                new("gustavo@gmail.com", "12345."),
                new("betsabe@mail.com", "Papa1234")
            };
    }

    private bool IsAValidEmail(string email)
    {
        return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }

    private async Task ShowToastAsync(string message)
    {
        // implement your logic here
        var toast = Toast.Make(message);
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        await toast.Show(cts.Token);
    }

    #endregion

    public event PropertyChangedEventHandler PropertyChanged;
}