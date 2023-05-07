using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Button btn;
    //점프 함
    public float jumpForce;
    //누적 점프 횟수
    private int jumpCount = 0;
    //바닥에 닿았는지 나타냄
    private bool isGrounded = false;
    //사망 상태
    private bool isDie = false;
    //달리는 상태
    public bool isRun = false;
    //사용할 리지드바디 컴포넌트
    private Rigidbody2D playerRigidbody;
    //사용할 애니메이터 컴포턴트
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.playerRigidbody = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isDie) return;



        //애니메이터의 Grounded파라메터를 isGrounded값을 생산(애니메이션 플레이)
        this.animator.SetBool("Grounded", this.isGrounded);
    }
    public void Jump()
    {
        //마우스 왼쪽 버튼을 눌렀고 최대 점프 횟수 (2)에 도달하지 않았다면
        if (this.jumpCount < 2)
        {
            //점프 횟수 증가
            this.jumpCount++;
            //점프 직전에 속도를 순간적으로 0.0으로 변경
            playerRigidbody.velocity = Vector2.zero;

            //리지드바디에 위쪽 힘주기
            this.playerRigidbody.AddForce(new Vector2(0, this.jumpForce));
            if (jumpCount == 2)
            {
                this.animator.SetTrigger("Double Jump");
            }
        }
    }

    public void Slide()
    {
        this.animator.SetTrigger("Slide");
    }

    public void Run()
    {
        this.animator.SetTrigger("Run");
    }
    public void DieHit()
    {
        if (isRun)
        {
            //사망처리
            //애니메이터의 Die 트리거 마라메터 설정
            this.animator.SetTrigger("Die_Hit");
            //속도를 0으로 변경
            this.playerRigidbody.velocity = Vector2.zero;
            //사망 상태 변경
            this.isDie = true;

            //게임 매니저의 게임오버 처리 실행
            GameManager.instance.OnPlayerDead();
        }

    }
    public void DieHeart()
    {
        if (isRun)
        {
            //사망처리
            //애니메이터의 Die 트리거 마라메터 설정
            this.animator.SetTrigger("Die_Heart");
            //속도를 0으로 변경
            this.playerRigidbody.velocity = Vector2.zero;
            //사망 상태 변경
            this.isDie = true;

            //게임 매니저의 게임오버 처리 실행
            GameManager.instance.OnPlayerDead();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 콜라이더를 가진 장애물과의 충돌감지
        if (collision.tag == "Dead" && !this.isDie)
        {
            //충돌한 상대방의 태그가 Dead고 아직 죽지 않았다면
            this.DieHit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            //isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            isRun = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        isRun = false;
    }
}
