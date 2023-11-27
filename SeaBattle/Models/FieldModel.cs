using System;
using Avalonia.Controls;
using Avalonia.Layout;

namespace SeaBattle.Models
{
    public class FieldModel
    {
        public Button[][] Field { get; set; }

        public Grid makeLayout()
        {
            var panel = new Grid();
            panel.Name = "FieldGrid";
            for (int i = 0; i < 10; i++)
            {
                var row = new StackPanel();
                row.Orientation = Orientation.Horizontal;
                row.VerticalAlignment = VerticalAlignment.Center;
                row.HorizontalAlignment = HorizontalAlignment.Stretch;
                for (int j = 0; j < 10; j++)
                {
                    var button = new Button();
                    button.Width = 50;
                    button.Height = 50;
                    row.Children.Add(button);
                }
                panel.Children.Add(row);
            }
            return panel;
        }
    }
}