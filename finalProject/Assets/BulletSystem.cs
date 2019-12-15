using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class BulletSystem : JobComponentSystem
{
    public static float totalTime = 0;

    [BurstCompile]
    struct BulletSystemJob : IJobForEach<Translation, Rotation, BulletData>
    {
        public float time;

        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, [ReadOnly] ref BulletData bulletData)
        {
            //Moves any bullet entities left and right based on their speed
            float x = bulletData.speed * math.sin(PI * time);
            translation.Value.x = x;


        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new BulletSystemJob();

        totalTime += UnityEngine.Time.deltaTime;
        job.time = totalTime;

        return job.Schedule(this, inputDependencies);
    }
}