using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class Player2PointSystem : JobComponentSystem
{
    
    [BurstCompile]
    struct Player2PointSystemJob : IJobForEach<Translation, Rotation, Player2PointData>
    {
        //Instantiates the necessary variable for the job
        public bool mousePressed;


        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref Player2PointData player2PointData)
        {
            //Moves the point entity around the board in set positions until the player reaches 5 points
            //Increments the count each time the mouse button is clicked
            if (mousePressed)
            {
                if (player2PointData.points == 0)
                {
                    translation.Value.x = 8f;
                    translation.Value.y = 4.2f;
                    player2PointData.points += 1;
                }
                else if (player2PointData.points == 1)
                {
                    translation.Value.x = 6f;
                    translation.Value.y = -2.8f;
                    player2PointData.points += 1;
                }
                else if (player2PointData.points == 2)
                {
                    translation.Value.x = 1f;
                    translation.Value.y = 6.2f;
                    player2PointData.points += 1;
                }
                else if (player2PointData.points == 3)
                {
                    translation.Value.x = 3f;
                    translation.Value.y = 0.2f;
                    player2PointData.points += 1;
                }
                else if (player2PointData.points == 4)
                {
                    translation.Value.x = 9f;
                    translation.Value.y = -3.8f;
                    player2PointData.points += 1;
                }
            }


        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new Player2PointSystemJob();


        //Checks to see if the left mouse button is pressed
        job.mousePressed = Input.GetKeyDown(KeyCode.Mouse0);



        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}