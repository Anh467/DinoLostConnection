using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InitiateObstacle : MonoBehaviour
{
    const float POSITION_X = 12;
    [SerializeField]
    List<GameObject> obstacles;
    int idTouching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstacle") return;

        if (idTouching == other.GetInstanceID()) return;
        idTouching = other.GetInstanceID();

        int ranInt = Random.Range(0, obstacles.Count);
        float positionX = Random.Range(12, 16);

        Vector3 direction = new Vector3(positionX, 0);
        Instantiate(obstacles[ranInt], direction, Quaternion.identity);
    }
}
