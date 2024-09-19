using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Rigidbody2D rigidbody;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.Instance.Score();
            animator.SetTrigger("EnemyTrigger");
            
        }
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
            MainSound mainSound = FindObjectOfType<MainSound>();
            if (mainSound != null)
            {
                mainSound.StopMusicOnPlayerCollision(); // À½¾Ç Á¤Áö
            }
            animator.SetTrigger("Enemy");
            animator.SetTrigger("EnemyTrigger");
        }
    }
}


