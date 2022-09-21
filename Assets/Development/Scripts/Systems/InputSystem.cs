using Leopotam.Ecs;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<InputComponent, MoveComponent> ecsFilter;

    // Data
    private UIData uiData;
    
    // Process
    public void Run()
    {
        // Loop
        foreach (var i in ecsFilter)
        {
            ref var inputComponent = ref ecsFilter.Get1(i);
                inputComponent.MoveInput = new Vector3(uiData.Joystick.Horizontal, 0, uiData.Joystick.Vertical);

            ref var moveComponent = ref ecsFilter.Get2(i);
                moveComponent.TargetPosition = (inputComponent.MoveInput.normalized);
        }
    }
}