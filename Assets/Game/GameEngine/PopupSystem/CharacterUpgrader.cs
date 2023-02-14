
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.GameEngine
{
    public class CharacterUpgrader : MonoBehaviour
    {
        [SerializeField] private TmpCharacter character;

        [Button]
        public bool CanUpgrade()
        {
            return this.character.level < this.character.maxLevel;
        }
        
        [Button]
        public void Upgrade()
        {
            if (this.CanUpgrade())
            {
                this.character.level++;
                this.character.damage += 5;
                this.character.hitPoints += 10;
                this.character.maxHitPoints += 10;
                character.LevelChanged();
            }
            else
            {
                Debug.Log("Level of character is maximum");
            }
        }
    }
}