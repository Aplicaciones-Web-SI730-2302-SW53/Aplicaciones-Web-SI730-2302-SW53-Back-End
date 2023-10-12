using _3._Data.Context;

namespace _3._Data.Model;

public class TutorialMySQLData : ITutorialData
{
    private LearningCenterBD _learningCenterBd;

    public TutorialMySQLData(LearningCenterBD learningCenterBd)
    {
        _learningCenterBd = learningCenterBd;
    }
    
    public Tutorial GetById(int id)
    {
       return _learningCenterBd.Tutorials.Where(t => t.Id == id).First();
    }

    public List<Tutorial> GetAll()
    {
        return _learningCenterBd.Tutorials.ToList();
    }

    public bool Create(string name)
    {
        throw new NotImplementedException();
    }
}