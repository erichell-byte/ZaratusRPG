using GameElements;
using UnityEngine;

namespace Context
{
    public class GameContextInstaller : MonoBehaviour
    {
        [SerializeField] private MonoGameContext _context;

        [Space] [SerializeField] private MonoBehaviour[] _listeners;
        
        [Space] [SerializeField] private MonoBehaviour[] _services;

        private void Awake()
        {
            // переписать под gameContext как в демо проекте
            
            
            // foreach(var service in this._services)
            //     _context.AddService(service);
            //
            // foreach (var listener in _listeners)
            //     _context.AddListener(listener);
        }
    }
}