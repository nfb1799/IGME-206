using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct BulletData : IComponentData
{
    //Instantiates the necessary data for bullet entities
    public float speed;
    public float x;
    public float y;
    
}
