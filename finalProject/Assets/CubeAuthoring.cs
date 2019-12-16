using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class CubeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Speed;
    public float X;
    public float Y;
    public bool BeenHit;

    //Converts the cube to an entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        CubeData data = new CubeData
        {
            speed = Speed,
            x = X,
            y = Y,
            beenHit = BeenHit
        };

        dstManager.AddComponentData(entity, data);
    }
}
