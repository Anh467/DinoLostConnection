using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    [SerializeField]
    float nerfSpeed = 2;
    [SerializeField]
    float scrollSpeed = 0.5f;
    float offset;
    Material material;
    
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        scrollSpeed = GameManager.instance.getGameSpeed() / nerfSpeed;
        offset += (scrollSpeed * Time.deltaTime) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
       //material.mainTextureOffset = new Vector2(0, offset);
    }
}
