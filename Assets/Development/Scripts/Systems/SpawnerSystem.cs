using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

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
                // Find and spawn
                Transform freeSpawnpoint = FindFreeSpawnpoint(spawnerComponent);
                if (freeSpawnpoint)
                {
                    // Create
                    CreateItem(freeSpawnpoint, spawnerComponent);

                    // Cooldown
                    spawnerComponent.NextSpawn = (Time.time + spawnerComponent.Cooldown);
                }
            }
        }
    }

    // Attempts to find a free spawnpoint.
    private Transform FindFreeSpawnpoint(SpawnerComponent inputSpawner)
    {
        // Get
        Transform spawnpointTransform = inputSpawner.SpawnPositions[Random.Range(0, inputSpawner.SpawnPositions.Count)];

        // Collision
        Collider[] hitColliders = Physics.OverlapSphere(spawnpointTransform.position, 0.1f);

        // Returning
        if (hitColliders.Length > 0)
            return null;
        else
            return spawnpointTransform;
    }

    // Creates an item
    private void CreateItem(Transform spawnpointTransform, SpawnerComponent inputSpawner)
    {
        // Create
        var newItem = Object.Instantiate(inputSpawner.ScriptableItem.Prefab, spawnpointTransform.position, Quaternion.identity);
            newItem.transform.SetParent(sceneData.ItemsHolder);
            newItem.transform.localScale = Vector3.zero;
            newItem.transform.localEulerAngles = new Vector3(0f, 360f * Random.Range(0f, 1f), 0f);

            // Tweening
            newItem.transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack);
            newItem.transform.DOPunchPosition(0.6f * Vector3.up, 0.6f, 4, 0);

        // Entitize
        var newItemEntity = ecsWorld.NewEntity();
            ref var itemComponent = ref newItemEntity.Get<ItemComponent>();
                itemComponent.Transform = newItem.transform;
                itemComponent.ModelTransform = itemComponent.Transform.GetChild(0);

        // Attach entity
        newItem.GetComponent<ItemView>().Entity = newItemEntity;
    }
}