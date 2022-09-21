using Leopotam.Ecs;
using UnityEngine;

public class AnimationSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<MoveComponent, AnimatorComponent> ecsFilter;

    // Data
    private SceneData sceneData;

    // Process
    public void Run()
    {
        // Loop
        foreach (var i in ecsFilter)
        {
            // Get
            ref var moveComponent = ref ecsFilter.Get1(i);
            ref var animatorComponent = ref ecsFilter.Get2(i);

            // Setup
            if (moveComponent.TargetPosition.sqrMagnitude > 0)
                animatorComponent.Animator.SetBool("IsMoving", true);
            else
                animatorComponent.Animator.SetBool("IsMoving", false);
        }
    }
}