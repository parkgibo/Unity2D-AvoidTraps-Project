using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer renderer;
    private float speed = 8;
    private bool isDead;


    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
 
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) // 마우스로 움직이는 코드 및 애니메이션 작동
        {
            float mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float direction = Mathf.Sign(mousePositionX - transform.position.x);
            rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(direction));
            renderer.flipX = direction < 0;
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            animator.SetFloat("Speed", 0f);
        }
    }
    private void ScreenChk() //카메라 고정
    {
        Vector3 worldPos = Camera.main.WorldToViewportPoint(transform.position);
        if (worldPos.x < 0.05f) worldPos.x = 0.05f;
        if (worldPos.x > 0.95f) worldPos.x = 0.95f;
        transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }
}



/*
 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer renderer;
    private float speed = 8;
    private float horizontal;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (GameManager.Instance.stopTrigger)
        {
            
            PlayerMove();
            animator.SetTrigger("Start");
            
        }
        if (!GameManager.Instance.stopTrigger)
        {
            animator.SetTrigger("Dead");
        }
        ScreenChk();
    }

    private void PlayerMove()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (horizontal < 0)
        {
            renderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            renderer.flipX = false;
        }
            rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }

    private void ScreenChk()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
 */