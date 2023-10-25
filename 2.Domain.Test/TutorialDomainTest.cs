using _2._Domain;
using _3._Data;
using _3._Data.Model;
using NSubstitute;

namespace _2.Domain.Test;

public class TutorialDomainTest
{
    [Theory]
    [InlineData("fake title 1",1,2023)]
    [InlineData("fake title 2",3,2021)]
    [InlineData("fake title 3",4,2022)]
    public void Create_ValidTutorial_ResultTrue(string title,int author,int year)
    {
        //Arrange
        Tutorial tutorial = new Tutorial()
        {
            Title = title,
            Author = author,
            Year = year
        };

        //TutorialMySQLData tutorialMySqlData = new TutorialMySQLData();
        var tutorialDataMock = Substitute.For<ITutorialData>();

        tutorialDataMock.GetByTitle(tutorial.Title).Returns((Tutorial)null);
        tutorialDataMock.Create(tutorial).Returns(true);
        
        TutorialDomain tutorialDomain = new TutorialDomain(tutorialDataMock);

        
        //Act
        var actualResult = tutorialDomain.Create(tutorial);

        //Assert
        Assert.True(actualResult);

    }
    
    
    [Theory]
    [InlineData(2018)]
    [InlineData(2020)]
    [InlineData(1998)]
    public void Create_Invalidyear_ResultFalse(int year)
    {
        //Arrange
        Tutorial tutorial = new Tutorial()
        {
            Year = year
        };
        
        //TutorialMySQLData tutorialMySqlData = new TutorialMySQLData();
        var tutorialDataMock = Substitute.For<ITutorialData>();
        
        TutorialDomain tutorialDomain = new TutorialDomain(tutorialDataMock);
        
        //Act
        Action act= () => tutorialDomain.Create(tutorial);

        //Assert
        Assert.Throws<Exception>(act);

    }
}