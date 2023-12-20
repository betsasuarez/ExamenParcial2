using ExamenParcial2.ViewModel;

namespace ExamenParcial2.Views;

public partial class EncuestaPage: ContentPage
{
    public EncuestaPage (EncuestaViewModel encuestaViewModel)
	{
		InitializeComponent();
        BindingContext = encuestaViewModel;
    }
}