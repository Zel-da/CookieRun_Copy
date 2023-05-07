using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jumpPower;
    public int JumpCount;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && JumpCount == 0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            JumpCount++;
        }

        /*if (Input.GetButtonDown("Jump") && !anim.GetBool("isDoubleJump") && JumpCount == 1)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isDoubleJump", true);
            JumpCount++;
        }*/
    }

    void FixedUpdate()
    {
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * 5, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 2, LayerMask.GetMask("flat"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 2f)
                {
                    anim.SetBool("isJump", false);
                    //anim.SetBool("isDoubleJump", false);
                    JumpCount = 0;
                }
            }
        }
        
    }
}
