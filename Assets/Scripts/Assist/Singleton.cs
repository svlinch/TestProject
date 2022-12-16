using UnityEngine;

public class SingletonStarter<T> : Starter where T : Component
{
    public static T Instance;

    protected virtual void Awake()
    {
        Instance = this as T;
    }
}