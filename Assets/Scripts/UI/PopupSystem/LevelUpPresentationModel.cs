using System;
using UnityEngine;

namespace UI.PopupSystem
{
    public class LevelUpPresentationModel : LevelUpPopup.IPresentationModel
    {
        public event Action<bool> OnLevelUpButtonStateChanged;

        private TmpCharacter character;

        private CharacterUpgrader characterUpgrader;


        public LevelUpPresentationModel(TmpCharacter character, CharacterUpgrader characterUpgrader)
        {
            this.character = character;
            this.characterUpgrader = characterUpgrader;
        }

        public void Start()
        {
            character.OnLevelChanged += OnLevelChanged;
        }

        public void Stop()
        {
            character.OnLevelChanged -= OnLevelChanged;
        }

        public string GetName()
        {
            return this.character.name;
        }

        public string GetDescription()
        {
            return this.character.description;
        }

        public Sprite GetAvatar()
        {
            return this.character.avatar;
        }

        public string GetLevel()
        {
            return this.character.level + " / " + this.character.maxLevel;
        }

        public string GetHitpoints()
        {
            return this.character.hitPoints + " / " + this.character.maxHitPoints;
        }

        public string GetDamage()
        {
            return this.character.damage.ToString();
        }

        public bool CanUpgrade()
        {
            return characterUpgrader.CanUpgrade();
        }

        public void OnButtonClicked()
        {
            characterUpgrader.Upgrade();
        }

        public void UpdateHitPoints()
        {
            
        }

        public void OnLevelChanged()
        {
            var canUpgrade = characterUpgrader.CanUpgrade();
            OnLevelUpButtonStateChanged?.Invoke(canUpgrade);
            
            
        }


        
    }
}