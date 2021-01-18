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
        speed = 0.5f;
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.forward*speed);
            //rb.AddForce(transform.forward*speed);
        }
        //backward
        if(Input.GetKey(KeyCode.S)){
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.forward*speed);
            //rb.AddForce(transform.forward*speed*-1);
        }
        //turn left and move
        if(Input.GetKey(KeyCode.A)){
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.Translate(Vector3.forward*speed);
            //transform.Rotate(0, -3, 0);
        }
        //turn right and move
        if(Input.GetKey(KeyCode.D)){
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(Vector3.forward*speed);
            //transform.Rotate(0, 3, 0);
        }
        

        if(Input.GetKey(KeyCode.Space)){
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, transform.position+transform.forward*2, projectile.rotation);
            clone.constraints = 0;
            clone.AddTorque(transform.up*500);
            clone.AddForce(transform.forward*1000);
        }
    }
}
