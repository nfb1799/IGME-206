using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class Player2Authoring : MonoBehaviour, IConvertGameObjectToEntity
{
    //Instantiates the necessary variables for a Player2 entity
    public float Moves;
    public float Score;
    
    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Player2Data data = new Player2Data
        {
            moves = Moves,
            score = Score
        };

        //Adds the entity to the entity manager
        dstManager.AddComponentData(entity, data);
    }
}
