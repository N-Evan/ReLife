//Unused. Makes Unity crash smh? 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 roamPos;
    private float distCheck;

    private float xDirection;
    private float movementSpeed;
    private bool rightFacing = true;

    private Rigidbody2D rigidBody;
    
    private void Start()
    {
        startPos = transform.position;
        roamPos = GetRoamingPosition();
        distCheck = DistanceToPosition();

        getXDirection();
        movementSpeed = 1f;

        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //set targetPos 
        //Enemy Movement Script Missing 
        moveAround();
    }

    private Vector3 GetRoamingPosition()
    {

        //startPos -> applying the randomVector to initial pos
        //randoming only on X
        //limiting distance 
        return startPos + (new Vector3(UnityEngine.Random.Range(-1f, 1f), startPos.y).normalized) * Random.Range(5f, 10f) ; 
    }

    private float DistanceToPosition ()
    {
        return Vector3.Distance(transform.position, roamPos);
    }

    private void getXDirection ()
    {
        if (roamPos.x > 0 && !rightFacing)
        {
            xDirection = 1f;
            rightFacing = !rightFacing;
        }
        if (roamPos.x < 0 && rightFacing)
        {
            xDirection = -1f;
            rightFacing = !rightFacing;
        }
    }

    private void moveAround()
    {
        while (distCheck > 1f)
        {
            transform.Translate(roamPos);
        }
        startPos = transform.position;
        roamPos = GetRoamingPosition();
        distCheck = DistanceToPosition();
        getXDirection();
    }
}
