using SaboresdeMama.Models;
using SaboresdeMama.Services;

namespace SaboresdeMama;

// Asegúrate de que dice "public PARTIAL class"
public partial class AgregarRecetaPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public AgregarRecetaPage(DatabaseService databaseService)
    {
        InitializeComponent(); // Este error desaparecerá
        _databaseService = databaseService;
    }

    private async void OnGuardarRecetaClicked(object sender, EventArgs e)
    {
        // Todos estos errores desaparecerán
        if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
            string.IsNullOrWhiteSpace(IngredientesEditor.Text) ||
            string.IsNullOrWhiteSpace(ProcedimientoEditor.Text))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        var nuevaReceta = new Receta
        {
            Nombre = NombreEntry.Text,
            Ingredientes = IngredientesEditor.Text,
            Procedimiento = ProcedimientoEditor.Text
        };

        await _databaseService.AddRecetaAsync(nuevaReceta);

        await DisplayAlert("Éxito", "Receta guardada correctamente.", "OK");
        await Shell.Current.GoToAsync("..");
    }
}