using MyEntities;
using UnityEngine;

namespace Context
{
    public class CharacterService : MonoBehaviour
    {
        [SerializeField] private UnityEntity character;

        public IEntity GetCharacter()
        {
            return this.character;
        }
    }
}