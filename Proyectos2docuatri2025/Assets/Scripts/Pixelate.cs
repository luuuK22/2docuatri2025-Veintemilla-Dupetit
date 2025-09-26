using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Pixelate : MonoBehaviour
{


    public Shader pixelShader;

    [Range(0.001f, 0.1f)]
    public float pixelSize = 0.02f;

    [Range(0.0f, 0.05f)]
    public float distortionStrength = 0.005f;

    [Range(0.0f, 30.0f)]
    public float distortionSpeed = 10.0f;

    private Material pixelMat;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (pixelMat == null && pixelShader != null)
            pixelMat = new Material(pixelShader);

        if (pixelMat != null)
        {
            pixelMat.SetFloat("_PixelSize", pixelSize);
            pixelMat.SetFloat("_DistortionStrength", distortionStrength);
            pixelMat.SetFloat("_DistortionSpeed", distortionSpeed);

            Graphics.Blit(src, dest, pixelMat);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
