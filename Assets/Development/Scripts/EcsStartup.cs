using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class EcsStartup : MonoBehaviour
{
    // Main
    private EcsWorld ecsWorld;
    private EcsSystems ecsSystems;

    // Initialize
    void Init()
    {        
        ecsWorld = new EcsWorld();
        ecsSystems = new EcsSystems(ecsWorld);
        ecsSystems
            .Init();
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
