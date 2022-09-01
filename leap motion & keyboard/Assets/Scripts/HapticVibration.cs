using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;



public class HapticVibration : MonoBehaviour
{
    public void LeftHand()
    {
        SendDatatoArduino(LeftNum, LeftTime, LeftAmplitude);
        //Debug.Log("Enemy got hit");
    }
    public void RightHand()
    {
        SendDatatoArduino(RightNum, RightTime, RightAmplitude);
        //Debug.Log("Plyaer got hit");
    }
    void SendDatatoArduino(int Num, float fTime,  float fAmplitude)
    {
        if (serial.IsOpen == false)
        {
            string strNum = Num.ToString();
            string strTime = fTime.ToString();
            string strAmplitude = fAmplitude.ToString();

            string data = strNum + "#" + strTime + "#"  + strAmplitude + "&";

            serial.Open();

            serial.Write(data);
            Debug.Log(data);
            data = "";
            serial.Close();
        }
    }
    public SerialPort serial = new SerialPort("COM10", 9600); //here change port - where you have connected arduino to computer
    //private bool lightState = false;

    private int Num = 10; //Vibration pin Number
    private float fTime = 100; // milliSecond
    private float fAmplitude = 512;
    //Frequency : 30 ~ 1000, Resonance =55; name : BM1C
    // Amplitude : -512 ~ +512  
    // from 0 to 1024 / 0 = 0V, 512=1.65V, 1024 = 3.3V

    public int RightNum = 9;
    public float RightTime = 100;
    public float RightAmplitude = 220;

    public int LeftNum = 10;
    public float LeftTime = 100;
    public float LeftAmplitude = 220;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
