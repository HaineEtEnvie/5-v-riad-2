using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp1.View_Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Razmer.ItemsSource = Models.Razmer.razmeri.Values;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name1 = Text1.Text.Trim();
                string name2 = Text2.Text.Trim();
                Logika.Check(name1, name2);
                var razmernost = Models.Razmer.razmeri.First(x => x.Value == Razmer.SelectedItem.ToString()).Key;
                Logika.CreateInformation(name1, name2, razmernost);
                GameWIndow gameWIndow = new();
                gameWIndow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
