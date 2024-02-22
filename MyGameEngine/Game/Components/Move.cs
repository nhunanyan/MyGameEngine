using MyGameEngine.Engine.Components;

namespace MyGameEngine.Game.Components;

public class Move : Component
{
    public override void Update()
    {
        Transform  transform =  GameObject.GetComponent<Transform>();
        transform.Position.X += 1;
        transform.Position.Y += 1;
    }
}