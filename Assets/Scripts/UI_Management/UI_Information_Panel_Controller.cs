using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Information_Panel_Controller : MonoBehaviour
{
    public static UI_Information_Panel_Controller instance;
    // Start is called before the first frame update
    [SerializeField]
    GameObject panel;
    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        int userHealContainer = PlayerDino.instance.healContainer;
        for(int i = 0; i < userHealContainer; i++)
        {
            var child = Instantiate(panel);
            child.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateInformation();
    }

    public void UpdateInformation()
    {
        int userHealPoint = PlayerDino.instance.healPoint;
        int userHealContainer = PlayerDino.instance.healContainer;
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        if (ts == null)
            return;
        int count = userHealContainer;
        foreach (Transform child in transform)
        {
            UI_Information_Panel_Slot_Controller slot = child.GetComponent<UI_Information_Panel_Slot_Controller>();
            if (!slot) continue;
            if(count <= userHealPoint)
            {
                slot.SetEnableTrue();
            }
            else
            {
                slot.SetEnableFalse();
            }
            --count;
        }
        
    }
}
