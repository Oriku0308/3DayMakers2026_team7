using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    static readonly Dictionary<Type, object> _dict = new();

    public static void Register<TKey, TValue>(TValue value)
    {
        _dict.Add(typeof(TKey), value);
    }

    public static TValue Resolve<TKey, TValue>(TKey type)
    {
        return (TValue)_dict[typeof(TKey)];
    }

    public static void RemoveValue<TKey>()
    {
        if (!_dict.ContainsKey(typeof(TKey))) return;
        _dict.Remove(typeof(TKey));
    }

    public static void RemoveAll()
    {
        _dict.Clear();
    }
}
