using System;
using UnityEngine;
using Leopotam.Ecs;
using NaughtyAttributes;

public class DropzoneCollissionChecker : MonoBehaviour
{
    // Main
    public EcsWorld EcsWorld;
    public EcsEntity OwnerEntity;

    // Exitting the dropzone.
    private void OnTriggerExit(Collider other)
    {
        // Create
        var newEvent = EcsWorld.NewEntity();
            ref var exitEvent = ref newEvent.Get<DropzoneExitEvent>();
                exitEvent.OwnerEntity = OwnerEntity;
                exitEvent.DropzoneEntity = other.transform.parent.GetComponent<DropzoneView>().Entity;
                
                // Setup dropzone
                exitEvent.OwnerEntity.Get<StackComponent>().DropzoneEntity = EcsEntity.Null;
    }

    // Entering the dropzone.
    private void OnTriggerEnter(Collider other)
    {
        // Create
        var newEvent = EcsWorld.NewEntity();
            ref var enterEvent = ref newEvent.Get<DropzoneEnterEvent>();
                enterEvent.OwnerEntity = OwnerEntity;
                enterEvent.DropzoneEntity = other.transform.parent.GetComponent<DropzoneView>().Entity;

                // Clean dropzone
                enterEvent.OwnerEntity.Get<StackComponent>().DropzoneEntity = enterEvent.DropzoneEntity;
    }
}