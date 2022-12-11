using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Money
{
    public class MoneyPanel : MonoBehaviour
    {
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public int Money { get; private set; }

        [Space] [SerializeField] private Text moneyText;

        [SerializeField] private RectTransform iconTransform;

        public void SetupMoney(int money)
        {
            this.Money = money;
            this.UpdateMoneyText();
        }

        public void IncrementMoney(int range)
        {
            var newAmount = this.Money + range;

            this.Money = newAmount;
            this.UpdateMoneyText();
            this.AnimateIncome();
        }

        public void DecrementMoney(int range)
        {
            var newAmount = this.Money - range;
            this.Money = newAmount;
            this.UpdateMoneyText();
        }
        
        private void UpdateMoneyText()
        {
            var money = Mathf.Max(Money, 0);
            this.moneyText.text = money.ToString();
        }

        public Vector3 GetIconPosition()
        {
            return this.iconTransform.TransformPoint(this.iconTransform.rect.center);
        }

        private void AnimateIncome()
        {
            var rootTransform = this.iconTransform;
            DOTween.Sequence()
                .Append(rootTransform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 1f))
                .Append(rootTransform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.2f));
        }
    }
}