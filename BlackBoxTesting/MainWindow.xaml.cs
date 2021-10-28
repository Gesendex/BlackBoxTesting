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
            Point p2;
            Point p1;
            Point p3;
            Point p4;
            try
            {
                p2 = new Point(double.Parse(TxbP1x.Text), double.Parse(TxbP1y.Text));
                p1 = new Point(double.Parse(TxbP2x.Text), double.Parse(TxbP2y.Text));
                p3 = new Point(double.Parse(TxbP3x.Text), double.Parse(TxbP3y.Text));
                p4 = new Point(double.Parse(TxbP4x.Text), double.Parse(TxbP4y.Text));
            }
            catch (Exception)
            {
                return;
            }
            
            if (ExpressionCalculator.IsSquare(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Square";
            }
            else if (ExpressionCalculator.IsRectangle(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Rectangle";
            }
            else if (ExpressionCalculator.IsRhomb(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Rhomb";
            }
            else if (ExpressionCalculator.IsParallelogram(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Parallelogram";
            }
            else if (ExpressionCalculator.IsIsoscelesTrapezoid(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Isosceles trapezoid";
            }
            else if (ExpressionCalculator.IsRectangularTrapezoid(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Rectangular trapezoid";
            }
            else if (ExpressionCalculator.IsTrapezoid(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Trapezoid";
            }
            else
            {
                TxbResult2.Text = "Quadrilateral";
            }
        }

        private void BtnRes1_Click(object sender, RoutedEventArgs e)
        {
            double c = 0;
            if ( double.TryParse(TxbB.Text, out double b))
            {
                string txbAtext = ""; 
                if (!double.TryParse(TxbA.Text, out double a))
                {
                    for (int i = 0; i < TxbA.Text.Length; i++)
                    {
                        if (char.IsDigit(TxbA.Text[i]))
                        {
                            txbAtext += TxbA.Text[i];
                        }
                    }
                    double.TryParse( txbAtext,out a);
                }
                if (TxbC.Text.Length == 0)
                {
                    
                }
                else if(!double.TryParse(TxbC.Text, out c))
                {
                    return;
                }
                ExpressionCalculator.Calculate(a, b, c, out double x1, out double x2);
                TxbResult1.Text = $"x1 = {x1:N2}\n" + $"x2 = {x2:N2}";
            }
        }

        private void Txb_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key <= Key.D0 || e.Key >= Key.D9) && e.Key != Key.OemMinus)
            { 
                e.Handled = true;
            }
        }

        private void TxbA_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key <= Key.D0 || e.Key >= Key.D9)&& e.Key != Key.OemMinus)
            {
                e.Handled = true;
            }
            if (e.Key >= Key.A && e.Key <= Key.Z)
                e.Handled = false;
        }
    }
}
