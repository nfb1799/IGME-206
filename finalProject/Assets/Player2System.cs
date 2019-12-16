using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class Player2System : JobComponentSystem
{
    // This declares a new kind of job, which is a unit of work to do.
    // The job is declared as an IJobForEach<Translation, Rotation>,
    // meaning it will process all entities in the world that have both
    // Translation and Rotation components. Change it to process the component
    // types you want.
    //
    // The job is also tagged with the BurstCompile attribute, which means
    // that the Burst compiler will optimize it for the best performance.
    [BurstCompile]
    struct Player2SystemJob : IJobForEach<Translation, Rotation, Player2Data>
    {
        public bool upPressed;
        public bool leftPressed;
        public bool downPressed;
        public bool rightPressed;       
        
        
        
        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref Player2Data player2Data)
        {
            if (upPressed && (translation.Value.y < 5.9))
            {
                translation.Value.y += 1;
                player2Data.y = translation.Value.y;
                player2Data.moves += 1;
            }

            if (leftPressed && (translation.Value.x > 1))
            {
                translation.Value.x -= 1;
                player2Data.x = translation.Value.x;
                player2Data.moves += 1;
            }

            if (downPressed && (translation.Value.y > -3.8))
            {
                translation.Value.y -= 1;
                player2Data.y = translation.Value.y;
                player2Data.moves += 1;
            }

            if (rightPressed && (translation.Value.x < 9))
            {
                translation.Value.x += 1;
                player2Data.x = translation.Value.x;
                player2Data.moves += 1;
            }


        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new Player2SystemJob();

        job.upPressed = Input.GetKeyDown(KeyCode.UpArrow);
        job.leftPressed = Input.GetKeyDown(KeyCode.LeftArrow);
        job.downPressed = Input.GetKeyDown(KeyCode.DownArrow);
        job.rightPressed = Input.GetKeyDown(KeyCode.RightArrow);
        
        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}