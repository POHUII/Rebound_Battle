using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectColor : MonoBehaviour
{
    private float colorIntensity = 3;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        ChangeColor();
    }

    void ChangeColor()
    {
        Color color = Tools.GetRandomHDRColor(colorIntensity);
        meshRenderer.material.SetColor("_EmissionColor", color);
    }
}
