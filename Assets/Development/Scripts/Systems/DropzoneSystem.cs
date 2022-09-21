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
        // Stacking
        ProcessStacks();

        // Collission
        ProcessExits();
        ProcessEnters();
    }

    // Processes exits collission
    private void ProcessExits()
    {
        // Loop
        foreach (var i in ecsFilterExit)
        {
            // Destroy
            ref var exitEventEntity = ref ecsFilterExit.GetEntity(i);
                exitEventEntity.Destroy();
        } 
    }

    // Processes enters collission
    private void ProcessEnters()
    {
        foreach (var i in ecsFilterEnter)
        {
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
                itemTransform.GetComponent<BoxCollider>().enabled = false;

                // Tweening
                itemTransform.DOComplete();
                itemTransform.SetParent(droppointTransform);

                itemTransform.DOLocalMove(itemTransform.localPosition + new Vector3(0, 2.0f, 0), 0.20f).OnComplete(() => {
                    itemTransform.DOLocalMove(Vector3.zero, 0.20f).OnComplete(() => {
                        itemTransform.DOScale(Vector3.zero, 0.30f).OnComplete(() => {
                            itemTransform.GetComponent<ItemView>().Entity.Destroy();
                            Object.Destroy(itemTransform.gameObject);
                        });
                    });

                    itemTransform.DOLocalRotate(new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f)), 0.20f, RotateMode.LocalAxisAdd).OnComplete(() => {
                            itemTransform.DOLocalRotate(new Vector3(90f, 90f, 0f), 0.20f);
                    });
                });
            }
        }

        // Cooldown
        nextStack = (Time.time + 0.15f);
    }
}