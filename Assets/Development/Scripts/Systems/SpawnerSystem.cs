using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;

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
            if ((spawnerComponent.NextSpawn < Time.time) && (spawnerComponent.Amount < spawnerComponent.MaxAmount))
            {
                // Add
                spawnerComponent.Amount += 1;

                // Create
                CreateItem(spawnerComponent);

                // Cooldown
                spawnerComponent.NextSpawn = (Time.time + spawnerComponent.Cooldown);
            }
        }
    }

    // Creates an item
    private void CreateItem(SpawnerComponent inputSpawner)
    {
        // Get
        Transform spawnpointTransform = inputSpawner.SpawnPositions[Random.Range(0, inputSpawner.SpawnPositions.Count - 1)];

        // Create
        var newItem = Object.Instantiate(inputSpawner.ScriptableItem.Prefab, spawnpointTransform.position, Quaternion.identity);

        // Entitize
        var newItemEntity = ecsWorld.NewEntity();
            ref var itemComponent = ref newItemEntity.Get<ItemComponent>();
                itemComponent.Transform = newItem.transform;
                itemComponent.ModelTransform = itemComponent.Transform.GetChild(0);
                itemComponent.ScriptableItem = inputSpawner.ScriptableItem;
    }
}