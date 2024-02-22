namespace MyGameEngine.Engine.Components;

public abstract class Component
{
    public GameObject GameObject { get; internal set; } 
    public bool IsActive { get; private set; }

    protected Component()
    {
        IsActive = true;
    }

    public virtual void Awake()
    {
        
    }
    
    public void SetActive(bool state)
    {
        IsActive = state;
    }
    public abstract void Update();
}