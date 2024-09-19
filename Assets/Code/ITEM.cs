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
    

    // Collider2D�� ����
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
            // Player Ŭ������ ActivateShieldForLimitedTime �ڷ�ƾ ȣ��
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
            DestroyAllEnemies();// �� ���� ȿ��
            Destroy(gameObject);
            
        }
    }
    private void DestroyAllEnemies() // ������ ��ź(�� ��ü ���� ���� ȿ��)
    {
        
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
            
        }
        
    }


}
