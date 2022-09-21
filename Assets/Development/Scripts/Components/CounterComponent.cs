using UnityEngine;
using TMPro;
using Leopotam.Ecs;

public struct CounterComponent
{
    public TMP_Text Text;
    public Transform Transform;
    public Transform Attachment;
    public EcsEntity StackEntity;
}