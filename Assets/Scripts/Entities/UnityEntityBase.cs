using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyEntities
{
    
    public class UnityEntityBase : UnityEntity
    {
        [SerializeField] private List<MonoBehaviour> elements = new List<MonoBehaviour>();

        private Entity _entity;

        public override T Get<T>()
        {
            try
            {
                return this._entity.Get<T>();
            }
            catch (Exception exception)
            {
                Debug.LogError(exception.Message, this);
                throw;
            }
        }

        public override T[] GetAll<T>()
        {
           return _entity.GetAll<T>();
        }

        public override bool TryGet<T>(out T element)
        {
            return _entity.TryGet(out element);
        }

        public override object[] GetAll()
        {
            return _entity.GetAll();
        }

        public override void Add(object element)
        {
            _entity.Add(element);
        }

        public override void Remove(object element)
        {
            _entity.Remove(element);
        }

#if UNITY_EDITOR
        public void Editor_AddElement(MonoBehaviour element)
        {
            this.elements.Add(element);   
        }
#endif
    }
}