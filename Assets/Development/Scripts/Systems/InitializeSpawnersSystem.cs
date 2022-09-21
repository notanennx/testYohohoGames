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
        foreach (SpawnerView spawnerView in GameObject.FindObjectsOfType<SpawnerView>())
        {
            // Create
            EcsEntity spawnerEntity = ecsWorld.NewEntity();
                ref var spawnerComponent = ref spawnerEntity.Get<SpawnerComponent>();

            // Attach
            spawnerView.Entity = spawnerEntity;

            // Fillup data
            spawnerComponent.Cooldown = sceneData.SpawnerCooldown;
            spawnerComponent.Transform = spawnerView.transform;
            spawnerComponent.PrefabToSpawn = sceneData.PrefabToSpawn;

            // Fillup positions
            spawnerComponent.SpawnPositions = new List<Transform>();
            foreach (Transform spawnPoint in spawnerComponent.Transform.Find("Spawn Positions"))
                spawnerComponent.SpawnPositions.Add(spawnPoint);
        }
    }
}