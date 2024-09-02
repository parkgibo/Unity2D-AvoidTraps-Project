using System.Collections;
using UnityEngine;

public class ItemAngel : MonoBehaviour
{
    private bool isInvincible = false;
    private bool hasTemporaryShield = false;
    private float shieldDuration = 5f; // �� ���� �ð�

    // ���� ���¸� Ȱ��ȭ�ϴ� �޼���
    public void ActivateInvincibility()
    {
        isInvincible = true;
        // �߰����� ���� ������ ���⿡ �߰�
    }

    // �ӽ� ���� Ȱ��ȭ�ϴ� �޼���
    public void ActivateTemporaryShield()
    {
        hasTemporaryShield = true;
        // �� ȿ���� Ȱ��ȭ�ϴ� ������ ���⿡ �߰�
        StartCoroutine(ShieldDurationCountdown());
    }

    private IEnumerator ShieldDurationCountdown()
    {
        yield return new WaitForSeconds(shieldDuration);
        hasTemporaryShield = false;
        // �� ȿ���� ��Ȱ��ȭ�ϴ� ������ ���⿡ �߰�
    }

    // �÷��̾ ���� �浹�� �� �� �������� üũ�ϴ� �޼���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasTemporaryShield)
        {
            // ���� �浹 �� ���� Ȱ��ȭ�� ����� ������ ���⿡ �߰�
            Debug.Log("Shield Absorbed Damage");
        }
    }
}
