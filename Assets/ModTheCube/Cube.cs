using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;

    // Set some starting variables
    public Vector3 position = new Vector3(0, 0, 0);
    public float[] rotation = new float[]{0, 0, 0};
    public float rotationAltarationSpeed = 0.7f;
    public float rotationSpeed = 100;
    public float scale = 1;
    public float[] colorRGBA = new float[]{1, 1, 1, 1};
    
    void Start()
    {
        // Set a random starting position rotation and color
        position = new Vector3(Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50));
        rotation = new float[]{Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50)};
        colorRGBA = new float[]{Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50)};
        
        material = Renderer.material;
    }
    
    void Update()
    {
        // Constantly increase the position values
        position.x += 0.01f;
        position.y += 0.01f;
        position.z += 0.01f;
        // Calculate the sine of the position values
        // This makes the cube float in a seemingly random circular motion
        transform.position = new Vector3(
            Mathf.Sin(position.x),
            Mathf.Sin(position.y),
            Mathf.Sin(position.z));
        
        // Constantly increase the rotation values
        rotation[0] += rotationAltarationSpeed * Time.deltaTime;
        rotation[1] += rotationAltarationSpeed * Time.deltaTime;
        rotation[2] += rotationAltarationSpeed * Time.deltaTime;
        // Calculate the sine of the rotation values
        // This makes the cube rotate in seemingly random directions
        transform.Rotate(
            Mathf.Sin(rotation[0]) * Time.deltaTime * rotationSpeed,
            Mathf.Sin(rotation[1]) * Time.deltaTime * rotationSpeed,
            Mathf.Sin(rotation[2]) * Time.deltaTime * rotationSpeed);

        // Repeatedly set the scale to a random value that is slightly higer or lower than the cubes default scale
        // This causes a flickering effect which makes it look like the cube is vibrating
        transform.localScale = Vector3.one * (2.0f + Random.Range(-100.0f, 100.0f) / 400.0f);
        
        // Constantly increase the color values
        colorRGBA[0] += 1 * Time.deltaTime;
        colorRGBA[1] += 1 * Time.deltaTime;
        colorRGBA[2] += 1 * Time.deltaTime;
        colorRGBA[3] += 0.5f * Time.deltaTime;
        // Calculate the sine of the color values
        // This makes the cube change color seemingly randomly
        material.color = new Color(
            Mathf.Sin(colorRGBA[0]) * Time.deltaTime * 50,
            Mathf.Sin(colorRGBA[1]) * Time.deltaTime * 50,
            Mathf.Sin(colorRGBA[2]) * Time.deltaTime * 50,
            Mathf.Sin(colorRGBA[3]) * Time.deltaTime * 50 + 0.3f);
    }
}
