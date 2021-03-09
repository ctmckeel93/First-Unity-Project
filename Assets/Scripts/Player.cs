using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private int superJumps;

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           jumpKeyPressed = true;
            
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdatee is called once every physics update
    void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position,0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (jumpKeyPressed)
        {
            float jumpPower = 5;
            if (superJumps != 0)
            {
                jumpPower = 8;
            }
            rigidBodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            superJumps--;
            if (superJumps < 0)
            {
                superJumps = 0;
            }
            Debug.Log(superJumps);
            jumpKeyPressed = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumps++;
            Debug.Log(superJumps);
        }

    }

    
}
