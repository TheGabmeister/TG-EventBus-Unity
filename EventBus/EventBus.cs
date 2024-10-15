using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBus
{ 
    public static class Bus<T> where T : IEvent
    {
        private static readonly HashSet<Action> BindingsWithoutArgs = new();
        private static readonly HashSet<Action<T>> BindingsWithArgs = new();

        public static void Add(Action<T> binding) => BindingsWithArgs.Add(binding);
        public static void Add(Action binding) => BindingsWithoutArgs.Add(binding);

        public static void Remove(Action<T> binding) => BindingsWithArgs.Remove(binding);
        public static void Remove(Action binding) => BindingsWithoutArgs.Remove(binding);

        public static void Raise(T @event)
        {
            foreach (Action<T> binding in BindingsWithArgs)
            {
                binding?.Invoke(@event);
            }

            foreach (Action binding in BindingsWithoutArgs)
            {
                binding?.Invoke();
            }
        }

        /// <summary>Remove all listeners.</summary>
        [UsedImplicitly] //used via reflection in EventBusUtilities.ClearAllBuses()
        public static void Clear()
        {
            Debug.Log($"Clearing {typeof(T).Name} bindings (removing all listeners)");
            BindingsWithArgs.Clear();
            BindingsWithoutArgs.Clear();
        }
    }
}