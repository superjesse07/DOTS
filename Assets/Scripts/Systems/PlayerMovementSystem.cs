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
    struct PlayerMovementSystemJob : IJobForEach<PlayerInput,PhysicsVelocity,MovementSpeed,Rotation>
    {

        public void Execute(ref PlayerInput pi, ref PhysicsVelocity vel,ref MovementSpeed speed,ref Rotation rot)
        {
            quaternion q = rot.Value;
            
            vel.Linear = pi.vertical * math.forward(q) * speed.Value;
            vel.Angular = float3(0, 1, 0) * pi.mouse.x + float3(1, 0, 0) * pi.mouse.y;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new PlayerMovementSystemJob();
        
        return job.Schedule(this, inputDependencies);
    }
}