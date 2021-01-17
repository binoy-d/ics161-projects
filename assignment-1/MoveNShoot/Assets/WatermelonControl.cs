using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GameObject.Find("SmallTank").GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy"){
            print("enemy hit");
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
