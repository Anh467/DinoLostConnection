using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    public float speed = 0.5f;
    public float distance = 0.2f;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yPosition = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(transform.position.x, startPosition.y + yPosition, transform.position.z);
    }
}
