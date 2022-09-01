using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.collider.tag=="ENEMY")
        {
            Destroy(gameObject, 0.05f);
            GameObject.FindGameObjectWithTag("Vibration").GetComponent<SineWaveFunction>().HitEnemy();
        }
        else if (collision.collider.tag == "PLAYER")
        {
            Destroy(gameObject, 0.05f);
            GameObject.FindGameObjectWithTag("Vibration").GetComponent<SineWaveFunction>().HitPlayer();
        }
        else if(collision.collider.tag == "Wall")
        {
            Destroy(gameObject, 0.05f);
            //Debug.Log("Wall got hit");
        }
    }
}
