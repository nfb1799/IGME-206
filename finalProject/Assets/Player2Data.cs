using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct Player2Data : IComponentData
{
    public float x;
    public float y;
    public float moves;
    public float score;
    
    
}
