using Leopotam.Ecs;
using UnityEngine;

public class CounterSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<CounterEvent> ecsFilterEvents;
    private EcsFilter<CounterComponent> ecsFilterCounters;

    // Data
    private UIData uiData;
    private SceneData sceneData;

    // Process
    public void Run()
    {
        // Loop events
        foreach (var i in ecsFilterEvents)
        {
            // Get
            ref var eventComponent = ref ecsFilterEvents.Get1(i);

            // New
            string newAmount = string.Format(uiData.CounterFormat, eventComponent.Amount.ToString(), eventComponent.StackEntity.Get<StackComponent>().Capacity);

            // Update
            eventComponent.CounterEntity.Get<CounterComponent>().Text.text = newAmount;

            // Remove
            ref var eventEntity = ref ecsFilterEvents.GetEntity(i);
                eventEntity.Destroy();
        }

        // Loop counters
        foreach (var i in ecsFilterCounters)
        {
            // Get
            ref var counterComponent = ref ecsFilterCounters.Get1(i);
            int curAmount = Mathf.Max(0, counterComponent.StackEntity.Get<StackComponent>().ItemsStack.Count - 5);

            Vector3 newHeight = new Vector3(0f, (0.6f * curAmount), 0f);
            Vector3 newPosition = sceneData.Camera.WorldToScreenPoint((counterComponent.Attachment.position + newHeight + uiData.CounterPosition));

            // Moving
            counterComponent.Transform.position = Vector3.Lerp(counterComponent.Transform.position, newPosition, (8f * Time.deltaTime));
        }
    }
}