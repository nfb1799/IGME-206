using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class CubeSystem : JobComponentSystem
{
    

    [BurstCompile]
    struct CubeSystemJob : IJobForEach<Translation, Rotation, CubeData>
    {
        
        public bool WPressed;
        public bool APressed;
        public bool SPressed;
        public bool DPressed;

        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref CubeData cubeData)
        {
            //Moves the cube up and down depending on the speed of the cube
            if(WPressed && (translation.Value.y < 5.9))
            {
                translation.Value.y += 1;
                cubeData.y = translation.Value.y;
                cubeData.moves += 1;
            }

            if(APressed && (translation.Value.x > -9))
            {
                translation.Value.x -= 1;
                cubeData.x = translation.Value.x;
                cubeData.moves += 1;
            }

            if(SPressed && (translation.Value.y > -3.8))
            {
                translation.Value.y -= 1;
                cubeData.y = translation.Value.y;
                cubeData.moves += 1;
            }

            if(DPressed && (translation.Value.x < -1))
            {
                translation.Value.x += 1;
                cubeData.x = translation.Value.x;
                cubeData.moves += 1;
            }
            
            
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new CubeSystemJob();

        job.WPressed = Input.GetKeyDown("w");
        job.APressed = Input.GetKeyDown("a");
        job.SPressed = Input.GetKeyDown("s");
        job.DPressed = Input.GetKeyDown("d");

        return job.Schedule(this, inputDependencies);
    }
}