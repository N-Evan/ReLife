using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            //transform.position = playerTransform.position;

            //can't directly apply player position to camera position??? 

            Vector3 tempCameraPos = transform.position;
            tempCameraPos.x = playerTransform.position.x;
            tempCameraPos.y = playerTransform.position.y;
            transform.position = tempCameraPos;
        }
        
    }
}
