using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class Player1Authoring : MonoBehaviour, IConvertGameObjectToEntity
{
    //Creates necessary variables for a Player1 Entity
    public float Moves;
    public float Score;

    //Converts the Player1 to an entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Player1Data data = new Player1Data
        {
            moves = Moves,
            score = Score
        };

        //Stores the entity in the entity manager
        dstManager.AddComponentData(entity, data);
    }
}

