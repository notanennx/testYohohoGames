using System;
using UnityEngine;
using NaughtyAttributes;

[Serializable]
public class SpawnerData
{
    public int Amount;
    public float Cooldown;
    public Transform Transform;
    public ScriptableItem ScriptableItem;
}

public class SceneData : MonoBehaviour
{
    [BoxGroup("Main")] public Camera Camera;

    [BoxGroup("Player")] public Transform PlayerTransform;

    [BoxGroup("Spawners")] public SpawnerData[] ItemSpawners;
}