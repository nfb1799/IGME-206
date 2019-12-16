using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject Prefab;
    public int CountX = 10;
    public int CountY = 10;

    void Start()
    {
        Unity.Mathematics.Random rand = new Unity.Mathematics.Random(42);

        // Create entity prefab from the game object hierarchy once
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, World.Active);
        var entityManager = World.Active.EntityManager;

        for (var x = 0; x < CountX; x++)
        {
            for (var y = 0; y < CountY; y++)
            {
                // Efficiently instantiate a bunch of entities from the already converted entity prefab
                var instance = entityManager.Instantiate(prefab);

                // Place the instantiated entity in a grid with some noise
                var position = transform.TransformPoint(new float3(x,y,0));
                entityManager.SetComponentData(instance, new Translation { Value = position });
                BulletData data = new BulletData { speed = rand.NextInt() % 10 };
                entityManager.SetComponentData(instance, data);
            }
        }
    }
}

