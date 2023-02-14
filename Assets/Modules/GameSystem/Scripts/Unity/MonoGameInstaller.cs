using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static GameSystem.GameComponentType;

namespace GameSystem
{
    public abstract class MonoGameInstaller : MonoBehaviour,
        IGameElementGroup,
        IGameServiceGroup,
        IGameConstructElement
    {
        private static readonly Type INJECT_ATTRIBUTE_TYPE = typeof(GameInjectAttribute);

        private static readonly Type MONO_BEHAVIOUR_TYPE = typeof(MonoBehaviour);

        private static readonly Type OBJECT_TYPE = typeof(object);

        private List<Metadata> localFields
        {
            get
            {
                if (this._localFields == null)
                {
                    this._localFields = this.CreateLocalFieldList();
                }

                return this._localFields;
            }
        }

        private List<Metadata> _localFields;

        public virtual IEnumerable<IGameElement> GetElements()
        {
            return this.GetElementsByReflection();
        }

        public virtual IEnumerable<object> GetServices()
        {
            return this.GetServicesByReflection();
        }

        public virtual void ConstructGame(IGameContext context)
        {
            this.ConstructByReflection(context);
        }

        protected IEnumerable<IGameElement> GetElementsByReflection()
        {
            var fields = this.localFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                if ((field.componentType & ELEMENT) != ELEMENT)
                {
                    continue;
                }

                if (field.fieldValue is IGameElement gameElement)
                {
                    yield return gameElement;
                }
                else
                {
                    Debug.LogWarning($"Oops... Field {field.fieldType} is not GameElement!");
                }
            }
        }

        private IEnumerable<object> GetServicesByReflection()
        {
            var fields = this.localFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                if ((field.componentType & SERVICE) == SERVICE)
                {
                    yield return field.fieldValue;
                }
            }
        }

        protected void ConstructByReflection(IGameContext context)
        {
            var fields = this.localFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                this.InjectObject(context, field.fieldType, field.fieldValue);
            }
        }

        private void InjectObject(IGameContext source, Type type, object target)
        {
            while (true)
            {
                if (type == null || type == OBJECT_TYPE || type == MONO_BEHAVIOUR_TYPE)
                {
                    break;
                }

                this.InjectByFields(source, target, type);
                this.InjectByMethods(source, target, type);

                type = type.BaseType;
            }
        }

        private void InjectByFields(IGameContext context, object target, Type targetType)
        {
            var fields = targetType.GetFields(BindingFlags.Instance |
                                              BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.DeclaredOnly);

            for (int i = 0, count = fields.Length; i < count; i++)
            {
                var field = fields[i];
                if (field.IsDefined(INJECT_ATTRIBUTE_TYPE))
                {
                    this.InjectByField(context, target, field);
                }
            }
        }

        private void InjectByField(IGameContext context, object target, FieldInfo field)
        {
            var fieldType = field.FieldType;
            var value = this.ResolveValue(context, fieldType);
            field.SetValue(target, value);
        }

        private void InjectByMethods(IGameContext context, object target, Type targetType)
        {
            var methods = targetType.GetMethods(BindingFlags.Instance |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.DeclaredOnly);

            for (int i = 0, count = methods.Length; i < count; i++)
            {
                var method = methods[i];
                if (method.IsDefined(INJECT_ATTRIBUTE_TYPE))
                {
                    this.InjectByMethod(context, target, method);
                }
            }
        }

        private void InjectByMethod(IGameContext context, object target, MethodInfo method)
        {
            var parameters = method.GetParameters();
            var count = parameters.Length;

            var args = new object[count];
            for (var i = 0; i < count; i++)
            {
                var parameter = parameters[i];
                var parameterType = parameter.ParameterType;
                args[i] = this.ResolveValue(context, parameterType);
            }

            method.Invoke(target, args);
        }

        private object ResolveValue(IGameContext context, Type type)
        {
            object arg;
            if (type == MONO_BEHAVIOUR_TYPE)
            {
                arg = this;
            }
            else if (!this.ResolveValueLocally(type, out arg))
            {
                arg = GameInjector.ResolveValue(context, type);
            }

            return arg;
        }

        private bool ResolveValueLocally(Type type, out object value)
        {
            var fields = this.localFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var metadata = fields[i];
                if (metadata.fieldType == type)
                {
                    value = metadata.fieldValue;
                    return true;
                }
            }

            value = default;
            return false;
        }

        private List<Metadata> CreateLocalFieldList()
        {
            var result = new List<Metadata>();
            var myType = this.GetType();
            var fields = myType.GetFields(BindingFlags.Instance |
                                          BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.DeclaredOnly);
            for (int i = 0, count = fields.Length; i < count; i++)
            {
                var field = fields[i];
                var attribute = field.GetCustomAttribute<GameComponentAttribute>();
                if (attribute == null)
                {
                    continue;
                }

                var metadata = new Metadata
                {
                    fieldType = field.FieldType,
                    fieldValue = field.GetValue(this),
                    componentType = attribute.type
                };
                result.Add(metadata);
            }

            return result;
        }

        private struct Metadata
        {
            public Type fieldType;

            public object fieldValue;

            public GameComponentType componentType;
        }
    }
}