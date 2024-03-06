using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DinoEgg : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSceneAdventure()
    {
        GameManager.instance.LoadScene("Adventure");
    }

    private void OnMouseDown()
    {
        animator.SetBool("isCracking", true);
    }
}
