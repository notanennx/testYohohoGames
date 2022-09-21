using System;
using UnityEngine;
using System.Collections;

public struct SpawnerComponent
{
    public int Amount;
    public int MaxAmount;
    public float Cooldown;
    public float NextSpawn;
    public Transform Transform;
    public ScriptableItem ScriptableItem;
}