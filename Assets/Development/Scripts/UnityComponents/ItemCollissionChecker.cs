using System;
using UnityEngine;
using Leopotam.Ecs;
using NaughtyAttributes;

public class ItemCollissionChecker : MonoBehaviour
{
    // Main
    public EcsWorld EcsWorld;
    public EcsEntity TriggerEntity;

    // On triggering.
    private void OnTriggerEnter(Collider other)
    {
        // Create
        var newEvent = EcsWorld.NewEntity();
            ref var pickupEvent = ref newEvent.Get<PickupEvent>();
                pickupEvent.TriggerEntity = TriggerEntity;
                pickupEvent.VictimTransform = other.transform;
    }
}