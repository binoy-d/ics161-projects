using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int parentPlayerNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setParentPlayer(int pNum){
        parentPlayerNum = pNum;
        //get all the tanks
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");

        //figure out which tank was the parent
        //and set the color to match the parent color
        foreach(GameObject t in tanks){
            if(t.GetComponent<Moving>().getPlayerNum() == parentPlayerNum){
                //set color of tip
                gameObject.GetComponent<Renderer>().material = t.GetComponent<Renderer>().material;
                //set color of cylinder(check prefab)
                //sorry for this disgusting line
                gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = t.GetComponent<Renderer>().material;
            }
        }
        
        
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log("Trigger Enter: "+other.name+","+gameObject.name);
        //destroy targets
        if(other.tag == "Target"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }else if(other.tag == "Tank"){
            //destroy tanks only if their playerNum 
            // is not the same as this bullet's parent
            if(other.GetComponent<Moving>().getPlayerNum()!=parentPlayerNum){
                other.GetComponent<Moving>().killPlayer();
                Destroy(gameObject);
            }
        }else{
            Destroy(gameObject);
        }
        
    }
}
