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
            ref var stackComponent = ref playerEntity.Get<StackComponent>();
            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref var animatorComponent = ref playerEntity.Get<AnimatorComponent>();

            // Fill stack
            //playerGO.GetComponentInChildren<CollisionCheckerView>().ecsWorld = ecsWorld;

            // Fill data
                // Stack
                ItemCollissionChecker itemCollissionChecker = sceneData.PlayerTransform.GetComponentInChildren<ItemCollissionChecker>();
                    itemCollissionChecker.EcsWorld = ecsWorld;

                stackComponent.Capacity = 8;
                stackComponent.Transform = itemCollissionChecker.transform;
                stackComponent.AttachmentTransform = stackComponent.Transform.GetChild(0);

                // Anims
                animatorComponent.Animator = sceneData.PlayerTransform.GetComponentInChildren<Animator>();

                // Movement
                moveComponent.Transform = sceneData.PlayerTransform;
                moveComponent.MoveSpeed = 4.8f;
                moveComponent.RotateSpeed = 6.4f;
                moveComponent.CharacterController = sceneData.PlayerTransform.GetComponent<CharacterController>();
    }
}