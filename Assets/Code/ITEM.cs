using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    public GameObject angel;
    private float shieldTime = 10f;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    

    // Collider2D로 변경
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            ApplyItemEffect(collision.gameObject);
        }
    }
    private void ApplyItemEffect(GameObject player)
    {
        if (CompareTag("ITEM"))
        {
            Debug.Log("1");
            // Player 클래스의 ActivateShieldForLimitedTime 코루틴 호출
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.StartCoroutine(playerScript.ActivateShieldForLimitedTime());
            }
        }
        if (CompareTag("ITEM2"))
        {
            Debug.Log("2");
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.Healbust();
            }
        }
        if (CompareTag("ITEM3"))
        {
           
            Debug.Log("3");
            DestroyAllEnemies();// 적 제거 효과
            Destroy(gameObject);
            
        }
    }
    private void DestroyAllEnemies() // 아이템 폭탄(적 개체 전부 제거 효과)
    {
        
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
            
        }
        
    }


}
