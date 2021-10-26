using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackBoxTesting
{
    public static class ExpressionCalculator
    {
        public static void Calculate(double a, double b, double c, out double x1, out double x2)
        {
            x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
        }
        /// <summary>
        /// Скалярное произведение вектора
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns> 
        public static double GetSkalyar(Point v1, Point v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        /// <summary>
        /// Расстояние между точками
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetLenght(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        /// <summary>
        /// Модуль вектора
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static double GetModule(Point v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }
        /// <summary>
        /// Угол между векторами
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetAngle(Point v1, Point v2)
        {
            return Math.Acos(GetSkalyar(v1, v2) / (GetModule(v1) * GetModule(v2)));
        }
        /// <summary>
        /// Находит вектор прямой заданной двумя точками
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point GetVector(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        /// <summary>
        /// Проверка на коллинеарность векторов
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool IsColleniar(Point v1, Point v2)
        {
            if (v1.Y == 0 || v2.Y == 0)
                return v1.Y / v1.X == v2.Y / v2.X;
            else
                return v1.X / v1.Y == v2.X / v2.Y;
        }
        /// <summary>
        /// Проверка на ромб
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsRomb(Point a, Point b, Point c, Point d)
        {
            double ab = GetLenght(a,b), bc = GetLenght(b, c), cd = GetLenght(c, d), da = GetLenght(d, a);
            return ab == bc && bc == cd && cd == da;
        }
        /// <summary>
        /// Проверка на квадрат
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsSquare(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(b, a);
            Point v2 = GetVector(b, c);
            Point v3 = GetVector(c, b);
            Point v4 = GetVector(c, d);
            return IsPryamougolnik(a, b, c, d) && IsRomb(a, b, c, d);
        }
     
        /// <summary>
        /// Проверка на парралелограм
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsParallelogram(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(a, b);
            Point v2 = GetVector(c, d);
            Point v3 = GetVector(b, c);
            Point v4 = GetVector(d, a);
            return IsColleniar(v1, v2) && IsColleniar(v3, v4);
        }
        /// <summary>
        /// Проверка на прямоугольник
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsPryamougolnik(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(a, b);
            Point v2 = GetVector(c, d);
            Point v3 = GetVector(b, c);
            Point v4 = GetVector(d, a);
            return IsColleniar(v1, v2) && IsColleniar(v3, v4) && GetSkalyar(v1, v3) == 0 && GetSkalyar(v2, v4) == 0;
        }
    }
}
