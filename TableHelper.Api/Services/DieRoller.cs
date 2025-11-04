namespace TableHelper.Api.Services;

public class DieRoller(Random _rnd)
{
    public int RollD2()
    {
        return _rnd.Next(1, 3);
    }

    public int RollD4()
    {
        return _rnd.Next(1, 5);
    }

    public int RollD6()
    {
        return _rnd.Next(1, 7);
    }
    
    public int RollD8()
    {
        return _rnd.Next(1, 9);
    }
    
    public int RollD10()
    {
        return _rnd.Next(1, 10);
    }

    public int RollD12()
    {
        return _rnd.Next(1, 12);
    }

    public int RollD100()
    {
        return _rnd.Next(1, 101);
    }
}