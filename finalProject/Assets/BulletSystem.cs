using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class BulletSystem : JobComponentSystem
{
    public static float totalTime = 0;
    

    [BurstCompile]
    struct BulletSystemJob : IJobForEach<Translation, Rotation, BulletData>
    {
        public float time;
        public bool isWPressed;

        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref BulletData bulletData)
        {
            //Moves any bullet entities left and right based on their speed
            float x = bulletData.speed * math.sin(PI * time);
            if (isWPressed)
            { 
                translation.Value.x = x;
                bulletData.x = x;
                bulletData.y = translation.Value.y;
            }

        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new BulletSystemJob();

        totalTime += UnityEngine.Time.deltaTime;
        job.time = totalTime;
        job.isWPressed = Input.GetKeyDown("w");

        return job.Schedule(this, inputDependencies);
    }
}