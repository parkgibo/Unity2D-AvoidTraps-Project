using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    public GameObject shieldEffectPrefab; // ��� ȿ�� ������Ʈ�� ������
    private GameObject shieldEffectInstance; // ��� ȿ�� ������Ʈ�� �ν��Ͻ�

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
                        shieldEffectInstance.transform.localPosition = Vector3.zero; // �÷��̾��� ��ġ�� ȿ���� ��ġ��Ŵ
                    }
                    shieldEffectInstance.SetActive(true); // ȿ�� Ȱ��ȭ
                }
                StartCoroutine(DisableShieldEffectAfterTime(5f)); // 5�� �� ��� ȿ�� ��Ȱ��ȭ
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
            shieldEffectInstance.SetActive(false); // ȿ�� ��Ȱ��ȭ
        }
    }
}
