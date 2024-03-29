using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float positionY;
    [SerializeField]
    float speed;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, positionY);
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameManager.instance.getGameSpeed() / 2.0f;
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            PlayerDino.instance.TakeDamage(1);
        }
    }
}
