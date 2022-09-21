using UnityEngine;
using Leopotam.Ecs;

public struct PickupEvent
{
    public EcsEntity TriggerEntity;
    public Transform VictimTransform;
}