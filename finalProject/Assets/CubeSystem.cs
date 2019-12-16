using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class CubeSystem : JobComponentSystem
{
    public static float totalTime = 0;

    [BurstCompile]
    struct CubeSystemJob : IJobForEach<Translation, Rotation, CubeData>
    {
        public float time;



        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref CubeData cubeData)
        {
            //Moves the cube up and down depending on the speed of the cube
            float y = cubeData.speed * math.sin(PI * time);
            translation.Value.y = y;
            cubeData.y = y;
            cubeData.x = translation.Value.x;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new CubeSystemJob();

        totalTime += UnityEngine.Time.deltaTime;
        job.time = totalTime;

        return job.Schedule(this, inputDependencies);
    }
}