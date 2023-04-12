using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap_OnCommand : MonoBehaviour
{
    public GameObject assetObj;
    public Material defaultMTL;
    public Material newMTL;

    public KeyCode keyBoardButton;

    private bool _isActive;
    private bool _isChanged;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
            MaterialChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        _isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isActive = false;
    }

    void MaterialChange()
    {
        if (Input.GetKeyDown(keyBoardButton))
        {
            _isChanged = !_isChanged;
            if (_isChanged)
                assetObj.GetComponent<Renderer>().material = newMTL;
            else
                assetObj.GetComponent<Renderer>().material = defaultMTL;
        }
    }

}
