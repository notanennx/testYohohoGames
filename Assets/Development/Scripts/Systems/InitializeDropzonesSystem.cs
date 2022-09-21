using System;
using Leopotam.Ecs;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitializeDropzonesSystem : IEcsInitSystem
{
    // Main
    private EcsWorld ecsWorld;

    // Data
    private SceneData sceneData;

    // Initialize
    public void Init()
    {
        // Loop
        foreach (DropzoneView dropzoneView in GameObject.FindObjectsOfType<DropzoneView>())
        {
            // Create
            EcsEntity dropzoneEntity = ecsWorld.NewEntity();
                ref var dropzoneComponent = ref dropzoneEntity.Get<DropzoneComponent>();

            // Attach
            dropzoneView.Entity = dropzoneEntity;

            // Fillup data
            dropzoneComponent.Transform = dropzoneView.transform;
            dropzoneComponent.DroppointTransform = dropzoneComponent.Transform.Find("Droppoint");
        }
    }
}