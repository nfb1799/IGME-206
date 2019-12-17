using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct Player1Data : IComponentData
{
    //Instantiate the necessary data for Player1 entities
    public float moves;
    public float score;
}