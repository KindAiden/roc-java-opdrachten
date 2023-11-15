float plus(float a, float b)
{
    return a + b;
}

numbers.int1 = float.Parse(Console.ReadLine());
numbers.int2 = float.Parse(Console.ReadLine());
Console.WriteLine(plus(numbers.int1, numbers.int2));
Console.ReadLine();

class numbers
{
    public static float int1;
    public static float int2;
}