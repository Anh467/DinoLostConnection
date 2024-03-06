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
    const string ANIMATION_PARAM_isHurt = "isHurt";
    [SerializeField]
    bool isUnTouchable = false;

    [SerializeField]
    float jumpForce = 8f;

    [SerializeField]
    float speedForce = 7f;
    [SerializeField]
    float gravity = 9.81f * 1.5f;
    // GetAxisRaw
    float horizontal;

    // information
    public int healContainer = 3;
    [SerializeField]
    public int healPoint;

    private void Awake()
    {
        healPoint = healContainer;
        isUnTouchable = false;

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
                direction = speedForce * Vector3.right;
            }
            if (horizontal < -0.001)
            {
                direction = speedForce * Vector3.left;
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
        UI_Information_Panel_Controller.instance.UpdateInformation();
        StartCoroutine(AnimationIsHurt());
    }
    public void IncreaseHeal(int heal)
    {
        if(healPoint + heal >= healContainer)
        {
            healPoint = healContainer;
            return;
        }
        healPoint += heal;
        UI_Information_Panel_Controller.instance.UpdateInformation();
    }
    // handle animation
    IEnumerator AnimationIsHurt()
    {
        isUnTouchable = true;
        animator.SetBool(ANIMATION_PARAM_isHurt, true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool(ANIMATION_PARAM_isHurt, false);
        isUnTouchable = false;
    }

    private void OnDestroy()
    {
        GameManager.instance.SaveScore();
        UI_Information_Management.instance.Pause();
    }
}
