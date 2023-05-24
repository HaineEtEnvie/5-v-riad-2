using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class GameWIndow : Window
    {
        private readonly Button[,] buttons; // Массив кнопок
        private bool isPlayer1Turn = true; // Ход игрока
        private const int WIN_LENGTH = 5; // Длина выигрышной последовательности
        public GameWIndow()
        {
            InitializeComponent();
            // создание грида и таблицы из кнопок
            Grid grid = new();
            RowDefinition qwe = new(){Height = new GridLength(100)};
            grid.RowDefinitions.Add(qwe);

            Grid.SetRow(Views.Knopki.label1, 0);
            Grid.SetColumnSpan(Views.Knopki.label1, Models.Information.Razmernost);
            grid.Children.Add(Views.Knopki.label1);
            
            Grid.SetRow(Views.Knopki.igrok1, 0);
            Grid.SetColumnSpan(Views.Knopki.igrok1, Models.Information.Razmernost);
            grid.Children.Add(Views.Knopki.igrok1);            
            
            Grid.SetRow(Views.Knopki.igrok2, 0);
            Grid.SetColumnSpan(Views.Knopki.igrok2, Models.Information.Razmernost);
            grid.Children.Add(Views.Knopki.igrok2);             
            
            Grid.SetRow(Views.Knopki.label2, 0);
            Grid.SetColumnSpan(Views.Knopki.label2, Models.Information.Razmernost);
            grid.Children.Add(Views.Knopki.label2);            
            
            Grid.SetRow(Views.Knopki.label3, 0);
            Grid.SetColumnSpan(Views.Knopki.label3, Models.Information.Razmernost);
            grid.Children.Add(Views.Knopki.label3); 

            for (int i = 0; i < Models.Information.Razmernost; i++)
            {
                RowDefinition row = new(){Height = new GridLength(1, GridUnitType.Star)};
                grid.RowDefinitions.Add(row);

                ColumnDefinition col = new(){Width = new GridLength(1, GridUnitType.Star)};
                grid.ColumnDefinitions.Add(col);
            }

            buttons = new Button[Models.Information.Razmernost, Models.Information.Razmernost];

            for (int i = 0; i < Models.Information.Razmernost; i++)
            {
                for (int j = 0; j < Models.Information.Razmernost; j++)
                {
                    Button button = new(){Content = ""};
                    button.Click += Button_Click; 
                    Grid.SetRow(button, i+1); 
                    Grid.SetColumn(button, j);
                    Grid.SetRowSpan(button, 1);
                    grid.Children.Add(button);
                    buttons[i, j] = button; 
                }
            }

            this.Content = grid;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            // Если кнопка уже нажата, выходим
            if (button.Content.ToString() != "") return;

            // чередование X и 0 для ходов
            if (isPlayer1Turn)
            {
                button.Content = "X";
                Views.Knopki.igrok1.Foreground = Brushes.Red;
                Views.Knopki.igrok2.Foreground = Brushes.Black;

            }
            else
            {
                Views.Knopki.igrok1.Foreground = Brushes.Black;
                Views.Knopki.igrok2.Foreground = Brushes.Red;
                button.Content = "O";
            }

            // Проверка победителя
            if (CheckForWinner())
            {
                MessageBox.Show($"{(isPlayer1Turn ? Models.Information.Player1.Name : Models.Information.Player2.Name)} победил(а)!");
                ResetGame();
                return;
            }
            
            // Переключаем ход игрока
            isPlayer1Turn = !isPlayer1Turn;
        }

        private bool CheckForWinner()
        {
            // Проверка горизонтали
            for (int i = 0; i < Models.Information.Razmernost; i++)
            {
                for (int j = 1; j <= Models.Information.Razmernost - WIN_LENGTH; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        if (buttons[i, j + k].Content.ToString() != buttons[i, j].Content.ToString() || buttons[i, j].Content.ToString() == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }

            // Проверка вертикали
            for (int i = 0; i <= Models.Information.Razmernost - WIN_LENGTH; i++)
            {
                for (int j = 0; j < Models.Information.Razmernost; j++)
                {   
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        if (buttons[i + k, j].Content.ToString() != buttons[i, j].Content.ToString() || buttons[i, j].Content.ToString() == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }

            // Проверка диагонали слева направо
            for (int i = 0; i <= Models.Information.Razmernost - WIN_LENGTH; i++)
            {
                for (int j = 0; j <= Models.Information.Razmernost - WIN_LENGTH; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        if (buttons[i + k, j + k].Content.ToString() != buttons[i, j].Content.ToString() || buttons[i, j].Content.ToString() == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }

            // Проверка диагонали справа налево
            for (int i = 0; i <= Models.Information.Razmernost - WIN_LENGTH; i++)
            {
                for (int j = WIN_LENGTH - 1; j < Models.Information.Razmernost; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        if (buttons[i + k, j - k].Content.ToString() != buttons[i, j].Content.ToString() || buttons[i, j].Content.ToString() == "")
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
        private void ResetGame()
        {
            // очистка текста
            foreach ( Button button in buttons )
            {
                button.Content = "";
            }
            // сброс ходов 
            isPlayer1Turn = true;
        }
    }
}
