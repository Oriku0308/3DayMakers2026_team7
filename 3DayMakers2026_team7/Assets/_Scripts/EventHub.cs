using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class EventHub
{
    readonly Dictionary<Type, List<Delegate>> _dict = new();

    /// <summary>
    /// イベントの発火
    /// </summary>
    /// <typeparam name="TEvent">発火するイベントの種類</typeparam>
    /// <param name="e">発火するイベント</param>
    public void Publish<TEvent>(TEvent e)   //どんな型でも通るようになっているがそこは暗黙の了解
    {
        var type = typeof(TEvent);
        if (!_dict.TryGetValue(type, out var list)) return;

        var handlers = list.ToArray();
        //登録されたアクションをすべて呼び出す
        foreach (var handler in handlers)
        {
            ((Action<TEvent>)handler)(e);
        }
    }

    /// <summary>
    /// イベントの購読
    /// </summary>
    /// <typeparam name="TEvent">購読するイベントの種類</typeparam>
    /// <param name="handler">発火時に行うアクション</param>
    /// <returns>アクションを削除する処理</returns>
    public IDisposable Subscribe<TEvent>(Action<TEvent> handler)    //どんな型でも通るようになっているがそこは暗黙の了解
    {
        //イベントに対してアクションを登録する
        var type = typeof(TEvent);
        if (!_dict.TryGetValue(type, out var list))
        {
            list = new List<Delegate>();
            _dict[type] = list;
        }

        list.Add(handler);

        //登録したアクションを削除したいとき用のクラスを返す
        //戻り値に対して.Dispose()を実行するとアクションが消える
        return new Subscription(() => list.Remove(handler));
    }

    /// <summary>アクションの削除を担うクラス</summary>
    private sealed class Subscription : IDisposable
    {
        readonly Action _dispose;
        bool _disposed;

        public Subscription(Action dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _dispose();
            _disposed = true;
        }
    }
}
