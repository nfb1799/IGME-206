using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class Player1PointSystem : JobComponentSystem
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
    struct Player1PointSystemJob : IJobForEach<Translation, Rotation, Player1PointData>
    {
        public bool spacePressed;


        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref Player1PointData player1PointData)
        {
            //Moves the points around the board in set positions when the player presses space
            //Increments the number of times the point has been hit each time
            if (spacePressed)
            {
                if (player1PointData.points == 0)
                {
                    translation.Value.x = -8f;
                    translation.Value.y = 4.2f;
                    player1PointData.points += 1;
                }
                else if (player1PointData.points == 1)
                {
                    translation.Value.x = -6f;
                    translation.Value.y = -2.8f;
                    player1PointData.points += 1;
                }
                else if (player1PointData.points == 2)
                {
                    translation.Value.x = -1f;
                    translation.Value.y = 6.2f;
                    player1PointData.points += 1;
                }
                else if (player1PointData.points == 3)
                {
                    translation.Value.x = -3f;
                    translation.Value.y = 0.2f;
                    player1PointData.points += 1;
                }
                else if (player1PointData.points == 4)
                {
                    translation.Value.x = -9f;
                    translation.Value.y = -3.8f;
                    player1PointData.points += 1;
                }
            }


        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new Player1PointSystemJob();


        //Checks to see if the space bar is pressed
        job.spacePressed = Input.GetKeyDown(KeyCode.Space);



        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}