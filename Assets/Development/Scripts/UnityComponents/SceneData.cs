using System;
using UnityEngine;
using Leopotam.Ecs;
using NaughtyAttributes;

public class SceneData : MonoBehaviour
{
    [BoxGroup("Main")] public Camera Camera;

    [BoxGroup("Player")] public Transform PlayerTransform;

    [BoxGroup("Holders")] public Transform ItemsHolder;

    [BoxGroup("Spawners")] public float SpawnerCooldown;
    [BoxGroup("Spawners")] public ScriptableItem SpawnerScriptableItem;
}