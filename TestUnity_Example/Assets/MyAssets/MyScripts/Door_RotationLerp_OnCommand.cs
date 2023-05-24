using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_RotationLerp_OnCommand : MonoBehaviour
{
    public GameObject door;
    public Quaternion rotation_Origin;
    public Quaternion rotation_Goal;
    public float speed;
    public KeyCode keyCommand;

    private bool _isReady;
    private bool _isUsing;
    private bool _isOpened;
    // Start is called before the first frame update
    void Start()
    {
        _isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isReady)
            DoorCTRL();

        if (_isOpened)
            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, rotation_Goal, speed);
        else if (!_isOpened)
            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, rotation_Origin, speed);
    }

    private void OnTriggerStay(Collider other)
    {
        _isReady = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isReady = false;
    }

    void DoorCTRL()
    {
        if (Input.GetKeyDown(keyCommand))
            _isUsing = !_isUsing;
        if (_isUsing)
        {
            _isOpened = true;
            Debug.Log("using");
        }
        else
            _isOpened = false;
    }
}
