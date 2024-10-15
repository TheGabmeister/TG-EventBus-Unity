using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBus
{ 

public static class Bus<T> where T : IEvent
{
    private static readonly HashSet<Action> BindingsWithoutArguments = new();
    private static readonly HashSet<Action<T>> BindingsWithArguments = new();

    public static void Add(Action<T> binding) => BindingsWithArguments.Add(binding);
    public static void Add(Action binding) => BindingsWithoutArguments.Add(binding);

    public static void Remove(Action<T> binding) => BindingsWithArguments.Remove(binding);
    public static void Remove(Action binding) => BindingsWithoutArguments.Remove(binding);

    public static void Raise(T @event)
    {
        foreach (Action<T> binding in BindingsWithArguments)
        {
            binding?.Invoke(@event);
        }

        foreach (Action binding in BindingsWithoutArguments)
        {
            binding?.Invoke();
        }
    }

    /// <summary>Remove all listeners.</summary>
    [UsedImplicitly] //used via reflection in EventBusUtilities.ClearAllBuses()
    public static void Clear()
    {
        Debug.Log($"Clearing {typeof(T).Name} bindings (removing all listeners)");
        BindingsWithArguments.Clear();
        BindingsWithoutArguments.Clear();
    }
}

}