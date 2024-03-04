using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 0.5f;
    float offset;
    Material material;
    void Start()
    {
        material = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += (scrollSpeed * Time.deltaTime) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
