using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class Player1MovementSystem : JobComponentSystem
{
    
    
    [BurstCompile]
    struct Player1MovementSystemJob : IJobForEach<Translation, Rotation, Player1Data>
    {
        //Instantiates the necessary variables for the job system
        public bool WPressed;
        public bool APressed;
        public bool SPressed;
        public bool DPressed;
        public bool spacePressed;

        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref Player1Data player1Data)
        {
            
            //Directs movement of Player1 within the necessary boundaries
            //Counts the number of moves the player makes
            if(WPressed && (translation.Value.y < 5.9))
            {
                translation.Value.y += 1;
                player1Data.moves += 1;
            }

            if(APressed && (translation.Value.x > -9))
            {
                translation.Value.x -= 1;
                player1Data.moves += 1;
            }

            if(SPressed && (translation.Value.y > -3.8))
            {
                translation.Value.y -= 1;
                player1Data.moves += 1;
            }

            if(DPressed && (translation.Value.x < -1))
            {
                translation.Value.x += 1;
                player1Data.moves += 1;
            }

            //Increments the players score when they get the point
            if (spacePressed)
                player1Data.score += 1;
            
            
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new Player1MovementSystemJob();

        //Checks to see if any keys are pressed.
        job.WPressed = Input.GetKeyDown("w");
        job.APressed = Input.GetKeyDown("a");
        job.SPressed = Input.GetKeyDown("s");
        job.DPressed = Input.GetKeyDown("d");
        job.spacePressed = Input.GetKeyDown(KeyCode.Space);

        return job.Schedule(this, inputDependencies);
    }
}