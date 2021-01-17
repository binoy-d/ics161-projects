using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    public float speed; //Floating point variable to store the player's movement speed.
    public Rigidbody rb;
    public Rigidbody projectile;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //SOURCE: https://learn.unity.com/tutorial/movement-basics#5c7f8528edbc2a002053b70f
    void FixedUpdate()
    {
        //forward
        if(Input.GetKey(KeyCode.W)){
            rb.AddForce(transform.forward*speed);
        }
        //backward
        if(Input.GetKey(KeyCode.S)){
            rb.AddForce(transform.forward*speed*-1);
        }
        //turn left
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0, -speed/30, 0);
        }
        //turn right
        if(Input.GetKey(KeyCode.D)){
            
            transform.Rotate(0, speed/30, 0);
        }
        

        if(Input.GetKey(KeyCode.Space)){
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, transform.position+transform.forward*2, projectile.rotation);
            clone.AddTorque(transform.up*500);
            clone.AddForce(transform.forward*1000);
        }
    }
}
