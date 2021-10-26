using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackBoxTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRes2_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, x3, x4, y1, y2, y3, y4;
            x1 = double.Parse(TxbP1x.Text);
            x2 = double.Parse(TxbP2x.Text);
            x3 = double.Parse(TxbP3x.Text);
            x4 = double.Parse(TxbP4x.Text);
            y1 = double.Parse(TxbP1y.Text);
            y2 = double.Parse(TxbP2y.Text);
            y3 = double.Parse(TxbP3y.Text);
            y4 = double.Parse(TxbP4y.Text);
            Point p1, p2, p3, p4;
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
            p3 = new Point(x3, y3);
            p4 = new Point(x4, y4);
            if (ExpressionCalculator.IsSquare(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Square";
            }
            else if (ExpressionCalculator.IsRomb(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Romb";
            }
            else if (ExpressionCalculator.IsParallelogram(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Parallelogram";
            }
        }

        private void BtnRes1_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxbA.Text, out double a) && double.TryParse(TxbB.Text, out double b) && double.TryParse(TxbC.Text, out double c))
            {
                ExpressionCalculator.Calculate(a, b, c, out double x1, out double x2);
                TxbResult1.Text = $"x1 = {x1:N2}\n" + $"x2 = {x2:N2}";
            }
        }
    }
}
