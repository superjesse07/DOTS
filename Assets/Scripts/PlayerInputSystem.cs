using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class PlayerInputSystem : JobComponentSystem
{
    [BurstCompile]
    struct PlayerInputSystemJob : IJobForEach<PlayerInput>
    {

        public float vertical;
        public Vector2 mouse;

        public void Execute(ref PlayerInput pi)
        {
            pi.mouse = mouse;
            pi.vertical = vertical;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new PlayerInputSystemJob();
        job.vertical = Input.GetAxis("Vertical");
        job.mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        return job.Schedule(this, inputDependencies);
    }
}