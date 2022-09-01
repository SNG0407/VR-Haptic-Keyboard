using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;



public class Multi_Vibration : MonoBehaviour
{
    void InvokePrint()
    {
        Debug.Log("data's sent!");
    }
    void SendDatatoArduino(int Num, float fTime, float fFrequency, float fAmplitude)
    {
        if (serial.IsOpen == false)
        {
            string strNum = Num.ToString();
            string strTime = fTime.ToString();
            string strFrequency = fFrequency.ToString();
            string strAmplitude = fAmplitude.ToString();


            string data = strNum + "#" + strTime + "#" + strFrequency + "#" + strAmplitude + "&";

            serial.Open();
            
            serial.Write(data);
            Debug.Log(data);
            serial.Close();
        }
    }
    public SerialPort serial = new SerialPort("COM5", 9600); //here change port - where you have connected arduino to computer
    private Rigidbody rb;
    float speed = 10.0f;

    public int Num = 10;
    public float fTime = 100; //1sec
    public float fFrequency = 55;
    public float fAmplitude = 512; // from 0 to 1024 / 0 = 0V, 512=1.65V, 1024 = 3.3V
    //Frequency : 30 ~ 1000, Resonance =55; name : BM1C
    // Amplitude : -512 ~ +512  
    public int NumRight = 9;
    public float fTimeRight = 200;
    public float fFrequencyRight = 55;
    public float fAmplitudeRight = 512;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            SendDatatoArduino(Num, fTime, fFrequency, fAmplitude);

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //Invoke("InvokePrint", 2f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            if (serial.IsOpen == false)
            {
                SendDatatoArduino(NumRight, fTimeRight, fFrequencyRight, fAmplitudeRight);
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

}
