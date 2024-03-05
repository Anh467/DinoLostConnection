
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Information_Panel_Slot_Controller : MonoBehaviour
{
    [SerializeField]
    Image _image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnableTrue() 
    {
        _image.color = new Color(255, 255, 255);
    }
    public void SetEnableFalse()
    {
        _image.color = new Color(0, 0, 0);
    }
}
