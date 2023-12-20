namespace ExamenParcial2.Models;

public static class Settings
{
    public static bool IsAuthenticated
    {
        get => Preferences.Default.Get(nameof(IsAuthenticated), false);
        set => Preferences.Default.Set(nameof(IsAuthenticated), value);
    }

    public static string Email
    {
        get => Preferences.Default.Get(nameof(Email), string.Empty);
        set => Preferences.Default.Set(nameof(Email), value);
    }

    public static string Password
    {
        get => Preferences.Default.Get(nameof(Password), string.Empty);
        set => Preferences.Default.Set(nameof(Password), value);
    }

    public static int RespuestaEncuesta1
    {
        get => Preferences.Get(nameof(RespuestaEncuesta1), 0);
        set => Preferences.Set(nameof(RespuestaEncuesta1), value);
    }

    public static double RespuestaEncuesta2
    {
        get => Preferences.Get(nameof(RespuestaEncuesta2), 0.0);
        set => Preferences.Set(nameof(RespuestaEncuesta2), value);
    }

    public static int RespuestaEncuesta3
    {
        get => Preferences.Get(nameof(RespuestaEncuesta3), 0);
        set => Preferences.Set(nameof(RespuestaEncuesta3), value);
    }
}