using SaboresdeMama.Models;

namespace SaboresdeMama;

[QueryProperty(nameof(Receta), "Receta")]
// Asegúrate de que dice "public PARTIAL class"
public partial class RecetaDetallePage : ContentPage
{
    Receta _receta;
    public Receta Receta
    {
        get => _receta;
        set
        {
            _receta = value;
            OnPropertyChanged();
            CargarDatosReceta();
        }
    }

    public RecetaDetallePage()
    {
        InitializeComponent(); // Este error desaparecerá
    }

    private void CargarDatosReceta()
    {
        if (Receta != null)
        {
            // Todos estos errores desaparecerán
            NombreLabel.Text = Receta.Nombre;
            IngredientesLabel.Text = Receta.Ingredientes;
            ProcedimientoLabel.Text = Receta.Procedimiento;
        }
    }
}