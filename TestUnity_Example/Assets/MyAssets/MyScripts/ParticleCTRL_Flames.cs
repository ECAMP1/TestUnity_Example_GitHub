using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCTRL_Flames : MonoBehaviour
{
    public ParticleSystem particles;
    public float maxSize;
    public float minSize;
    public float speed;

    private bool _isGrowing;
    // Start is called before the first frame update
    void Start()
    {
        particles.startSize = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrowing)
            LerpSize();
        if (_isGrowing == false)
            particles.startSize = Mathf.MoveTowards(particles.startSize, minSize, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isGrowing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isGrowing = false;
    }

    void LerpSize()
    {
        particles.startSize = Mathf.MoveTowards(particles.startSize,maxSize, speed* Time.deltaTime);
    }
}
