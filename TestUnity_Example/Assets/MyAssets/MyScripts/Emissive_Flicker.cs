using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissive_Flicker : MonoBehaviour
{
    public GameObject assetOBJ;
    public Material emissiveMTL;
    public Color BaseColor;

    public AnimationCurve emissiveCurve;

    public float startingValue;
    public float secondValue;
    public float emissionSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        emissiveMTL.SetColor("_EmissionColor", BaseColor * startingValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (startingValue < secondValue)
            firstFlicker();
    }

    void firstFlicker()
    {
        startingValue = Mathf.MoveTowards(startingValue, secondValue, emissiveCurve.Evaluate(emissionSpeed * Time.deltaTime));
        emissiveMTL.SetColor("_EmissionColor", BaseColor * startingValue);
    }
}
