using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class CubeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Speed;


    //Converts the cube to an entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        CubeData data = new CubeData
        {
            speed = Speed
        };

        dstManager.AddComponentData(entity, data);
    }
}
