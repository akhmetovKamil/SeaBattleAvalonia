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
            FCell.Width = 41;
            FCell.Height = 41;
            ChangeState("error", x, y);
        }
        public void FCellHandler(object sender, RoutedEventArgs e)
        {
            StateProp props = (StateProp)((Button)e.Source).Tag;
            // FCell.Classes.RemoveAt();
            FCell.Classes.Remove(props.state);
            ChangeState("regular", props.x, props.y);
        }
        private static void GenFCellStatesDict()
        {
            FCellStatesDict = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> State = new Dictionary<string, string>();
            FCellStatesDict.Add("regular", State);

            Dictionary<string, string> ErrorState = new Dictionary<string, string>();
            FCellStatesDict.Add("error", ErrorState);

            Dictionary<string, string> MissState = new Dictionary<string, string>();
            FCellStatesDict.Add("miss", MissState);

            Dictionary<string, string> DisabledState = new Dictionary<string, string>();
            FCellStatesDict.Add("disabled", DisabledState);

            Dictionary<string, string> HitState = new Dictionary<string, string>();
            FCellStatesDict.Add("hit", HitState);

            Dictionary<string, string> FullHit = new Dictionary<string, string>();
            FCellStatesDict.Add("fullhit", FullHit);
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
            FCell.Classes.Set(state, true);
        }
    }
}