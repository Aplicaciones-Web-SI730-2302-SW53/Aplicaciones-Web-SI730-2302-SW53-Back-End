using _2._Domain;

namespace _2.Domain.Test;

public class MathDomaintest
{
    //happy path
    [Theory]
    [InlineData(1,4,5)]
    [InlineData(6,8,14)]
    [InlineData(10,9,19)]
    public void Sum_Valid_ReturnSum(int a ,int b , int expected)
    {
        //Arrange - setup
        MathDomain mathDomain = new MathDomain();
        
        //Act - execution
        int actualResult = mathDomain.Sum(8, 9);
        
        //Assert - comparison
        Assert.Equal(17,actualResult);
    }
    
    //unhappy 
    [Theory]
    [InlineData(101,4)]
    [InlineData(105,40)]
    [InlineData(120,4)]
    public void Sum_ValueMoreThan100_ReturnException(int a ,int b )
    {
        //Arrange - setup
        MathDomain mathDomain = new MathDomain();
        
        //Act - execution
        Action act = () => mathDomain.Sum(a, b); // function
        
        //assert
        Assert.Throws<ArgumentException>(act);
    }
}