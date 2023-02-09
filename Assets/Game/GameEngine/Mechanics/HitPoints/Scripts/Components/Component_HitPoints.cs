using System;
using Primitives;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    // сделать так чтобы этот компонент наследовал событийные интерфейсы
    public class Component_HitPoints : MonoBehaviour
    {
        public event Action<int> OnHitPointsChanged
        {
            add { this.engine.OnHitPointsChanged += value; }
            remove { this.engine.OnHitPointsChanged -= value; }
        }
        
        public event Action<int> OnMaxHitPointsChanged
        {
            add { this.engine.OnMaxHitPointsChanged += value; }
            remove { this.engine.OnMaxHitPointsChanged -= value; }
        }

        public int HitPoints
        {
            get { return this.engine.CurrentHitPoints; }
        }

        public int MaxHitPoints
        {
            get { return this.engine.MaxHitPoints; }
        }
        
        private HitPointsEngine engine;
        
        public void Setup(int hitPoints, int max)
        {
            this.engine.Setup(hitPoints, max);
        }

        public void SetHitPoints(int hitPoints)
        {
            this.engine.CurrentHitPoints = hitPoints;
        }

        public void SetMaxHitPoints(int maxHitpoints)
        {
            this.engine.MaxHitPoints = maxHitpoints;
        }

        public void AddHItPoints(int range)
        {
            this.engine.CurrentHitPoints += range;
        }
        
    }
}
