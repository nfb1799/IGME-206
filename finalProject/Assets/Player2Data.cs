using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct Player2Data : IComponentData
{
    //Instantiates the necessary variables for a Player2 entity
    public float moves;
    public float score;
    
    
}
