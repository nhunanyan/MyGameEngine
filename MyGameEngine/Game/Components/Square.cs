using MyGameEngine.Engine.Components;

namespace MyGameEngine.Game.Components;

public class Square : Component, ICanvasDrawable
{
    public Transform Transform { get; private set; }
    public override void Awake()
    {
        Transform = GameObject.GetComponent<Transform>();
    }

    private void AddRow(char[,] squareArray, int length, int j)
    {
        for (int i = 0; i < length; ++i)
        {
            squareArray[j, i] = '*';
        }
    }

    private void AddSpaces(char[,] squareArray, int count, int j)
    {
        for (int i = 1; i <= count; i++)
        {
            squareArray[j, i] = ' ';
        }
    }

    public char[,] ConstructArray()
    {
        var squareArray = new char[Transform.Scale.Y, Transform.Scale.X];
        AddRow(squareArray,Transform.Scale.X, 0);

        for (int i = 1; i <= Transform.Scale.Y - 2; i++)
        {
            squareArray[i, 0] = '*';
            AddSpaces(squareArray,Transform.Scale.X - 2, i);
            squareArray[i, Transform.Scale.Y - 1] = '*';
        }

        AddRow(squareArray,Transform.Scale.X, Transform.Scale.Y - 1);
        return squareArray;
    }

    public override void Update()
    {
    }

    public DrawInfo GetDrawInfo()
    {
        var shape = ConstructArray();
        return new DrawInfo(Transform.Position, shape);
    }
}