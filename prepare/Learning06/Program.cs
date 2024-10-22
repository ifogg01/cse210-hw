using System;

class Program
{
    static void Main(string[] args)
    {
         Console.WriteLine("");
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 4);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Yellow", 2, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Blue", 3);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
            Console.WriteLine("");

        }
    }
}