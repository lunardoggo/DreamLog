﻿using System.Collections.Generic;
using System;

namespace DreamLib.DependencyInjection
{
    public static class DependencyContainer
    {
        private static readonly Dictionary<Type, object> singletonDependencies = new Dictionary<Type, object>();

        public static void RegisterSingleton<T>(Func<T> singletonGetter) where T : class
        {
            DependencyContainer.RegisterSingleton<T>(singletonGetter.Invoke());
        }

        public static void RegisterSingleton<T>(T singleton) where T : class
        {
            if (DependencyContainer.IsRegistered<T>())
                DependencyContainer.singletonDependencies[typeof(T)] = singleton;
            else
                DependencyContainer.singletonDependencies.Add(typeof(T), singleton);
        }

        public static void RemoveSingleton<T>() where T : class
        {
            if (DependencyContainer.DependencyCache.ContainsKey(typeof(T)))
            {
                DependencyContainer.DependencyCache.Remove(typeof(T));
            }
        }

        public static T GetSingleton<T>() where T : class
        {
            if (DependencyContainer.singletonDependencies.TryGetValue(typeof(T), out object value))
            {
                if (value is T output)
                    return output;
            }
            return null;
        }

        public static bool IsRegistered<T>()
        {
            return DependencyContainer.singletonDependencies.ContainsKey(typeof(T));
        }

        internal static Dictionary<Type, object> DependencyCache
        {
            get { return DependencyContainer.singletonDependencies; }
        }
    }
}
