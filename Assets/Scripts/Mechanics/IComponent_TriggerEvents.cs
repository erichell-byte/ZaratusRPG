using System;
using UnityEngine;

namespace Mechanics
{
    public interface IComponent_TriggerEvents
    {
        event Action<Collider> OnEntered;

        event Action<Collider> OnStaying;

        event Action<Collider> OnExit;
    }
}