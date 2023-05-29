using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using WpfApp6.ViewModels.Base;
using WpfApp6.Models;

namespace WpfApp6.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private Game game;
        public Game Game 
        {
            get => game;
            set => Set(ref game, value);
        }
        
        public MainWindowViewModel()
        {               
            game = new Game();
            Size = "15";
        }

        ObservableCollection<ObservableCollection<Field>> f = new();
        public ObservableCollection<ObservableCollection<Field>> F
        {
            get => f;
            set => Set(ref f, value);
        }

        DataTable field;
        public DataTable Field
        {
            get => field;
            set => Set(ref field, value);            
        }

        int size = 15;
        public string Size
        {
            get => size.ToString();
            set 
            {
                var key = value.Trim('[').Trim(']').Split(',').FirstOrDefault();

                if (int.TryParse(key, out int newSize))
                {
                    Set(ref size, newSize);
                    ResetDataTable();
                    ResetF();
                }
            }
        }

        private void ResetDataTable()
        {
            DataTable newField = new();
            for (int i = 0; i < size; i++)
                newField.Columns.Add();

            for (int i = 0; i < size; i++)
            {
                object[] row = new object[size];
                for (int j = 0; j < size; j++)
                    row[j] = i * 10 + j;
                newField.Rows.Add(row);
            }

            Field = newField;
        }

        public void ResetF()
        {
            f.Clear(); 
            ObservableCollection<ObservableCollection<Field>> newf = new();
            for (int i = 0; i < size; i++)
            {
                ObservableCollection<Field> fRow = new();
                for (int j = 0; j < size; j++)
                    fRow.Add(new Field() {I = i, J = j });
                newf.Add(fRow);
            }

            F = newf;
        }
    }
}
