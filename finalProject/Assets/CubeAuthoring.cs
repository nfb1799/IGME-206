using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class CubeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float X;
    public float Y;
    public float Moves;
    public bool BeenHit;

    //Converts the cube to an entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        CubeData data = new CubeData
        {
            x = X,
            y = Y,
            moves = Moves,
            beenHit = BeenHit
        };

        dstManager.AddComponentData(entity, data);
    }
}
