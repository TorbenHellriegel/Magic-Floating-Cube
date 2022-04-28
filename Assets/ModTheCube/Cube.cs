using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
        
    private Material material;
    public Vector3 position = new Vector3(0, 0, 0);
    public float[] rotation = new float[]{0, 0, 0};
    public float rotationAltarationSpeed = 0.7f;
    public float rotationSpeed = 100;
    public float scale = 1;
    public float[] colorRGBA = new float[]{1, 1, 1, 1};
    
    void Start()
    {
        position = new Vector3(Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50));
        rotation = new float[]{Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50)};
        colorRGBA = new float[]{Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50)};
        
        material = Renderer.material;
    }
    
    void Update()
    {
        position.x += 0.01f;
        position.y += 0.01f;
        position.z += 0.01f;
        transform.position = new Vector3(
            Mathf.Sin(position.x),
            Mathf.Sin(position.y),
            Mathf.Sin(position.z));
        
        rotation[0] += rotationAltarationSpeed * Time.deltaTime;
        rotation[1] += rotationAltarationSpeed * Time.deltaTime;
        rotation[2] += rotationAltarationSpeed * Time.deltaTime;
        transform.Rotate(
            Mathf.Sin(rotation[0]) * Time.deltaTime * rotationSpeed,
            Mathf.Sin(rotation[1]) * Time.deltaTime * rotationSpeed,
            Mathf.Sin(rotation[2]) * Time.deltaTime * rotationSpeed);

        transform.localScale = Vector3.one * (2.0f + Random.Range(-100.0f, 100.0f) / 400.0f);
        
        colorRGBA[0] += 1 * Time.deltaTime;
        colorRGBA[1] += 1 * Time.deltaTime;
        colorRGBA[2] += 1 * Time.deltaTime;
        colorRGBA[3] += 0.5f * Time.deltaTime;
        material.color = new Color(
            Mathf.Sin(colorRGBA[0]) * Time.deltaTime * 50,
            Mathf.Sin(colorRGBA[1]) * Time.deltaTime * 50,
            Mathf.Sin(colorRGBA[2]) * Time.deltaTime * 50,
            Mathf.Sin(colorRGBA[3]) * Time.deltaTime * 50 + 0.3f);
    }
}
