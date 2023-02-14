using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameEngine
{
    public class TmpCharacter: MonoBehaviour
    {
        public event Action OnLevelChanged;
        
        public string name;

        public string description;

        public Sprite avatar;

        public int level;
        
        public int maxLevel;

        public int hitPoints;

        public int maxHitPoints;

        public int damage;

        public void LevelChanged()
        {
            this.OnLevelChanged?.Invoke();
        }
        
    }
}