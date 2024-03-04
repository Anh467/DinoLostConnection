using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.instance.getGameSpeed()/ transform.localScale.x;
        m_Renderer.material.mainTextureOffset -= Vector2.right * speed * Time.deltaTime ;
    }
}
