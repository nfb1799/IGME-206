using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class BulletAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Speed;

    //Converts the bullet to an entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        BulletData data = new BulletData
        {
            speed = Speed
        };

        dstManager.AddComponentData(entity, data);

    }
}
