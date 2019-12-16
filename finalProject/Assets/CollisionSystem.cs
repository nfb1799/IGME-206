using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class CollisionSystem : JobComponentSystem
{
    public static float totalTime = 0;

    [BurstCompile]
    struct CollisionSystemJob : IJobForEach<Translation, Rotation, CubeData, BulletData>
    {
        public float time;
        
        
        
        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref CubeData cubeData, ref BulletData bulletData)
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
        
        totalTime += UnityEngine.Time.deltaTime;
        job.time = totalTime;

        return job.Schedule(this, inputDependencies);
    }
}