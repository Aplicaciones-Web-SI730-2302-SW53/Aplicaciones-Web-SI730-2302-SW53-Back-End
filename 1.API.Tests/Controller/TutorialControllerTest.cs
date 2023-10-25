using _1._API.Controllers;
using _1._API.Response;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using AutoMapper;
using NSubstitute;

namespace _1.API.Tests.Controller;

public class TutorialControllerTest
{
    [Fact]
    public async Task GetAsync_ReturnOk()
    {
        //Arrange
        var tutorialDomainMock = Substitute.For<ITutorialDomain>();

        //moq getall
        var tutorialDataMock = Substitute.For<ITutorialData>();
        List<Tutorial> tutorials = new List<Tutorial>();
        tutorials.Add(new Tutorial() { Title = "Fake 1" });
        tutorials.Add(new Tutorial() { Title = "Fake 2" });
        tutorials.Add(new Tutorial() { Title = "Fake 3" });

        tutorialDataMock.GetAllAsync().Returns(Task.FromResult(tutorials));
        
        //moq mapper
        var mapperMock = Substitute.For<IMapper>();
        List<TutorialResponse> tutorialReponses = new List<TutorialResponse>();
        tutorialReponses.Add(new TutorialResponse() { Title = "Fake 1" });
        tutorialReponses.Add(new TutorialResponse() { Title = "Fake 2" });
        tutorialReponses.Add(new TutorialResponse() { Title = "Fake 3" });

        mapperMock.Map<List<Tutorial>, List<TutorialResponse>>(tutorials).Returns(tutorialReponses);
        
        //Act
        //creation Objet
        TutorialController tutorialController = new TutorialController(tutorialDataMock,tutorialDomainMock,mapperMock);
        var actualResult = await tutorialController.GetAsync();
        
        //Assert 
        Assert.Equal(3, actualResult.Count());
    }
}
