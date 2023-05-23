using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_RotationLerp_OnCommand : MonoBehaviour
{
    public GameObject door;
    public KeyCode keyCommand;
    public Vector3 rotation_Origin;
    public Vector3 rotation_Goal;
    public float speed;

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
            door.transform.rotation = Quaternion.Lerp(Quaternion.Euler(door.transform.position), Quaternion.Euler(rotation_Goal), speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
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
