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
    public GameObject angel;
    public GameObject Heal;
    private float shieldTime = 10f;
    private bool isShieldActive = false;

    void Start()
    {
        ScreenChk();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        angelstart();
        HealStart();
    }

    private void angelstart()
    {
        angel.SetActive(false);
        isShieldActive = false;
    }

    private void angelbust()
    {
       angel.SetActive(true);
       isShieldActive = true;
    }

    private void HealStart()
    {
        Heal.SetActive(false);
    }

    public void Healbust()
    {
        Heal.SetActive(true);
        StartCoroutine(ActivateDoubleScore());
    }
    public IEnumerator ActivateDoubleScore()
    {
        GameManager.Instance.ActivateDoubleScore(5f);
        yield return new WaitForSeconds(5f);
        HealStart();
    }


    void Update()
    {
        if (Input.GetMouseButton(0)) // ���콺�� �����̴� �ڵ� �� �ִϸ��̼� �۵�
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
    private void ScreenChk() //ī�޶� ����
    {
        Vector3 worldPos = Camera.main.WorldToViewportPoint(transform.position);
        if (worldPos.x < 0.05f) worldPos.x = 0.05f;
        if (worldPos.x > 0.95f) worldPos.x = 0.95f;
        transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }

    
    public IEnumerator ActivateShieldForLimitedTime()
    {
        angelbust();
        yield return new WaitForSeconds(shieldTime);
        // ���� ��Ȱ��ȭ ������ �߰��� �� ����
        angelstart();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���а� Ȱ��ȭ�� ���¿����� �浹 ó��
        if (isShieldActive && collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  // �� ����
        }
    }
    
}



