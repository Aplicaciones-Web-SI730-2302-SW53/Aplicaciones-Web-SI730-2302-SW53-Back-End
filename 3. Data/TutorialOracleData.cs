namespace _3._Data;

public class TutorialOracleData :ITutorialData
{
    public string GetById(int id)
    {
        //conecto BBDD
        return "Tutorial from ORACle " + id.ToString();
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