using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Flicker : MonoBehaviour
{
    public Light lightObj;
    public AnimationCurve _curve;

    public float length;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightObj.intensity = Mathf.PingPong(_curve.Evaluate(Time.time), length);
    }
}
