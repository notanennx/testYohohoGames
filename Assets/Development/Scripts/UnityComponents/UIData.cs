using UnityEngine;
using NaughtyAttributes;

public class UIData : MonoBehaviour
{
    [BoxGroup("Input")] public Joystick Joystick;

    [BoxGroup("Counters")] public string CounterFormat;
    [BoxGroup("Counters")] public Vector3 CounterPosition;
    [BoxGroup("Counters")] public Transform CounterHolder;
    [BoxGroup("Counters")] public GameObject CounterPrefab;
}