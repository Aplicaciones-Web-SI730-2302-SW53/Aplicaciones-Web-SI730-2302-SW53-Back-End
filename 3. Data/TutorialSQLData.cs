namespace _3._Data;

public class TutorialSQLData :ITutorialData
{
    public string GetById(int id)
    {
        //conecto BBDD
        return "Tutorial from SQL" + id.ToString();
    }

    public string[] GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Create(string name)
    {
        throw new NotImplementedException();
    }
}