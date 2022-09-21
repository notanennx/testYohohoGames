using Leopotam.Ecs;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class PickupSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<PickupEvent> ecsFilter;

    // Data
    private UIData uiData;
    
    // Process
    public void Run()
    {
        foreach (var i in ecsFilter)
        {
            // Get
            ref var pickupEvent = ref ecsFilter.Get1(i);
            ref var stackComponent = ref pickupEvent.TriggerEntity.Get<StackComponent>();

            // Have space?
            if (stackComponent.ItemsStack.Count < stackComponent.Capacity)
            {
                // Get
                Vector3 newPosition = new Vector3(0f, (0.25f * stackComponent.ItemsStack.Count), 0f);
                Transform itemTransfom = pickupEvent.VictimTransform;

                // Tweening
                itemTransfom.DOComplete();

                // Tweening
                itemTransfom.SetParent(stackComponent.AttachmentTransform);
                itemTransfom.DOLocalMove(itemTransfom.localPosition + new Vector3(0, 0.5f + newPosition.y, 0), 0.20f).OnComplete(() => {
                    itemTransfom.DOLocalMove(newPosition, 0.20f);
                });
                itemTransfom.DOLocalRotate(new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f)), 0.20f, RotateMode.LocalAxisAdd).OnComplete(() => {
                        itemTransfom.DOLocalRotate(new Vector3(90f, 90f, 0f), 0.20f);
                    });

                // Add
                stackComponent.ItemsStack.Push(pickupEvent.VictimTransform);
            }

            // Remove
            ref var pickupEntity = ref ecsFilter.GetEntity(i);
                pickupEntity.Destroy();
        }
    }
}