using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{


    public float speed;
    public float jumpforce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;









    private int extraJump;
    public int extraJumpValue;











    // Start is called before the first frame update
    void Start(){
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal"); //gives the horisontal buttons (a and d, left and right) positive and negative values
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }



        


       


    }

    void Update()
    {
        if(isGrounded == true)
        {
            extraJump = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJump--;

        }else if(Input.GetKeyDown(KeyCode.Space) && extraJump==0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }





    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
