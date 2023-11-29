using System;
using System.Collections.Generic;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using ReactiveUI;

namespace SeaBattle.Models
{
    public class FCellModel
    {
        public Button FCell { get; set; }
        private static Dictionary<string, Dictionary<string, string>> FCellStatesDict;
        public FCellModel(int x, int y)
        {
            FCell = new Button();
            GenFCellStatesDict();
            // Нам надо отдельно создать файл где определить стейт
            // типо регуляр=такой то цвет и бордер
            // под
            // FCell.Command = pnlButtons.AddHandler(Button.Click, new RoutedEventHandler(DoSomething));
            FCell.Click += FCellHandler;
            FCell.Width = 50;
            FCell.Height = 50;
            ChangeState("regular", x, y);
        }
        public void FCellHandler(object sender, RoutedEventArgs e)
        {
            StateProp props = (StateProp)((Button)e.Source).Tag;
            ChangeState("error", props.x, props.y);
        }
        private static void GenFCellStatesDict()
        {
            FCellStatesDict = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> State = new Dictionary<string, string>();
            State.Add("bg", "#61AAFF");
            FCellStatesDict.Add("regular", State);
            Dictionary<string, string> StateErr = new Dictionary<string, string>();
            StateErr.Add("bg", "#FF3838");
            FCellStatesDict.Add("error", StateErr);
        }

        public class StateProp
        {
            public int x;
            public int y;
            public string state;
            public StateProp(int x, int y, string state)
            {
                this.x = x;
                this.y = y;
                this.state = state;
            }
        }

        public void ChangeState(string state, int x, int y)
        {

            FCell.Tag = new StateProp(x, y, state);
            string colour = FCellStatesDict[state]["bg"];
            FCell.Background = new SolidColorBrush(Color.FromRgb(
            Convert.ToByte(colour.Substring(1, 2), 16),
            Convert.ToByte(colour.Substring(3, 2), 16),
            Convert.ToByte(colour.Substring(5, 2), 16)));
        }
    }
}