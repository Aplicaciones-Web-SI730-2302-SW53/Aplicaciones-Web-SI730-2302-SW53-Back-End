using _3._Data;
using _3._Data.Model;

namespace _2._Domain;

public class TutorialDomain :ITutorialDomain
{
    private ITutorialData _tutorialData;

    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }
    
    public bool Create(Tutorial tutorial)
    {
        var existingTutitorial = _tutorialData.GetByTitle(tutorial.Title);

        if (existingTutitorial == null)
        {
            return _tutorialData.Create(tutorial);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Tutorial tutorial, int id)
    {       
        
       // if (tutorial.Title ==  "") return false;// No es negocio
        var existingTutitorial = _tutorialData.GetByTitle(tutorial.Title);

        if (existingTutitorial == null)
        {
            return _tutorialData.Update(tutorial,id);
        }
        else
        {
            return false;
        }
    }
    public bool Delete(int id)
    {
        //Validar negocio
        return _tutorialData.Delete(id);
    }
}