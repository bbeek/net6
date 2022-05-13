using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternMatching
{

    public static class Program
    {
        // Start, langversion 6
        public static void Main(string[] args)
        {

            // Pattern matching, hoe zit het ook al weer.
            switch (ColourEnum.Green)
            {
                case ColourEnum.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ColourEnum.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ColourEnum.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ColourEnum.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

            }

            Console.WriteLine("Traditional pattern matching");
            Console.ForegroundColor = ConsoleColor.White;

            #region Type matching
            /*
            Shape shape = new Rectangle { Height = 4, Length = 3 };
            if (shape is Triangle)
            {
                Console.WriteLine(shape.Area);
            }
            */
            #endregion

            #region C#7

            //----------------------------------------------------------------------------------------------------------

            // switch naar 7
            /*
            if (shape is null)
            {
                Console.WriteLine("Demo broke");
            }
            else
            {
                Console.WriteLine("C#7 constant pattern");
            }
            */
            #region switch when (var pattern)
            /*
            switch (shape)
            {
                case Triangle t when t.Area > 12:
                    Console.WriteLine("Triangle area greater then 12");
                    break;
                case Triangle t when t.Base == 3:
                    Console.WriteLine("Triangle base is 3");
                    break;
                case Rectangle r when r.Height == 4:
                    Console.WriteLine("C# 7 matching");
                    break;
                default:
                    Console.WriteLine("Not matched");
                    break;
            }
            */
            #endregion
            #endregion

            #region C#8

            //----------------------------------------------------------------------------------------------------------

            // switch naar 8
            /*
            if (shape is Rectangle { Height: var height } && height % 2 == 0)
            {
                Console.WriteLine("C# 8 property and var matching");
            }
            */
            #region Nested property matching
            /*
            var nested = new NestedShape((Rectangle)shape, new Circle { Radius = 3 });

            if (nested is { Circle: { Radius: 3 } })
            {
                Console.WriteLine("C# 8 nested property matching");
            }
            */
            #endregion

            #region Switch expression
            /*
            double CalculateAreaSwitchExpression(Shape shape)
            {
                return shape switch
                {
                    null => throw new ArgumentNullException(nameof(shape)),

                    Square { Length: var l } => l * l,
                    Circle { Radius: var r } => r * r * Math.PI,
                    Rectangle { Height: var h, Length: var l } => h * l,
                    Triangle { Base: var b, Height: var h } => b * h / 2,

                    _ => throw new NotSupportedException()
                };
            }

            Console.WriteLine($"Area calculated with C# 8 switch expression: {CalculateAreaSwitchExpression(nested.Circle)}");
            */
            #endregion

            #region Positional
            /*
            if ((Rectangle)shape is (4, _))
            {
                Console.WriteLine("Positional matching");
            }
            */
            #endregion

            #endregion

            #region C#9

            //----------------------------------------------------------------------------------------------------------

            // switch naar 9
            /*
            if (nested.Circle is { Area: >= 10 })
            {
                Console.WriteLine("C# 9 relation pattern matching");
            }
            */

            #region logical pattern
            /*
            if (shape is Triangle or not Circle) // ((shape is not null) &&
            {
                Console.WriteLine("C# 9 logical pattern matching");

            }
            */
            #endregion

            #endregion

            #region C#10

            //----------------------------------------------------------------------------------------------------------

            // switch naar latest
            /*
            if (nested is { Circle.Radius: 3 })
            {
                Console.WriteLine("C# 10 nested property matching");
            }
            */












            /*
            if (nested is { Circle.Radius: 3 } or { Rectangle.Height: 3  })
            {
                Console.WriteLine("C# 10 nested property matching");
            }
            */
            #endregion

            #region Other

            //----------------------------------------------------------------------------------------------------------

            // switch naar langversion preview, C# 11: list pattern
            /*
            static int CheckSwitch(int[] values)
                => values switch
                {
                    [1, 2, .., 10] => 1,
                    [1, 2] => 2,
                    [1, _] => 3,
                    [1, ..] => 4,
                    [..] => 50
                };


            Console.WriteLine(CheckSwitch(new[] { 1, 2, 10 }));          // prints 1
            Console.WriteLine(CheckSwitch(new[] { 1, 2, 7, 3, 3, 10 })); // prints 1
            Console.WriteLine(CheckSwitch(new[] { 1, 2 }));              // prints 2
            Console.WriteLine(CheckSwitch(new[] { 1, 3 }));              // prints 3
            Console.WriteLine(CheckSwitch(new[] { 1, 3, 5 }));           // prints 4
            Console.WriteLine(CheckSwitch(new[] { 2, 5, 6, 7 }));        // prints 50
            */








            /*
            static IEnumerable<string[]> ReadRecords()
            {
                return """
                    04-01-2020, DEPOSIT,    Initial deposit,            2250.00
                    04-15-2020, DEPOSIT,    Refund,                      125.65
                    04-18-2020, DEPOSIT,    Paycheck,                    825.65
                    04-22-2020, WITHDRAWAL, Debit,           Groceries,  255.73
                    05-01-2020, WITHDRAWAL, #1102,           Rent, apt, 2100.00
                    05-02-2020, INTEREST,                                  0.65
                    05-07-2020, WITHDRAWAL, Debit,           Movies,      12.57
                    04-15-2020, FEE,                                       5.55
                    """.Split(Environment.NewLine).Select(s => s.Split(",", StringSplitOptions.TrimEntries));
            }

            var ar = ReadRecords();

            decimal balance = 0m;
            foreach (var record in ReadRecords())
            {
                balance += record switch
                {
                    [_, "DEPOSIT", _, var amount] => decimal.Parse(amount),
                    [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
                    [_, "INTEREST", var amount] => decimal.Parse(amount),
                    [_, "FEE", var fee] => decimal.Parse(fee),
                    _ => throw new InvalidOperationException($"Record {record.Aggregate((s, y) => s + "," + y)} is not in the expected format!"),
                };
                Console.WriteLine($"Record: {record.Aggregate((s, y) => s + "," + y)}, New balance: {balance:C}");

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Total balance {balance:C}");
            Console.ForegroundColor = ConsoleColor.White;

            // Done
            */
            #endregion

            #region preview preview
            // VS 2022 preview
            /*
            static bool IsABC(Span<char> s)
            {
                return s switch
                {
                    "ABC" => true,
                    _ => false
                };
            }
            */
            #endregion
        }


    }

}
