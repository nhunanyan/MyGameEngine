using MyGameEngine.Engine.Components;

namespace MyGameEngine.Engine;

public class GameObject
{
    private readonly List<Component> _components = new List<Component>();
    public GameObject()
    {
        AddComponent<Transform>();
    }
    public T AddComponent<T>() where T : Component, new()
    {
        T component = new T
        {
            GameObject = this
        };
        component.Awake();
        _components.Add(component);
        return component;
    }

    public T GetComponent<T>() where T : Component
    {
        return (T)_components.Find(component => component.GetType() == typeof(T));
    }

    public void Update()
    {
        foreach (var component in _components)
        {
            if (component.IsActive)
            {
                component.Update();
            }
        }
    }
    
}