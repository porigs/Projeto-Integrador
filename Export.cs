using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Export : MonoBehaviour
{
    public Transform ParentGameObject;
 
    public void GenerateMesh()
    {
        Vector3[] points = null;
        for(int i = 0; i < ParentGameObject.childCount; i++)
        {
            points[i] = ParentGameObject.GetChild(i).transform.position;
        }

        Mesh mesh = new();
        mesh.vertices = points;


        string STL_File = null;

        STL_File += "solid name\n";

        for(int i = 0; i < points.Length; i+= 3)
        {
            var normal1 = points[i] - points[i + 1];
            var normal2 = points[i] - points[i + LiDAR.lidar.horizontalCuts];
            var normal = Vector3.Cross(normal1, normal2).normalized;

            STL_File += "facet normal " + normal.x + normal.y + normal.z + '\n';
            STL_File += " outer loop\n";
            STL_File += "  vertex " + points[i].x + " " + points[i+1] + " " + points[i+2] + "\n";
            STL_File += " end loop\n";
            STL_File += "end facet\n";
        }

        STL_File += "endsolid name";

        
    }


    public void SaveMesh()
    {

    }
}
