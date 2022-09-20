using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using NaughtyAttributes;

public class EcsStartup : MonoBehaviour
{
    // Main
    private EcsWorld ecsWorld;
    private EcsSystems ecsSystems;

    // Data
    [SerializeField, BoxGroup("Data")] private UIData uiData;
    [SerializeField, BoxGroup("Data")] private SceneData sceneData;
    //public StaticData configuration;

    // Initialize
    private void Awake()
    {        
        ecsWorld = new EcsWorld();
        ecsSystems = new EcsSystems(ecsWorld);

        // Adding stuff
        ecsSystems
            .Add(new PlayerInitSystem())

            .Add(new InputSystem())
            .Add(new MovementSystem())

            .Inject(uiData)
            .Inject(sceneData);

        // Finalizing stuff
        ecsSystems.Init();
    }

    // Update
    private void Update()
    {
        ecsSystems?.Run();
    }

    // Destroy
    private void Destroy()
    {
        if (ecsSystems != null)
        {
            ecsSystems.Destroy();
            ecsSystems = null;

            ecsWorld.Destroy();
            ecsWorld = null;
        }
    }
}
