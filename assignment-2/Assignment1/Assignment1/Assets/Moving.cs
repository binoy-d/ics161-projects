using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject bullet;
    public int playerNum;
    private GameObject shotBullet;
    private float speed;
    //{up, down, left, right, shoot}
    private KeyCode[] controls; 
    private bool isDead;
    // Start is called before the first frame update
    void Start(){
        speed  = 0.2f;
        isDead = false;
        if(playerNum == 1){
            controls = new KeyCode[]{
                KeyCode.W,
                KeyCode.S,
                KeyCode.A,
                KeyCode.D,
                KeyCode.Space
            };
        }else{
            controls = new KeyCode[]{
                KeyCode.UpArrow,
                KeyCode.DownArrow,
                KeyCode.LeftArrow,
                KeyCode.RightArrow,
                KeyCode.Return
            };
        }
    }

    // Update is called once per frame
    void Update(){
        if(isDead){
            //move it far far away
            transform.position = new Vector3(200, 200, 200);
        }
        if(Input.GetKeyDown(controls[4])){
            Debug.Log("Player "+playerNum+" fired!");
            shotBullet = Instantiate(bullet,transform.position,transform.rotation);
            shotBullet.GetComponent<Bullet>().setParentPlayer(playerNum);
            Transform tranBullet = shotBullet.GetComponent<Transform>();
            Rigidbody rigBullet = shotBullet.GetComponent<Rigidbody>();
            if( rigBullet){
                rigBullet.AddForce(transform.forward*40.0f,ForceMode.VelocityChange);
            }
        }
    }

    
    void FixedUpdate(){
        if (Input.GetKey(controls[3])){//right
            transform.Translate(new Vector3(0,0,speed));
            transform.rotation = Quaternion.Euler(0,90,0);
        }else if(Input.GetKey(controls[2])){//left
            transform.Translate(new Vector3(0,0,speed));
            transform.rotation = Quaternion.Euler(0,-90,0);
        }else if(Input.GetKey(controls[0])){//up
            transform.Translate(new Vector3(0,0,speed));
            transform.rotation = Quaternion.Euler(0,0,0);
        }else if(Input.GetKey(controls[1])){//down
            transform.Translate(new Vector3(0,0,speed));
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        
    }

    public int getPlayerNum(){
        return playerNum;
    }

    public void killPlayer(){
        isDead = true;
        Invoke("revivePlayer", 3); //revive after 3 seconds
    }

    public void revivePlayer(){
        isDead = false;
        transform.position = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
    }
    
}
