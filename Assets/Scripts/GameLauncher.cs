using System.Collections;
using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameContext gameContext;
    
    [Button]
    private void StartTimer()
    {
        Debug.Log(timer.name);
        timer.OnEnded += gameContext.ConstructGame;
        timer.OnEnded += gameContext.StartGame;
        timer.Play();
        return;
    }
    
    


}
