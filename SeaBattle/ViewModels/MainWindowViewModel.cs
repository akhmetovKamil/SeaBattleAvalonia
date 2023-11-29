using Avalonia.Controls;
using Avalonia.Diagnostics.Screenshots;
using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public FieldModel Field { get; }

    public StackPanel FieldGrid { get; }
    public MainWindowViewModel()
    {
        Field = new FieldModel();
        FieldGrid = Field.makeLayout();
    }
}