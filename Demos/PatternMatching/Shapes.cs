using System;

namespace PatternMatching
{
    internal class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Height { get; set; }

        public override double Area => Length * Height;

        #region Demo
        /*
        public void Deconstruct(out double length, out double height)
        {
            length = Length;
            height = Height;
        }
        */
        #endregion
    }

    internal class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double Area => .5 * Base * Height;
    }

    internal class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area => Math.PI * Radius * Radius;
    }

    internal class Square : Shape
    {
        public double Length { get; set; }

        public override double Area => Length*Length;
    }

    internal abstract class Shape 
    {
        public abstract double Area { get; }
    }


    internal class NestedShape
    {
        public NestedShape(Rectangle rectangle, Circle circle)
        {
            Rectangle = rectangle;
            Circle = circle;
        }

        public Rectangle Rectangle { get; set; }
        public Circle Circle { get; set; }
    }
}
