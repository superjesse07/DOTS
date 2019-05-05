using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class Bootstrap : MonoBehaviour
{
    public float speed;
    public GameObject Prefab;
    public Entity e;

    void Start()
    {
        var manager = World.Active.EntityManager;
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, World.Active);

        Entity player = manager.Instantiate(prefab);
        manager.SetComponentData(player, new Translation() { Value = new float3(0, 0, 0) });
        manager.AddComponentData(player, new MovementSpeed() { Value = speed });
        manager.AddComponentData(player, new PlayerInput());

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = (Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None);
    }
}
