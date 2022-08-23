using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareLib;

namespace SquareLib
{
    class Program 
    {
        static void Main(string[] args)
        {
            List<string[]> allPolygonPoints = new List<string[]>();
            using (StreamReader sr = File.OpenText(@"E:\Точки\points.txt")) //вставить свой адрес файла в система
            {
                //считывание координат точек 
                while (true)
                {
                    string str = sr.ReadLine();
                    if (str == null)
                        break;
                    string[] elements = str.Split(' ');
                    allPolygonPoints.Add(elements);
                }
            }
            //создание массивов точек по Х и Y координатам
            double[] Xi = new double[allPolygonPoints[0].Length];
            double[] Yi = new double[allPolygonPoints[1].Length];
            for (int i = 0; i < allPolygonPoints[0].Length; i++)
            {
                Xi[i] = Convert.ToDouble(allPolygonPoints[0][i]);
                Yi[i] = Convert.ToDouble(allPolygonPoints[1][i]);
            }
            List<string[]> allTriangleElements = new List<string[]>();
            using (StreamReader sr1 = File.OpenText(@"E:\Точки\trianglepoints.txt")) //аналогично считывание и для координат треугольника
            {

                while (true)
                {
                    string str = sr1.ReadLine();
                    if (str == null)
                        break;
                    string[] triangleElements = str.Split(' ');
                    allTriangleElements.Add(triangleElements);
                }
            }
            double[] triangleXi = new double[allTriangleElements[0].Length];
            double[] triangleYi = new double[allTriangleElements[1].Length];
            for (int i = 0; i < allTriangleElements[0].Length; i++)
            {
                triangleXi[i] = Convert.ToDouble(allTriangleElements[0][i]);
                triangleYi[i] = Convert.ToDouble(allTriangleElements[1][i]);
            }
            //проверка работоспособности библиотеки
            Triangle triangle = new Triangle(triangleXi, triangleYi);
            Console.WriteLine(triangle.TriangleSquare()); //вывод площади треугольнка
            triangle.TriangleRight(); //вывод является ли треугольник прямоугольным
            Console.WriteLine("Введите радиус круга: ");
            int R = Convert.ToInt32(Console.ReadLine());
            Circle circle = new Circle(R);
            circle.CircleSquare();//вывод площади круга по радиусу
            Console.WriteLine("Тест на выпуклость N - угольника");
            Polygon polygon = new Polygon(Xi,Yi);
            polygon.PolygonType();//вывод типа N-угольника
            polygon.PolygonSquare();//вывод площади N-угольника

            Console.ReadKey();
        }
    }
}