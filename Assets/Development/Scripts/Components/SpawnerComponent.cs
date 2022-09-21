using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct SpawnerComponent
{
    public int Amount;
    public int MaxAmount;
    public float Cooldown;
    public float NextSpawn;
    public Transform Transform;
    public ScriptableItem ScriptableItem;
    public List<Transform> SpawnPositions;
}