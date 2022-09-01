using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Left_Hand
{
    L_THUMB,
    L_INDEX,
    L_MIDDLE,
    L_RING,
    L_PINKY
}
enum Right_Hand
{
    R_THUMB,
    R_INDEX,
    R_MIDDLE,
    R_RING,
    R_PINKY
}
public class Touched : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "keypad" )
        {
            if (this.tag == "Left_Finger")
            {
                Debug.Log(this.tag);
                GameObject.FindGameObjectWithTag("Vibration").GetComponent<HapticVibration>().LeftHand();
                //Debug.Log("Left hand");

            }
            else if (this.tag == "Right_Finger")
            {
                Debug.Log(this.tag);
                GameObject.FindGameObjectWithTag("Vibration").GetComponent<HapticVibration>().RightHand();
                //Debug.Log("Right hand");
            }
        }
    }
}


