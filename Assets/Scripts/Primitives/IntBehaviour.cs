using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyPartWork
{
    public sealed class IntBehaviour : MonoBehaviour
    {
        public event Action<int> OnValueChanged;

        public int Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField] private int value;

    }
}