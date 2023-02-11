using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta
{
    [Serializable]
    public sealed class HitPointsUpgradeTable
    {

        public int HitPointsStep
        {
            get
            {
                return this.hitPointsStep;
            }
        }

        [InfoBox("HitPoints : Linear function")]
        [SerializeField]
        private int startHitPoint = 1;
        
        [SerializeField]
        private int hitPointsStep = 1;

        [Space]
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLabelForListElement"
        )]
        [SerializeField]
        private int[] levels;

        public int GetHitPoints(int level)
        {
            var index = level - 1;
            return this.levels[index];
        }
        
        public void OnValidate(int maxLevel)
        {
            var levels = new int[maxLevel];

            var currentHitPoints = this.startHitPoint;
            for (var i = 0; i < maxLevel; i++)
            {
                levels[i] = currentHitPoints;
                currentHitPoints += hitPointsStep;
            }

            this.levels = levels;
        }
        
        
#if UNITY_EDITOR
        private void DrawLabelForListElement(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level {index + 1}");
        }
#endif
    }
}