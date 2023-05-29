using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp6.Infrastructure.Commands.Base;
using WpfApp6.Models;
using WpfApp6.ViewModels;

namespace WpfApp6.Infrastructure.Commands
{
    class FuckCommand : Command
    {
        private const int WIN_LENGTH = 5; // Длина выигрышной последовательности
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            Field field = parameters[0]  as Field;
            MainWindowViewModel mwvm = parameters[1] as MainWindowViewModel;
            if (field == null || field.State != "")
            {
                return;
            }
            
            field.State = mwvm.Game.Move;

            // Поиск нажатой кнопки для изменения состояния
            foreach (var collection in mwvm.F)
            {
                foreach (var item in collection)
                {
                    if (item.I == field.I && item.J == field.J)
                    {
                        item.State = field.State;
                    }
                }
            }
            mwvm.Game.Move = mwvm.Game.Move == "X" ? "0" : "X";
            
            CheckWin(field.State, mwvm);
        }
        
         private void CheckWin(string state, MainWindowViewModel mwwm)
        {
            // Проверка победителя
            if (CheckForWinner(mwwm.F))
            {
                MessageBox.Show($"{state} победили!");
                ResetGame(mwwm);
            }
        }

        static bool CheckForWinner( ObservableCollection<ObservableCollection<Field>> f)
        {
            // Проверка горизонтали
            for (int i = 0; i < f.Count; i++)
            {
                for (int j = 0; j <= f.Count - WIN_LENGTH; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);
                        
                        var next = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j + k);
                        
                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }

            // Проверка вертикали
            for (int i = 0; i <= f.Count - WIN_LENGTH; i++)
            {
                for (int j = 0; j < f.Count; j++)
                {   
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);
                        
                        var next = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i + k))?.FirstOrDefault(x => x.J == j);
                        
                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }

            // Проверка диагонали слева направо
            for (int i = 0; i <= f.Count - WIN_LENGTH; i++)
            {
                for (int j = 0; j <= f.Count - WIN_LENGTH; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);
                        
                        var next = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i + k))?.FirstOrDefault(x => x.J == j + k);
                        
                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }

            // Проверка диагонали справа налево
            for (int i = 0; i <= f.Count - WIN_LENGTH; i++)
            {
                for (int j = WIN_LENGTH - 1; j < f.Count; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);
                        
                        var next = f.FirstOrDefault(x =>
                            x.Any(y => y.I == i + k))?.FirstOrDefault(x => x.J == j - k);
                        
                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }
            return false;
        }
        static void ResetGame(MainWindowViewModel mwwm)
        {
            // сброс ходов 
            mwwm.Game.Move = "X";
            mwwm.Size = mwwm.Size;
        }
    }
}
