
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public class UpgradeShower : MonoBehaviour, IGameConstructElement
    {
        private TmpCharacter tmpCharacter;

        private CharacterUpgrader upgrader;

        private PopupManager popupManager;
        
        [Button]
        public void ShowUpgrade()
        {
            var presentationModel = new LevelUpPresentationModel(tmpCharacter, upgrader);
            this.popupManager.ShowPopup(PopupName.LEVELUP, presentationModel);
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            tmpCharacter = context.GetService<TmpCharacter>();
            upgrader = context.GetService<CharacterUpgrader>();
            popupManager = context.GetService<PopupManager>();
            Debug.Log(popupManager);
        }
    }
}