using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly IDictionary<Type, Type> _typeDictionary = new Dictionary<Type, Type>();

    public static void Register<TKey, TValue>()
    {
        _typeDictionary[typeof(TKey)] = typeof(TValue);
    }

    public static TKey Resolve<TKey>()
    {
        if (_typeDictionary.TryGetValue(typeof(TKey), out var k))
            return (TKey)Activator.CreateInstance(k);
        return default;
    }

    public static void Remove<TKey>()
    {
        if (_typeDictionary.ContainsKey(typeof(TKey)))
            _typeDictionary.Remove(typeof(TKey));
    }
}
