using UnityEngine;

public class WebCam : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private Renderer renderer;
    private Texture2D newTexture;

    void Start()
    {
        InitializeCamera();
    }

    private void InitializeCamera()
    {
        renderer = GetComponent<Renderer>();
        webcamTexture = new WebCamTexture(1280, 720);
        webcamTexture.requestedFPS = 10;
        webcamTexture.Play();

        // Create new texture with same size
        newTexture = new Texture2D(1280, 720, TextureFormat.RGB24, false);

        // Assign once
        renderer.material.mainTexture = newTexture;

        // Debug available devices
        foreach (var device in WebCamTexture.devices)
        {
            Debug.Log(device.name);
        }
    }

    private void GenerateGreenChannel()
    {
        Color[] pixels = webcamTexture.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            float g = pixels[i].g;       // keep green channel
            if (g > 0.9)
            {
                pixels[i] = new Color(0, g, 0);
            }
            else
                pixels[i] = new Color(0, 0, 0);
        }

        newTexture.SetPixels(pixels);
        newTexture.Apply();
    }

    private void Update() // use Update instead of FixedUpdate
    {
        if (webcamTexture.width > 16) // wait until webcam initializes
        {
            GenerateGreenChannel();
        }
    }
}
