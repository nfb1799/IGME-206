using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class WaveAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float InitialHeight;
    public float Frequency;
    public float Amplitude;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        // set up the initial data
        WaveData data = new WaveData
        {
            initialHeight = InitialHeight,
            amplitude = Amplitude,
            frequency = Frequency
        };

        // add it to the entity
        dstManager.AddComponentData(entity, data);


    }
}
