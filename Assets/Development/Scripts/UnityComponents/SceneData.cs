using UnityEngine;
using NaughtyAttributes;

public class SceneData : MonoBehaviour
{
    [BoxGroup("Main")] public Camera Camera;
    
    [BoxGroup("Player")] public Transform PlayerTransform;
}