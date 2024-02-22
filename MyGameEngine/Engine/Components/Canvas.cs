namespace MyGameEngine.Engine.Components;

public struct DrawInfo
{
    public Vector3 Position { get; }
    public char[,] shape { get; }

    public DrawInfo(Vector3 position, char[,] shape)
    {
        Position = position;
        this.shape = shape;
    }
}
public interface ICanvasDrawable
{
    DrawInfo GetDrawInfo();
}

public class Canvas : Component
{
    public char[,] Space;
    public readonly int Size = 26;

    private readonly List<ICanvasDrawable> _drawables = new List<ICanvasDrawable>();

    private void DefaultSpace(Vector3 position, Vector3 scale)
    {
        for (int i = position.Y; i < scale.Y + position.Y; ++i)
        {
            for (int j = position.X; j < scale.X + position.X; ++j)
            {
                Space[i, j] = ' ';
            }
        }
    }
    public Canvas()
    {
        Space = new char[Size, Size];
        for (int i = 0; i < Size; ++i)
        {
            for (int j = 0; j < Size; ++j)
            {
                Space[i, j] = ' ';
            }
        }
    }

    public void Append(ICanvasDrawable drawable)
    {
        _drawables.Add(drawable);
    }

    public void DrawShape(Vector3 position, char[,] shapeArray)
    {
        //DefaultSpace();
        for (int i = position.Y; i < shapeArray.GetLength(0) + position.Y; ++i)
        {
            for (int j = position.X; j < shapeArray.GetLength(1) + position.X; ++j)
            {
                Space[i, j] = shapeArray[i - position.Y, j - position.X];
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < Size; ++i)
        {
            for (int j = 0; j < Size; ++j)
            {
                Console.Write(Space[i,j]);
            }
            Console.WriteLine();
        }
    }
    public override void Update()
    {
        Console.Clear();
        foreach (ICanvasDrawable drawable in _drawables)
        {
            var info = drawable.GetDrawInfo();
            Vector3 scale = new Vector3(info.shape.GetLength(0) + 1, info.shape.GetLength(1) + 1);
            DefaultSpace(info.Position, scale);
            DrawShape(info.Position,info.shape);
        }
        
        Print();
    }
}