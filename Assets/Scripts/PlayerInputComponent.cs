using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct PlayerInput : IComponentData
{
    public float vertical;
    public Vector2 mouse;
    
}
