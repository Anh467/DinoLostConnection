using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDino : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController character;
    Animator animator;
    Vector3 direction;

    public static PlayerDino instance;
    // const
    const string ANIMATION_PARAM_isRun = "isRun";
    const string ANIMATION_PARAM_isCrouch = "isCrouch";

    [SerializeField]
    bool isUnTouchable = false;

    [SerializeField]
    float jumpForce = 8f;
    [SerializeField]
    float gravity = 9.81f * 1.5f;
    // GetAxisRaw
    float horizontal;

    // information
    public int healContainer { get; private set; } = 3;
    public int healPoint { get; private set; }

    private void Awake()
    {
        healPoint = healContainer;

        character = GetComponent <CharacterController>();
        animator = GetComponent<Animator>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
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

    // handler heal variable
    public void TakeDamage(int damage)
    {
        if (isUnTouchable) return;
        healPoint -= damage;
        if (healPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void IncreaseHeal(int heal)
    {
        if(healPoint + heal >= healContainer)
        {
            healPoint = healContainer;
            return;
        }
        healPoint += heal;
    }
    // 
}
