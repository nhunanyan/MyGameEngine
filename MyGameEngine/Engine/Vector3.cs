namespace MyGameEngine.Engine;

public struct Vector3
{
    public int X;
    public int Y;
    public int Z;

    public Vector3()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }

    public Vector3(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Vector3(int x, int y, int z) : this(x, y)
    {
        Z = z;
    }

    public static Vector3 Zero = new Vector3(0, 0, 0);
    public static Vector3 One = new Vector3(1, 1, 1);
}