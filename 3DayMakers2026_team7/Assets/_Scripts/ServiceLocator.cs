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
        return (TKey)Activator.CreateInstance(_typeDictionary[typeof(TKey)]);
    }
}
