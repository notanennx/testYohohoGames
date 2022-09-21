using System;
using Leopotam.Ecs;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitializeSpawnersSystem : IEcsInitSystem
{
    // Main
    private EcsWorld ecsWorld;

    // Data
    private SceneData sceneData;

    // Initialize
    public void Init()
    {
        // Loop
        foreach (SpawnerData spawnerData in sceneData.ItemSpawners)
        {
            // Create
            EcsEntity spawnerEntity = ecsWorld.NewEntity();
                ref var spawnerComponent = ref spawnerEntity.Get<SpawnerComponent>();

            // Fillup data
            spawnerComponent.Cooldown = spawnerData.Cooldown;
            spawnerComponent.Transform = spawnerData.Transform;
            spawnerComponent.ScriptableItem = spawnerData.ScriptableItem;

            // Fillup positions
            spawnerComponent.SpawnPositions = new List<Transform>();
            foreach (Transform spawnPoint in spawnerComponent.Transform.GetChild(0))
                spawnerComponent.SpawnPositions.Add(spawnPoint);
        }
    }
}