using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class Player2Authoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float X;
    public float Y;
    public float Moves;
    public float Score;
    
    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Player2Data data = new Player2Data
        {
            x = X,
            y = Y,
            moves = Moves,
            score = Score
        };

        dstManager.AddComponentData(entity, data);
    }
}
