Rational r0 = new( 1, 2);
Rational r1 = new(-1, 2);
Rational r2 = new( 1, 3);
Rational r3 = new(-1, 3);

Rational[] rs = [r0, r1, r2, r3];

foreach(var a in rs)
{
    foreach(var b in rs)
    {
        Console.WriteLine("a: " + a + "   b: " + b);
        Console.WriteLine("Compare: " + a.CompareTo(b));
        Console.WriteLine("Add: " + (a + b));
        Console.WriteLine("Substract: " + (a - b));
        Console.WriteLine("Multiply: " + (a * b));
        Console.WriteLine("Divide: " + (a / b));
        Console.WriteLine();
    }
}
Console.WriteLine("Rational(1,2)+3: " + r0 + 3);
Console.WriteLine("(double)Rational: " + (double)r0);