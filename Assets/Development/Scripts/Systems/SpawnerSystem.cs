using Leopotam.Ecs;
using UnityEngine;

public class SpawnerSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<SpawnerComponent> ecsFilter;

    // Data
    private SceneData sceneData;

    // Process
    public void Run()
    {
        // Loop
        foreach (var i in ecsFilter)
        {
            // Get
            ref var spawnerComponent = ref ecsFilter.Get1(i); 

            // Attemp to spawn
            if (spawnerComponent.NextSpawn < Time.time)
            {
                // Create
                

                // Cooldown
                spawnerComponent.NextSpawn = (Time.time + spawnerComponent.Cooldown);
            }
        }
    }
}