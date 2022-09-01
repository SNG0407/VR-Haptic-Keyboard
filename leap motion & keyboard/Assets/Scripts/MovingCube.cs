using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    float speed = 10.0f; //이동 속도

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Vibration").GetComponent<HapticVibration>().RightHand();
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Vibration").GetComponent<HapticVibration>().LeftHand();

        }
    }
}
