using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    // Start is called before the first frame update
    void Start()
    {
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();
        //key.material.color = Color.gray;
        if (key !=null)
        {
            var keyFeedBack = other.gameObject.GetComponent<KeyFeedback>();
            keyFeedBack.keyHit = true;
            if (other.gameObject.GetComponent<KeyFeedback>().keyCanBeHitAgain)
            {
                if (key.text == "SPACE")
                {
                    playerTextOutput.text += " ";
                }
                else if (key.text == "Back")
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                }
                else
                {
                    playerTextOutput.text += key.text;
                }
            }
        }
        
    }
}
