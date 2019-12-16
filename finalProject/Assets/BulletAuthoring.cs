using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class BulletAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Speed;
    public float X;
    public float Y;

    //Converts the bullet to an entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        BulletData data = new BulletData
        {
            speed = Speed,
            x = X,
            y = Y
        };

        dstManager.AddComponentData(entity, data);

    }
}
