﻿using System;
using System.Collections.Generic;

namespace Ariane.Drivers
{
    public abstract class DriverBindings : IDisposable, IDriverBindings
    {
        public abstract string Url { get; }
        public abstract void NavigateTo(Uri url);
        public abstract void Dispose();
        public abstract IEnumerable<IHandle> NavigationHandlers { get; }

        public class Handle<TAttributeType> : IHandle
        {
            public Type AttributeType { get { return typeof(TAttributeType); } }
            public Func<Attribute, string> GetLookupValue { get; private set; }
            public Func<string, IDriverBindings, object> FindAllMatches { get; private set; }

            public Handle(Func<Attribute, string> getLookupValue, Func<string, IDriverBindings, object> findAllMatches)
            {
                GetLookupValue = getLookupValue;
                FindAllMatches = findAllMatches;
            }
        }

        public interface IHandle
        {
            Type AttributeType { get; }
            Func<Attribute, string> GetLookupValue { get; }
            Func<string, IDriverBindings, object> FindAllMatches { get; }
        }
    }
}