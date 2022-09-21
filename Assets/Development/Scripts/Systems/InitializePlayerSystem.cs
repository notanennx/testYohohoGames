using Leopotam.Ecs;
using UnityEngine;

public class InitializePlayerSystem : IEcsInitSystem
{
    // Main
    private EcsWorld ecsWorld;

    // Data
    private SceneData sceneData;

    // Initialize
    public void Init()
    {
        // Install player
        EcsEntity playerEntity = ecsWorld.NewEntity();
            ref var moveComponent = ref playerEntity.Get<MoveComponent>();
            ref var inputComponent = ref playerEntity.Get<InputComponent>(); 
            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref var animatorComponent = ref playerEntity.Get<AnimatorComponent>();

            // Fill data
                // Anims
                animatorComponent.Animator = sceneData.PlayerTransform.GetComponentInChildren<Animator>();

                // Movement
                moveComponent.Transform = sceneData.PlayerTransform;
                moveComponent.MoveSpeed = 4.8f;
                moveComponent.RotateSpeed = 6.4f;
                moveComponent.CharacterController = sceneData.PlayerTransform.GetComponent<CharacterController>();
    }
}