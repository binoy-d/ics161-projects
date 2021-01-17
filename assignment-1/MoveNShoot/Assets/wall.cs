using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GameObject.Find("Ground").GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Watermelon"){
            print("delete melon");
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Watermelon"){
            print("delete melon");
            Destroy(other.gameObject);
        }
        
    }
}
