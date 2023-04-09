using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Translate : MonoBehaviour
{
    public Transform platform;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            _player.transform.parent = platform.transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.E))
        {
            PlatformUp();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            _player.transform.parent = null;
        }
    }

    void PlatformUp()
    {
        platform.GetComponent<Animator>().SetTrigger("Up");
    }
}

