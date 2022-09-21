using UnityEngine;
using Leopotam.Ecs;

public struct DropzoneExitEvent
{
    public EcsEntity OwnerEntity;
    public EcsEntity DropzoneEntity;
}