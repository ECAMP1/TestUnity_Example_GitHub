using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Lerp : MonoBehaviour
{
    public GameObject elevator_OBJ;
    public Vector3 position_01;
    public Vector3 position_02;
    public float speed;
    public KeyCode keyCommand;

    private bool _isSTILL;
    private bool _isGoing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGoing)
            speed = Mathf.MoveTowards(0, 10f, Time.deltaTime);
            elevator_OBJ.transform.position = Vector3.Lerp (position_01, position_02, speed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(keyCommand))
        {
            _isSTILL = !_isSTILL;
            if (_isSTILL)
                _isGoing = true;
            Debug.Log("checking");
                
        }
    }
}
