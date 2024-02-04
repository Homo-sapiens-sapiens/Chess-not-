using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Color baseColor;

    private void Start()
    {
        baseColor = gameObject.GetComponent<Renderer>().material.color;
    }

    public void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    public void Reset()
    {
        gameObject.GetComponent<Renderer>().material.color = baseColor;
    }
}

