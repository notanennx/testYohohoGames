using UnityEngine;
using Leopotam.Ecs;

public struct CounterEvent
{
    public int Amount;
    public EcsEntity StackEntity; 
    public EcsEntity CounterEntity;
}