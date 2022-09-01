using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;



public class SineWaveFunction : MonoBehaviour
{
    public void HitEnemy()
    {
        SendDatatoArduino(EnemyNum, EnemyTime, EnemyfFrequency, EnemyAmplitude);
        //Debug.Log("Enemy got hit");
    }
    public void HitPlayer()
    {
        SendDatatoArduino(PlayerNum, PlayeTime, PlayefFrequency, PlayeAmplitude);
        //Debug.Log("Plyaer got hit");
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
    public SerialPort serial = new SerialPort("COM11", 9600); //here change port - where you have connected arduino to computer
    //private bool lightState = false;

    private int Num = 10; //Vibration pin Number
    private float fTime = 100; // milliSecond
    private float fFrequency = 55;
    private float fAmplitude = 512;
    //Frequency : 30 ~ 1000, Resonance =55; name : BM1C
    // Amplitude : -512 ~ +512  
    // from 0 to 1024 / 0 = 0V, 512=1.65V, 1024 = 3.3V

    public int PlayerNum = 10;
    public float PlayeTime = 100;
    public float PlayefFrequency = 55;
    public float PlayeAmplitude = 512;

    public int EnemyNum = 9;
    public float EnemyTime = 100;
    public float EnemyfFrequency = 55;
    public float EnemyAmplitude = 512;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
