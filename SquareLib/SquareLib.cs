namespace SquareLib
{
    public class Triangle
    {
        public double[] _triangleXi;
        public double[] _triangleYi;
        public double _A, _B, _C;

        public Triangle(double[] xi, double[] yi)
        {
            this._triangleXi = xi;
            this._triangleYi = yi;
        }
        public double TriangleSquare()
        {
            //нахождение длин сторон треугольника
            _A = Math.Sqrt((_triangleXi[1] - _triangleXi[0]) * (_triangleXi[1] - _triangleXi[0]) + (_triangleYi[1] - _triangleYi[0]) * (_triangleYi[1] - _triangleYi[0]));
            _B = Math.Sqrt((_triangleXi[2] - _triangleXi[0]) * (_triangleXi[2] - _triangleXi[0]) + (_triangleYi[2] - _triangleYi[0]) * (_triangleYi[2] - _triangleYi[0]));
            _C = Math.Sqrt((_triangleXi[2] - _triangleXi[1]) * (_triangleXi[2] - _triangleXi[1]) + (_triangleYi[2] - _triangleYi[1]) * (_triangleYi[2] - _triangleYi[1]));
            
            if (_A + _B < _C || _A + _C < _B || _B + _C < _A) //проверка на существование треугольника
                throw new Exception("Заданные точки не являются треугольником"); 
            

            double p = (_A + _B + _C) / 2;
            double triangleSquare = Math.Sqrt(p*(p - _A) * (p - _B) * (p - _C)); //нахождение площади через полупериметр
            return triangleSquare;
        }
        public void TriangleRight()
        {
            //созданим локальную переменную квадратов сторон чтобы не считать несколько раз
            double A2 = _A * _A;
            double B2 = _B * _B;
            double C2 = _C * _C;
            if (_A + _B < _C || _A + _C < _B || _B + _C < _A)
                throw new Exception("Заданные точки не являются треугольником");
            if (A2 == B2 + C2 || B2 == A2 + C2 || C2 == A2 + B2) //желательно написать метод точного равенства double - переменных с заданной точностью
                Console.WriteLine("Треугольник прямоугольный");
            else
                Console.WriteLine("Треугольник не прямоугольный");
        }
    }

    public class Circle
    {
        public int R;
        public double circleSquare;
        public Circle(int R)
        {
            circleSquare = Math.PI * R * R; //вычисление площади круга
        }
        public void CircleSquare() => Console.WriteLine($"Площадь круга: {circleSquare}");
    }
    public class Polygon
    {
        public int Count { get { return _Xi?.Length ?? 0; } } //количество точек N-угольника 
        public int _polygonType = int.MaxValue;
        double[] _Xi;
        double[] _Yi;
        public Polygon(double[]xi, double[]yi)
        {
            this._Xi = xi; 
            this._Yi = yi;
        }
        public int PolygonType()
        {
            //алгоритм проверки на выпуклость N-угольника

            double c = ((_Xi[1] - _Xi[this.Count - 1]) * (_Xi[0] - _Xi[this.Count - 1])) + ((_Yi[1] - _Yi[this.Count - 1]) * (_Yi[0] - _Yi[this.Count - 1]));
            for (int i = 1; i < this.Count; i++)
            {
                double s = 0.0;
                if (i + 1 == this.Count)
                    s = ((_Xi[0] - _Yi[i - 1]) * (_Xi[i] - _Xi[i - 1])) + ((_Yi[0] - _Yi[i - 1]) * (_Yi[i] - _Yi[i - 1]));
                else
                    s = ((_Xi[i + 1] - _Yi[i - 1]) * (_Xi[i] - _Xi[i - 1])) + ((_Yi[i + 1] - _Yi[i - 1]) * (_Yi[i] - _Yi[i - 1]));
                double res = c * s;
                if (res == 0)
                {
                    Console.WriteLine("Данный полигон имеет развернутый угол");
                    _polygonType = 0;
                    break;
                }

                if (res < 0)
                {
                    _polygonType = -1;
                    break;
                }
                if (res > 0 && i == this.Count - 1)
                {
                    _polygonType = 1;
                    break;
                }

            }
            switch (_polygonType)
            {
                case -1:
                    Console.WriteLine("Заданный N - угольник невыпуклый");
                    break;
                case 1:
                    Console.WriteLine("Заданный N - угольник выпуклый");
                    break;

            }
            return _polygonType;
        }
             public double PolygonSquare()
            {
                double polygonSquare = 0.0;
                double sumX = 0;
                double sumY = 0;
            //нахождение площади N-угольника по формуле площади Гаусса
                for (int i = 0; i < this.Count; i++)
                {
                if (i + 1 == this.Count)
                {
                    sumX += _Xi[i] * _Yi[0];
                    sumY += _Yi[i] * _Xi[0];
                    break;
                }
                    sumX += _Xi[i] * _Yi[i + 1];
                    sumY += _Yi[i] * _Xi[i + 1];

                }
                polygonSquare = Math.Abs(0.5 * (sumX - sumY));
            Console.Write($"Площадь N - угольника: {polygonSquare}");
            return polygonSquare;
            }
    }
}