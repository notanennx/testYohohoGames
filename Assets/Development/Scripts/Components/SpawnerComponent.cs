using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct SpawnerComponent
{
    public float Cooldown;
    public float NextSpawn;
    public Transform Transform;
    public GameObject PrefabToSpawn;
    //public ScriptableItem ScriptableItem;
    public List<Transform> SpawnPositions;
}