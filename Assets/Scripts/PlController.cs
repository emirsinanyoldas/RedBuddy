using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnmr;
//    [SerializeField]        //Unity de gosterir ama private olarak
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f, jumpFrequency = 1f, nextJumpTime;


    bool facingRight = true;

    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundCheckLayer;

    public void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnmr=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 //      print(Input.GetAxis("Horizontal")); /* Kontrol tuslari denemesi icin yazildi */
        HorizontalMove();
        OnGroundCheck();
        if (playerRB.velocity.x < 0 && facingRight)
        {
            //Yuzunu cevir
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            //Yuzunu cevir
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad)) 
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
//          OnGroundCheck();
        }
    }
    public void FixedUpdate()
    {
        
    }
    public void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnmr.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocaleScale = transform.localScale;
        tempLocaleScale.x *= -1;
        transform.localScale = tempLocaleScale;
    }
    void Jump()
    {
        //playerRB.AddForce(new Vector2(0f, jumpSpeed));
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpSpeed);
    }
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnmr.SetBool("isGroundedAnim", isGrounded);
    }
}