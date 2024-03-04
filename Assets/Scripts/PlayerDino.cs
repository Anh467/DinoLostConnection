using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDino : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController character;
    Animator animator;
    Vector3 direction;

    // const
    const string ANIMATION_PARAM_isRun = "isRun";
    const string ANIMATION_PARAM_isCrouch = "isCrouch";

    //[SerializeField]
    float jumpForce = 8f;
    //[SerializeField]
    float gravity = 9.81f * 2f;
    // GetAxisRaw
    float horizontal;


    private void Awake()
    {
        character = GetComponent <CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
        animator.SetBool("isRun", true);
    }
    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = jumpForce * Vector3.up ;
            }
            if(horizontal > 0.001)
            {
                direction = jumpForce * Vector3.right;
            }
            if (horizontal < -0.001)
            {
                direction = jumpForce * Vector3.left;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool(ANIMATION_PARAM_isCrouch, true);
                character.height = 0.5f;
            }
            else
            {
                animator.SetBool(ANIMATION_PARAM_isCrouch, false);
                character.height = 1f;
                
                
            }
        }

        character.Move(direction * Time.deltaTime);
    }


}
