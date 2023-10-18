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
       return _learningCenterBd.Tutorials.Where(t => t.Id == id && t.IsActive).First();
    }

    public Tutorial GetByTitle(string title)
    {
        return _learningCenterBd.Tutorials.Where(t => t.Title ==title && t.IsActive).FirstOrDefault();
    }

    public List<Tutorial> GetAll()
    {
        return _learningCenterBd.Tutorials.Where(t => t.IsActive).ToList();
    }

    public bool Create(Tutorial tutorial)
    {
        try
        {
            _learningCenterBd.Tutorials.Add(tutorial);
            _learningCenterBd.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            //Logear
            return false;
        }
    }

    public bool Update(Tutorial tutorial, int id)
    {    try
        {
            var tutorialToBeUpdated = _learningCenterBd.Tutorials.Where(t => t.Id == id).First();

            tutorialToBeUpdated.Title = tutorial.Title;
            tutorialToBeUpdated.Author = tutorial.Author;
            tutorialToBeUpdated.Year = tutorial.Year;
            tutorialToBeUpdated.CategoryId = tutorial.CategoryId;
            
            tutorialToBeUpdated.DateUpdate = DateTime.Now;

            _learningCenterBd.Tutorials.Update(tutorialToBeUpdated);
            _learningCenterBd.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            //Logear
            return false;
        }
    }

    public bool Delete(int id)
    {  try
        {
            var tutorialToBeUpdated = _learningCenterBd.Tutorials.Where(t => t.Id == id).First();
            
            tutorialToBeUpdated.DateUpdate = DateTime.Now;
            tutorialToBeUpdated.IsActive = false;

            //_learningCenterBd.Tutorials.Remove(tutorialToBeUpdated);/// ELimina física
            
            _learningCenterBd.Tutorials.Update(tutorialToBeUpdated);
            _learningCenterBd.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            //Logear
            return false;
        }
    }
}