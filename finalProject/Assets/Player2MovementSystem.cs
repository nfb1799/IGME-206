using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class Player2MovementSystem : JobComponentSystem
{
    
    [BurstCompile]
    struct Player2MovementSystemJob : IJobForEach<Translation, Rotation, Player2Data>
    {
        //Instantiates the necessary variables for the job system
        public bool upPressed;
        public bool leftPressed;
        public bool downPressed;
        public bool rightPressed;
        public bool mousePressed;
        
        
        
        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation, ref Player2Data player2Data)
        {
            //Directs the Player2 entity around the board within the boundaries
            //Increments the number of moves the player has made
            if (upPressed && (translation.Value.y < 5.9))
            {
                translation.Value.y += 1;
                player2Data.moves += 1;
            }

            if (leftPressed && (translation.Value.x > 1))
            {
                translation.Value.x -= 1;
                player2Data.moves += 1;
            }

            if (downPressed && (translation.Value.y > -3.8))
            {
                translation.Value.y -= 1;
                player2Data.moves += 1;
            }

            if (rightPressed && (translation.Value.x < 9))
            {
                translation.Value.x += 1;
                player2Data.moves += 1;
            }

            //Increments the players score when the mouse button is pressed
            if (mousePressed)
                player2Data.score += 1;

        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new Player2MovementSystemJob();

        //Checks to see if any relevant buttons are being pressed
        job.upPressed = Input.GetKeyDown(KeyCode.UpArrow);
        job.leftPressed = Input.GetKeyDown(KeyCode.LeftArrow);
        job.downPressed = Input.GetKeyDown(KeyCode.DownArrow);
        job.rightPressed = Input.GetKeyDown(KeyCode.RightArrow);
        job.mousePressed = Input.GetKeyDown(KeyCode.Mouse0);
        
        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}