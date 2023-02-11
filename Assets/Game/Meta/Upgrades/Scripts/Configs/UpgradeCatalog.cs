using System;
using Meta.Upgrades;
using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(fileName = "Upgrade Catalog", menuName = UpgradeExtensions.MENU_PATH + "new UpgradeCatalog")]
    public sealed class UpgradeCatalog : ScriptableObject
    {
        [SerializeField] private UpgradeConfig[] configs;

        public UpgradeConfig[] GetAllUpgrades()
        {
            return this.configs;
        }

        public UpgradeConfig FindUpgrade(string id)
        {
            var length = this.configs.Length;
            for (var i = 0; i < length; i++)
            {
                var config = this.configs[i];
                if (config.id == id)
                    return config;
            }

            throw new Exception($"Config with id {id} not found!");
        }
    }
}