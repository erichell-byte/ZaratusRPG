using JetBrains.Annotations;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace Game.Meta
{
    public sealed class UpgradeView : MonoBehaviour
    {
        private const string UPGRADE_COLOR_HEX = "309D1E";
        
        public UpgradeButton UpgradeButton
        {
            get { return this.upgradeButton; }
        }

        [SerializeField] private Image iconImage;

        [Space] [SerializeField] private TextMeshProUGUI titleText;
        
        [Space] [SerializeField] private TextMeshProUGUI valueText;
        
        [Space] [SerializeField] private TextMeshProUGUI levelText;

        [Space] [SerializeField] 
        private UpgradeButton upgradeButton;

        public void SetIcon(Sprite icon)
        {
            this.iconImage.sprite = icon;
        }

        public void SetTitle(string title)
        {
            this.titleText.text = title;
        }

        public void SetValue(string title, string value, [CanBeNull] string nextProfit)
        {
            var text = $"{title} : {value}";
            if (nextProfit != null)
            {
                text += $" <color=#{UPGRADE_COLOR_HEX}>(+{nextProfit})</color>";
            }

            this.valueText.text = text;
        }

        public void SetLevel(string title, int currentLevel, int maxLevel)
        {
            this.levelText.text = $"{title} : {currentLevel}/{maxLevel}";
        }



    }
}