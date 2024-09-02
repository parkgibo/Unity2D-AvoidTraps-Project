using System.Collections;
using UnityEngine;

public class ItemAngel : MonoBehaviour
{
    private bool isInvincible = false;
    private bool hasTemporaryShield = false;
    private float shieldDuration = 5f; // 방어막 지속 시간

    // 무적 상태를 활성화하는 메서드
    public void ActivateInvincibility()
    {
        isInvincible = true;
        // 추가적인 무적 로직을 여기에 추가
    }

    // 임시 방어막을 활성화하는 메서드
    public void ActivateTemporaryShield()
    {
        hasTemporaryShield = true;
        // 방어막 효과를 활성화하는 로직을 여기에 추가
        StartCoroutine(ShieldDurationCountdown());
    }

    private IEnumerator ShieldDurationCountdown()
    {
        yield return new WaitForSeconds(shieldDuration);
        hasTemporaryShield = false;
        // 방어막 효과를 비활성화하는 로직을 여기에 추가
    }

    // 플레이어가 적과 충돌할 때 방어막 상태인지 체크하는 메서드
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasTemporaryShield)
        {
            // 적과 충돌 시 방어막이 활성화된 경우의 로직을 여기에 추가
            Debug.Log("Shield Absorbed Damage");
        }
    }
}
