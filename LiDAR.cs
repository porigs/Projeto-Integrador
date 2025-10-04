using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class LiDAR : MonoBehaviour
{
    public static LiDAR lidar;

    public LiDAR()
    {
        lidar = this;
    }

    public GameObject particle;
    public GameObject pivot;
    public SplineContainer spline;

    public int horizontalCuts;
    public int verticalCuts;

    public float angularSpeed;
    public float interval;
    float elapsedInterval;


    float3 position;
    float3 tangent;
    float3 upVector;
    // Update is called once per frame
    //void Update()
    //{
    //    //transform.RotateAround(pivot.transform.position,Vector3.up, angularSpeed * Time.deltaTime);

    //    pivot.transform.rotation = Quaternion.Euler(0, 360 / ArduinoReceiver.receiver.currentPlatformRotation, 0);
        
    //    spline.Evaluate(ArduinoReceiver.receiver.currentLidarPosition,out position, out tangent,out upVector);
    //    transform.position = position;
    //    transform.LookAt(pivot.transform);

    //    elapsedInterval += Time.deltaTime;
    //    if (elapsedInterval > interval)
    //    {
    //        GenerateParticle(4 + Mathf.Sin(Time.time));
    //        elapsedInterval = 0;
    //    }
    //}

    void GenerateParticle(float distance)
    {
        Instantiate(particle, transform.TransformPoint(new(0, 0, distance)),Quaternion.identity,pivot.transform);
    }

    private void OnGUI()
    {
        GUI.Label(new(10,10,30,30), "" + 1 / Time.deltaTime);
    }
}
