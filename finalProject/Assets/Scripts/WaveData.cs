using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct WaveData : IComponentData
{
    public float initialHeight; // initial y pos
    public float amplitude;
    public float frequency;
}
