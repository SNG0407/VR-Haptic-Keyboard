using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedback : MonoBehaviour
{
    private SoundHandler soundHandler;
    public bool keyHit = false;
    public bool keyCanBeHitAgain= false;

    private float originalXPosition;
    private float originalYPosition;
    private float originalZPosition;

    private float originalXlocalScale;
    private float originalYlocalScale;
    private float originalZlocalScale;
    // Start is called before the first frame update
    void Start()
    {
        soundHandler = GameObject.FindGameObjectWithTag("SoundHandler").GetComponent<SoundHandler>();
        originalXPosition = transform.position.x;
        originalYPosition = transform.position.y;
        originalZPosition = transform.position.z;

        originalXlocalScale = transform.localScale.x;
        originalYlocalScale = transform.localScale.y;
        originalZlocalScale = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (keyHit == true)
        {
            if(keyCanBeHitAgain == true)
            soundHandler.PlayKeyClick();
            keyCanBeHitAgain = false;
            keyHit = false;
            transform.position += new Vector3(0, -0.005f, 0);

        }

        if (transform.position.y< originalYPosition)
        {
            transform.position += new Vector3(0, 0.001f,0);
            keyCanBeHitAgain = false;
        }
        else
        {
            keyCanBeHitAgain = true;
        }    
    }
}
