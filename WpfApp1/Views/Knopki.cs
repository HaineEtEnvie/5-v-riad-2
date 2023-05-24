using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Views
{
    public class Knopki
    {
        public static Label label1 = new()
        {
            Name = "Label1",
            Content = "5 в ряд",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(24, 10, 0, 0),
            Height = 85,
            Width = 506,
            FontSize = 48,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
        };

        public static Label igrok1 = new()
        {
            Name = "igrok1",
            Content = Models.Information.Player1.Name,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(1114, 0, 0, 0),
            Height = 100,
            Width = 230,
            FontSize = 26,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
        };

        public static Label igrok2 = new()
        {
            Name = "igrok2",
            Content = Models.Information.Player2.Name,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(1360, 0, 0, 0),
            Height = 100,
            Width = 230,
            FontSize = 26,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
        };

        public static Label label2 = new()
        {
            Name = "label2",
            Content = "Первый игрок",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(1114, 0, 0, 0),
            Height = 32,
            Width = 230,
            FontSize = 16,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
        };

        public static Label label3 = new()
        {
            Name = "label3",
            Content = "Второй игрок",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(1360, 0, 0, 0),
            Height = 32,
            Width = 230,
            FontSize = 16,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
        };

    }
}
