using Leopotam.Ecs;
using UnityEngine;
using DG.Tweening;

public class DropzoneSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<StackComponent> ecsFilterStacks;
    private EcsFilter<DropzoneExitEvent> ecsFilterExit;
    private EcsFilter<DropzoneEnterEvent> ecsFilterEnter;

    // Misc
    private float nextStack;

    // Process
    public void Run()
    {
        // Loop exits
        foreach (var i in ecsFilterExit)
        {
            // Debug
            Debug.Log("Exited dropzone!");

            // Destroy
            ref var exitEventEntity = ref ecsFilterExit.GetEntity(i);
                exitEventEntity.Destroy();
        }

        // Loop enters
        foreach (var i in ecsFilterEnter)
        {
            // Debug
            Debug.Log("Enteed dropzone!");

            // Destroy
            ref var enteEventEntity = ref ecsFilterEnter.GetEntity(i);
                enteEventEntity.Destroy();
        }
    }

    // Process stack removal
    private void ProcessStacks()
    {
        // Exit
        if (nextStack > Time.time) return;

        // Loop enters
        foreach (var i in ecsFilterStacks)
        {
            // Get
            ref var stackComponent = ref ecsFilterStacks.Get1(i);
            if ((stackComponent.ItemsStack.Count > 0) && (stackComponent.Dropzone != EcsEntity.Null))
            {
                // Get
                Transform droppointTransform = stackComponent.Dropzone.Get<DropzoneComponent>().DroppointTransform;

                // Pick
                Transform itemTransform = stackComponent.ItemsStack.Pop();

                // Tweening
                itemTransform.DOComplete();
                itemTransform.SetParent(droppointTransform);

                itemTransform.DOLocalMove(Vector3.zero, 0.30f).OnComplete(() => {
                    itemTransform.DOScale(Vector3.zero, 0.30f).OnComplete(() => {
                        Object.Destroy(itemTransform.gameObject);
                    });
                });
            }
        }

        // Cooldown
        nextStack = (Time.time + 0.15f);
    }
}