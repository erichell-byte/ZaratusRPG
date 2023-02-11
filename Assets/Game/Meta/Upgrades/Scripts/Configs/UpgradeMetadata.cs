using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Meta.Upgrades
{
    [Serializable]
    public class UpgradeMetadata
    {
        
        [SerializeField]
        public string localizedTitle;

        [PreviewField] 
        [SerializeField] 
        public Sprite icon;
    }
}