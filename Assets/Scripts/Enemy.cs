using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody body;
    Renderer myRender;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if(fpsTargetDistance < enemyLookDistance)
        {
            
            LookAtPlayer();
            print("Lookie here!");
            myRender.material.color = Color.yellow;
        }

        if(fpsTargetDistance < attackDistance)
        {
            myRender.material.color = Color.red;
            print("ATTACK!");
            AttackPlayer();
        }

        else
        {
            myRender.material.color = Color.white;
        }
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void AttackPlayer()
    {
        body.AddForce(transform.forward*enemyMovementSpeed);
    }
}
