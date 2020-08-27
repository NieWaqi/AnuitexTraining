﻿using System;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Mappers.Base
{
    public abstract class BaseMapper<TFirst, TSecond>
    {
        public abstract TFirst Map(TSecond item);
        public abstract TSecond Map(TFirst item);

        public List<TFirst> Map(List<TSecond> elements, Action<TFirst> callback = null)
        {
            var objectCollection = new List<TFirst>();
            if (elements != null)
            {
                foreach (TSecond element in elements)
                {
                    TFirst newObject = Map(element);
                    if (newObject != null)
                    {
                        callback?.Invoke(newObject);
                        objectCollection.Add(newObject);
                    }
                }
            }
            return objectCollection;
        }

        public List<TSecond> Map(List<TFirst> elements, Action<TSecond> callback = null)
        {
            var objectCollection = new List<TSecond>();

            if (elements != null)
            {
                foreach (TFirst element in elements)
                {
                    TSecond newObject = Map(element);
                    if (newObject != null)
                    {
                        callback?.Invoke(newObject);
                        objectCollection.Add(newObject);
                    }
                }
            }
            return objectCollection;
        }
    }
}