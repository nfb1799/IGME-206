using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class Player2PointAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    //Instantiates the necessary variable for a Player2Point entity
    public float Points;
    
    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Player2PointData data = new Player2PointData
        {
            points = Points
        };

        //Adds the entity to the manager
        dstManager.AddComponentData(entity, data);
    }
}
