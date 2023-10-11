using _3._Data;

namespace _2._Domain;

public class TutorialDomain :ITutorialDomain
{
    private ITutorialData _tutorialData;

    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }
    
    public bool Create(string name)
    {
       return _tutorialData.Create(name);
    }
}