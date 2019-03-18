using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public float followSpeed = 0.2f;
    Camera mainCamera;
    public GameObject player;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(player.transform.position.x ,mainCamera.transform.position.y, player.transform.position.z - 2), followSpeed);
    }
}
