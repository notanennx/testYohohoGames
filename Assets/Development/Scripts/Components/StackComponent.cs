using System;
using Leopotam.Ecs;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct StackComponent
{
    public int Capacity;
    public Transform Transform;
    public Transform AttachmentTransform;
    public Stack<Transform> ItemsStack;
}