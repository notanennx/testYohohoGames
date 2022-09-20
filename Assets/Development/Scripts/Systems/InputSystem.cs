using Leopotam.Ecs;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<InputComponent, MoveComponent> filter;

    // Data
    private UIData uiData;
    
    // Process
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var inputComponent = ref filter.Get1(i);
                inputComponent.MoveInput = new Vector3(uiData.Joystick.Horizontal, 0, uiData.Joystick.Vertical);

            ref var moveComponent = ref filter.Get2(i);
                moveComponent.TargetPosition = (inputComponent.MoveInput.normalized);
        }
    }
}