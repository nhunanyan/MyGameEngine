using MyGameEngine.Engine.Components;
using MyGameEngine.Game.Components;

namespace MyGameEngine.Engine;

public class System
{
    public List<GameObject> GameObjects = new List<GameObject>();
    public System()
    {
        GameObject canvasGameObject = new GameObject();
        Canvas canvas = canvasGameObject.AddComponent<Canvas>();
        GameObjects.Add(canvasGameObject);
        
        GameObject squareGameObject2 = new GameObject();
        squareGameObject2.AddComponent<ChangeScale>();
        Square square2=squareGameObject2.AddComponent<Square>();
        square2.Transform.Position = new Vector3(12, 12);
        GameObjects.Add(squareGameObject2);
        
        GameObject squareGameObject3 = new GameObject();
        squareGameObject3.AddComponent<ChangeScale>();
        Square square3=squareGameObject3.AddComponent<Square>();
        square3.Transform.Position = new Vector3(6, 12);
        GameObjects.Add(squareGameObject3);
        
        
        GameObject squareGameObject = new GameObject();
        squareGameObject.AddComponent<ChangeScale>();
        Square square=squareGameObject.AddComponent<Square>();
        square.Transform.Position = new Vector3(1, 1);
        GameObjects.Add(squareGameObject);
        
       
        canvas.Append(square2);
        canvas.Append(square3);
        canvas.Append(square);
        
    }
    
    public void Run()
    {
        while (true)
        {
            for (int j = 0; j < GameObjects.Count; j++)
            {
                GameObjects[j].Update();
            }
            Thread.Sleep(200);
        }
    }
}