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
    void Init()
    {        
        ecsWorld = new EcsWorld();
        ecsSystems = new EcsSystems(ecsWorld);

        // Adding stuff
        ecsSystems
            .Inject(uiData)
            .Inject(sceneData);

        // Finalizing stuff
        ecsSystems.Init();
    }

    // Update
    void UpdateLoop()
    {
        ecsSystems?.Run();
    }

    // Destroy
    void Destroy()
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
