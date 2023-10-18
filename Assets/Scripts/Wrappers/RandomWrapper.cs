
public class RandomWrapper : IRandom
{
    static readonly System.Random rng = new();

    public int Next(int max)
    {
        return rng.Next(max);
    }
}
