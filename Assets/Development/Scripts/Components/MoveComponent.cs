using UnityEngine;

public struct MoveComponent
{
    public float MoveSpeed;
    public float RotateSpeed;
    public Vector3 TargetPosition;
    public Animator Animator;
    public Transform Transform;
    public CharacterController CharacterController;
}