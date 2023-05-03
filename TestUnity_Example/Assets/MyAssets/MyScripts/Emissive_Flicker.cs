using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissive_Flicker : MonoBehaviour
{
    public GameObject assetOBJ;
    public Material emissiveMTL;
    private Color emissiveColor;
    public AnimationCurve curve;

    public float emissionMax;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        emissiveColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(curve.Evaluate (Time.time), emissionMax));
        emissiveMTL.SetColor("_EmissionColor", emissiveColor);
    }
}
