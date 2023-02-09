using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace Primitives
{
    public sealed class HitPointsEngine : MonoBehaviour
    {
        public event Action OnSetuped;

        public event Action<int> OnHitPointsChanged;
        
        public event Action<int> OnMaxHitPointsChanged;

        public event Action OnHitPointsFull;

        public event Action OnHitPointsEmpty;

        public int CurrentHitPoints
        {
            get { return this.currentHitPoints; }
            set { this.SetHitPoints(value); }
        }

        public int MaxHitPoints
        {
            get { return this.maxHitPoints; }
            set { this.SetMaxHitPoints(value);}
        }
        
        [SerializeField] private int currentHitPoints;
        [SerializeField] private int maxHitPoints;

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Setup(int current, int max)
        {
            this.maxHitPoints = max;
            this.currentHitPoints = Mathf.Clamp(current, 0, this.maxHitPoints);
            this.OnSetuped?.Invoke();
        }
        
        [GUIColor(0,1,0)]
        [Button]
        private void SetHitPoints(int value)
        {
            value = Mathf.Clamp(value, 0, maxHitPoints);
            this.currentHitPoints = value;
            
            this.OnHitPointsChanged?.Invoke(this.currentHitPoints);

            if (value <= 0)
            {
                this.OnHitPointsEmpty?.Invoke();
            }

            if (value >= this.maxHitPoints)
            {
                this.OnHitPointsFull?.Invoke();
            }
        }

        [GUIColor(0, 1, 0)]
        [Button]
        private void SetMaxHitPoints(int value)
        {
            value = Math.Max(1, value);
            if (this.currentHitPoints > value)
            {
                currentHitPoints = value;
            }

            this.maxHitPoints = value;
            this.OnMaxHitPointsChanged?.Invoke(value);
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            this.maxHitPoints = Math.Max(1, maxHitPoints);
            this.currentHitPoints = Math.Clamp(this.currentHitPoints, 1, this.maxHitPoints);
        }
#endif
    }
}