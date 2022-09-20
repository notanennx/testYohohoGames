using Leopotam.Ecs;
using UnityEngine;

public class MovementSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<MoveComponent> filter;

    // Process
    public void Run()
    {
        foreach (var i in filter)
        {
            // Get
            ref var moveComponent = ref filter.Get1(i);

                // Move
                moveComponent.CharacterController.Move(moveComponent.TargetPosition * (moveComponent.MoveSpeed * Time.deltaTime));

                // Rotate
                Vector3 newDirection = Vector3.RotateTowards(moveComponent.Transform.forward, moveComponent.TargetPosition, (moveComponent.RotateSpeed * Time.deltaTime), 0f);
                    Quaternion targetRotation = Quaternion.LookRotation(newDirection);
                        targetRotation.x = 0;
                        targetRotation.z = 0;

                    moveComponent.Transform.rotation = targetRotation;


            /*
            if (moveComponent.IsMoving())
            {
                // Non npcs only
                if (!moveComponent.IsNpc())
                {
                    // Get
                    Vector3 newPosition = new Vector3(moveComponent.GetMovement().x, 0f, moveComponent.GetMovement().y).normalized;
                    Vector3 newDirection = Vector3.RotateTowards(moveComponent.transform.forward, newPosition, (moveComponent.GetRotationSpeed() * Time.deltaTime), 0f);
                
                    // Angle
                    Quaternion targetRotation = Quaternion.LookRotation(newDirection);
                        targetRotation.x = 0;
                        targetRotation.z = 0;

                    // Movement
                    moveComponent.transform.rotation = targetRotation;
                    moveComponent.Move(newPosition);
                }

                // Animation
                moveComponent.GetAnimator().SetBool("IsMoving", true);
            }
            else
            {
                // Animation
                moveComponent.GetAnimator().SetBool("IsMoving", false);
            }
            */
        }
    }
}