using UnityEngine;
using Leopotam.Ecs;

public struct DropzoneEnterEvent
{
    public EcsEntity OwnerEntity;
    public EcsEntity DropzoneEntity;
}