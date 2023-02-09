using System;

namespace Game.GameEngine.Mechanics
{
    
    public interface IComponent_GetMoveSpeed
    {
        float Speed { get; }
    }

    public interface IComponent_SetMoveSpeed
    {
        void SetSpeed(float speed);
    }

    public interface IComponent_IMoveSpeedChanged
    {
        event Action<float> OnSpeedChanged;
    }
}