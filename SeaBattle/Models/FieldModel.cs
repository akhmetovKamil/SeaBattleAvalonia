using System;
using Avalonia.Controls;
using Avalonia.Layout;

namespace SeaBattle.Models
{
    public class FieldModel
    {
        public FCellModel[][] Field { get; set; }
        public FieldModel()
        {
            Field = new FCellModel[10][];
            for (int i = 0; i < 10; i++)
            {
                Field[i] = new FCellModel[10];
                for (int j = 0; j < 10; j++)
                {
                    Field[i][j] = new FCellModel(i, j);
                }
            }
        }

        public StackPanel makeLayout()
        {
            // var panel = new Grid();
            var panel = new StackPanel();
            panel.Name = "FieldGrid";
            // panel.RowDefinitions = new RowDefinitions("* * * * * * * * * *");
            for (int i = 0; i < 10; i++)
            {
                var row = new StackPanel();
                row.Orientation = Orientation.Horizontal;
                row.VerticalAlignment = VerticalAlignment.Center;
                row.HorizontalAlignment = HorizontalAlignment.Stretch;
                for (int j = 0; j < 10; j++)
                {
                    row.Children.Add(Field[i][j].FCell);
                }
                panel.Children.Add(row);
            }
            return panel;
        }
    }
}