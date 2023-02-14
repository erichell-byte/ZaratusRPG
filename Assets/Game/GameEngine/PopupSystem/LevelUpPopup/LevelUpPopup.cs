using System;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game.GamePlay.Player;

namespace Game.GameEngine
{
    public class LevelUpPopup : Popup
    {
        [SerializeField] private TextMeshProUGUI characterName;

        [SerializeField] private TextMeshProUGUI description;

        [SerializeField] private Image avatar;

        [SerializeField] private TextMeshProUGUI level;

        [SerializeField] private TextMeshProUGUI hitPoints;

        [SerializeField] private TextMeshProUGUI damage;

        [SerializeField] private Button levelUpButton;

        private IPresentationModel presenter;

        protected override void OnShow(object args)
        {
            if (args is not IPresentationModel presenter)
            {
                throw new Exception("Expected presentation model");
            }

            this.presenter = presenter;
            this.presenter.Start();
            this.presenter.OnLevelUpButtonStateChanged += OnLevelUpButtonStateChange;
            this.presenter.OnLevelUp += UpdateStats;

            this.characterName.text = presenter.GetName();
            this.description.text = presenter.GetDescription();
            this.avatar.sprite = presenter.GetAvatar();
            this.level.text = presenter.GetLevel();
            this.hitPoints.text = presenter.GetHitpoints();
            this.damage.text = presenter.GetDamage();

            this.levelUpButton.interactable = presenter.CanUpgrade();
            levelUpButton.onClick.AddListener(OnLevelUpClicked);
        }

        private void UpdateStats()
        {
            level.text = presenter.GetLevel();
            hitPoints.text = presenter.GetHitpoints();
            damage.text = presenter.GetDamage();

        }

        protected override void OnHide()
        {
            levelUpButton.onClick.RemoveListener(OnLevelUpClicked);
            this.presenter.OnLevelUpButtonStateChanged -= OnLevelUpButtonStateChange;
            this.presenter.OnLevelUp -= UpdateStats;
            this.presenter.Stop();
        }

        private void OnLevelUpClicked()
        {
            presenter.OnButtonClicked();
        }
        
        private void OnLevelUpButtonStateChange(bool isAvailable)
        {
            this.levelUpButton.interactable = isAvailable;
        }
        public interface IPresentationModel
        {
            event Action<bool> OnLevelUpButtonStateChanged;
            
            event Action OnLevelUp;

            void Start();

            void Stop();

            string GetName();

            string GetDescription();

            Sprite GetAvatar();

            string GetLevel();

            string GetHitpoints();

            string GetDamage();

            bool CanUpgrade();

            void OnButtonClicked();
            
        }
    }
}