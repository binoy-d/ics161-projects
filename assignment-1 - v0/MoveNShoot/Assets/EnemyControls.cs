using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        target = GameObject.Find("SmallTank").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        transform.LookAt(target);
        //rb.AddForce(transform.forward);
    }
}
