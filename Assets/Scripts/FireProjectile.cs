using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public Rigidbody Projectile;
    public float Speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody p = Instantiate(Projectile, transform.position, transform.rotation);
            p.velocity = transform.forward * Speed;

        }
    }
}
