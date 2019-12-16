using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class CollisionSystem : JobComponentSystem
{
 
    [BurstCompile]
    struct CollisionSystemJob : IJobForEachWithEntity<Translation, Rotation, CubeData, BulletData>
    {
         
        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref CubeData cubeData, [ReadOnly] ref BulletData bulletData)
        {
            if(math.floor(cubeData.x) == math.floor(bulletData.x))
            {
                cubeData.beenHit = true;
            }
            
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new CollisionSystemJob();
        
        return job.Schedule(this, inputDependencies);
    }
}