﻿using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct CubeData : IComponentData
{
    //Instantiats the necessary data for cube entities
    public float speed;
}