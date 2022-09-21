using Leopotam.Ecs;
using UnityEngine;

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
            spawnerComponent.MaxAmount = spawnerData.Amount;
            spawnerComponent.Transform = spawnerData.Transform;
            spawnerComponent.ScriptableItem = spawnerData.ScriptableItem;
        }
    }
}