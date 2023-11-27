using Avalonia.Controls;
using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public FieldModel Field { get; }

    public Grid FieldGrid { get; }
    public MainWindowViewModel()
    {
        Field = new FieldModel();
        FieldGrid = Field.makeLayout();
    }
}