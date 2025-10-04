using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ArduinoReceiver : MonoBehaviour
{
    public static ArduinoReceiver receiver;

    public ArduinoReceiver()
    {
        receiver = this;
    }

    SerialPort port;
    Thread readThread;
    public GameObject testObj;

    public float currentPlatformRotation;
    public float currentLidarPosition;

    bool online;

    // Start is called before the first frame update
    void Start()
    {
        port = new("COM4",9600);
        port.Open();
    }

    float b;


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            online = !online;

            if (online)
                port.Write("Test");
            else
                port.Write("Test");
        }
    }

    public void ChangeLidarPosition(float position)
    {
        port.Write("LidarTo"+position);
    }

    private void OnDisable()
    {
        port.Close();
    }
}
