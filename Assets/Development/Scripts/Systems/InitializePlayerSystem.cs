using TMPro;
using Leopotam.Ecs;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitializePlayerSystem : IEcsInitSystem
{
    // Main
    private EcsWorld ecsWorld;

    // Data
    private UIData uiData;
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
                // Movement
                moveComponent.Transform = sceneData.PlayerTransform;
                moveComponent.MoveSpeed = 4.8f;
                moveComponent.RotateSpeed = 6.4f;
                moveComponent.CharacterController = sceneData.PlayerTransform.GetComponent<CharacterController>();
                
                // Anims
                animatorComponent.Animator = sceneData.PlayerTransform.GetComponentInChildren<Animator>();

        // Install stacking
        EcsEntity stackEntity = ecsWorld.NewEntity();
            ref var stackComponent = ref stackEntity.Get<StackComponent>();

                // Dropper
                DropzoneCollissionChecker dropzoneCollissionChecker = sceneData.PlayerTransform.GetComponentInChildren<DropzoneCollissionChecker>();
                    dropzoneCollissionChecker.EcsWorld = ecsWorld;
                    dropzoneCollissionChecker.OwnerEntity = stackEntity;

                // Stacking
                ItemCollissionChecker itemCollissionChecker = sceneData.PlayerTransform.GetComponentInChildren<ItemCollissionChecker>();
                    itemCollissionChecker.EcsWorld = ecsWorld;
                    itemCollissionChecker.TriggerEntity = stackEntity;

                stackComponent.Capacity = 16;
                stackComponent.Transform = itemCollissionChecker.transform;
                stackComponent.ItemsStack = new Stack<Transform>();
                stackComponent.AttachmentTransform = stackComponent.Transform.GetChild(0);

                // Add counter
                AddStackCounter(stackEntity);
    }

    // Adds a stack counter to player
    private void AddStackCounter(EcsEntity inputStackEntity)
    {
        // Stack counter
        CounterView stackCounter = Object.Instantiate(uiData.CounterPrefab, uiData.CounterHolder).GetComponent<CounterView>();

            // Entitize
            EcsEntity stackCounterEntity = ecsWorld.NewEntity();
                ref var stackCounterComponent = ref stackCounterEntity.Get<CounterComponent>();
                    stackCounterComponent.Text = stackCounter.GetComponentInChildren<TMP_Text>();
                    stackCounterComponent.Text.text = string.Format(uiData.CounterFormat,
                        inputStackEntity.Get<StackComponent>().ItemsStack.Count,
                        inputStackEntity.Get<StackComponent>().Capacity);

                    stackCounterComponent.Transform = stackCounter.transform;
                    stackCounterComponent.Attachment = inputStackEntity.Get<StackComponent>().Transform;
                    stackCounterComponent.StackEntity = inputStackEntity;

            // Attaching
            stackCounter.Entity = stackCounterEntity;
            inputStackEntity.Get<StackComponent>().CounterEntity = stackCounterEntity;
    }
}