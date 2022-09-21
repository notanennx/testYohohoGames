using Leopotam.Ecs;
using UnityEngine;

public class MovementSystem : IEcsRunSystem
{
    // Main
    private EcsWorld ecsWorld;
    private EcsFilter<MoveComponent> ecsFilter;

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

                // Move
                Vector3 targetPosition = ConvertoToIso(moveComponent.TargetPosition * (moveComponent.MoveSpeed * Time.deltaTime));
                    moveComponent.CharacterController.Move(targetPosition);

                // Rotate
                Vector3 newDirection = Vector3.RotateTowards(moveComponent.Transform.forward, targetPosition, (moveComponent.RotateSpeed * Time.deltaTime), 0f);
                    Quaternion targetRotation = Quaternion.LookRotation(newDirection);
                        targetRotation.x = 0;
                        targetRotation.z = 0;

                    moveComponent.Transform.rotation = targetRotation;
        }
    }

    // Converts movement vector to isometric vector;
    private Vector3 ConvertoToIso(Vector3 inputVector)
    {
        Quaternion rotation = Quaternion.Euler(0, sceneData.Camera.transform.localEulerAngles.y, 0);
        Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);
        Vector3 result = isoMatrix.MultiplyPoint3x4(inputVector);

        return result;
    }
}