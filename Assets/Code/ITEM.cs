using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    public GameObject shieldEffectPrefab; // 방어 효과 오브젝트의 프리팹
    private GameObject shieldEffectInstance; // 방어 효과 오브젝트의 인스턴스

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyItemEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyItemEffect(GameObject player)
    {
        if (CompareTag("ITEM"))
        {
            Debug.Log("1");
            ItemAngel itemAngel = player.GetComponent<ItemAngel>();
            if (itemAngel != null)
            {
                itemAngel.ActivateTemporaryShield();
                if (shieldEffectPrefab != null)
                {
                    if (shieldEffectInstance == null)
                    {
                        shieldEffectInstance = Instantiate(shieldEffectPrefab, player.transform);
                        shieldEffectInstance.transform.localPosition = Vector3.zero; // 플레이어의 위치에 효과를 위치시킴
                    }
                    shieldEffectInstance.SetActive(true); // 효과 활성화
                }
                StartCoroutine(DisableShieldEffectAfterTime(5f)); // 5초 후 방어 효과 비활성화
            }
        }
        else if (CompareTag("ITEM2"))
        {
            Debug.Log("2");
            
        }
        else if (CompareTag("ITEM3"))
        {
            Debug.Log("3");
            DestroyAllEnemies();
        }
    }

    private void DestroyAllEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    private IEnumerator DisableShieldEffectAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (shieldEffectInstance != null)
        {
            shieldEffectInstance.SetActive(false); // 효과 비활성화
        }
    }
}
