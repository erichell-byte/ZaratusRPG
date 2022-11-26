using System;
using System.Collections.Generic;

namespace MyEntities
{
    public class Entity : IEntity
    {

        protected readonly List<object> elements;

        public Entity()
        {
            this.elements = new List<object>();
        }

        public Entity(IEnumerable<object> elements)
        {
            this.elements = new List<object>(elements);
        }

        public Entity(params object[] elements)
        {
            this.elements = new List<object>(elements);
        }
        

        public T Get<T>()
        {
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                var component = this.elements[i];
                if (component is T result)
                {
                    return result;
                }
            }
            throw new Exception($"Component of {typeof(T).Name} is not found ");
        }

        public T[] GetAll<T>()
        {
            var result = new List<T>();
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                if (this.elements[i] is T element)
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
        }

        public bool TryGet<T>(out T element)
        {
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                if (this.elements[i] is T result)
                {
                    element = result;
                    return true;
                }
            }
            element = default;
            return false;
        }

        public object[] GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(object element)
        {
            throw new NotImplementedException();
        }

        public void Remove(object element)
        {
            throw new NotImplementedException();
        }
    }

}