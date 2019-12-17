using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class Player1PointAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    //Instantiates the necessary variable for a Point entity
    public float Points;
    
    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Player1PointData data = new Player1PointData
        {
            points = Points
        };

        //Adds the entity to the entity manager
        dstManager.AddComponentData(entity, data);
    }
}
