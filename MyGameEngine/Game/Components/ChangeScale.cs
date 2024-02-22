using MyGameEngine.Engine.Components;

namespace MyGameEngine.Game.Components;

public class ChangeScale : Component
{
    private bool _change = false;
    public override void Update()
    {
        Transform transform = GameObject.GetComponent<Transform>();
        if (transform.Scale.X < 10 && !_change)
        {
            transform.Scale.X += 1;
            transform.Scale.Y += 1;
            if (transform.Scale.X == 10) _change = true;
        }
        else if (transform.Scale.X > 0 && _change)
        {
            transform.Scale.X -= 1;
            transform.Scale.Y -= 1;
            if (transform.Scale.Y == 0) _change = false;
        }
    }
}