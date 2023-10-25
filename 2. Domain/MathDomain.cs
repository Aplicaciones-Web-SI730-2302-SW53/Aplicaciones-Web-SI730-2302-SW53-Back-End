namespace _2._Domain;

public class MathDomain
{
    public int Sum(int a, int b)
    {
        //a b < 100
        if (a > 100 || b > 100) throw new ArgumentException("value more than 100");
        
        return a + b ;
    }
}