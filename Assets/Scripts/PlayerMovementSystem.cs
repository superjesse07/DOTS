using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;
using Unity.Physics;
using UnityEngine;
public class PlayerMovementSystem : JobComponentSystem
{
    [BurstCompile]
    struct PlayerMovementSystemJob : IJobForEach<PlayerInput,PhysicsVelocity,MovementSpeed>
    {

        public void Execute(ref PlayerInput pi, ref PhysicsVelocity vel,ref MovementSpeed speed)
        {

            vel.Linear = pi.vertical * new float3(0, 0, 1) * speed.Value;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new PlayerMovementSystemJob();
        
        return job.Schedule(this, inputDependencies);
    }
}