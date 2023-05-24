using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_TranslateLerp_OnTrigger : MonoBehaviour
{
    public GameObject door;
    public Vector3 position_Origin;
    public Vector3 position_Goal;
    public float speed;

    private bool _isOpened;
    // Start is called before the first frame update
    void Start()
    {
        _isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOpened)
            door.transform.position = Vector3.Lerp(door.transform.position, position_Goal, speed*Time.deltaTime);
        else
            door.transform.position = Vector3.Lerp(door.transform.position, position_Origin, speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isOpened = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isOpened = false;
    }
}
