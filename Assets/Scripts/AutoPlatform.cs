using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlatform : MonoBehaviour
{
    [SerializeField] private Transform downPos, upPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform initialPos;

    private Vector3 targetPos;

    void Start()
    {
        targetPos = initialPos.position;
    }
     
    // Update is called once per frame
    void Update()
    {
        if (transform.position == downPos.position)
        {
            targetPos = upPos.position;
        }
        if (transform.position == upPos.position)
        {
            targetPos = downPos.position;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
    }
}
