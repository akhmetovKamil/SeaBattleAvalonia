using Avalonia.Controls;
using Avalonia.ReactiveUI;
using SeaBattle.Models;
using SeaBattle.ViewModels;

namespace SeaBattle.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{

    public MainWindow()
    {
        InitializeComponent();
        // var temp = new FieldModel();
        // Test.Children.Add(ViewModel!.Greeting);
    }
}