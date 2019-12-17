using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct Player1PointData : IComponentData
{
    //Instantiates the necessary variable for Player1Point entities
    public float points;
    
}