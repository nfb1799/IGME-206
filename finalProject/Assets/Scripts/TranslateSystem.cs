using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class TranslationSystem : JobComponentSystem
{
    public static float totalTime = 0;

    [BurstCompile]
    [RequireComponentTag(typeof(TranslateOnlyTag))]
    struct BouncingSystemJob : IJobForEach<Translation, Rotation, WaveData>
    {
        public float time;



        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, [ReadOnly] ref WaveData waveData)
        {
            float x = math.abs(waveData.amplitude * math.sin(PI * waveData.frequency * time)) + waveData.initialHeight;
            translation.Value.x = x;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new BouncingSystemJob();

        // bouncing requires a summation of the delta time's from Unity
        totalTime += UnityEngine.Time.deltaTime;
        job.time = totalTime;


        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}