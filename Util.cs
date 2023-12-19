
using CommunityToolkit.Maui.Alerts;

namespace ExamenParcial2;


public static class Util
{
    public static async Task ShowToastAsync(string message)
    {

        var toast = Toast.Make(message);
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await toast.Show(cts.Token);
    }

}