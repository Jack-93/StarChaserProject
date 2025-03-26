using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAI : MonoBehaviour
{
    // 적 스펙 기본 틀 ( 캐릭터적인 특성은 캐릭터와 비슷함 )
    public int MaxHP = 100;               // 적의 최대 체력
    public float attackRange = 3.0f;      // 적의 공격 범위
    public float attackDamage = 10.0f;    // 적의 기본 공격 데미지
    protected float attackCooldown = 2.0f; // 공격 대기 시간
    private float attackCooldownTimer;

    private void Update()
    {
        AttackPlayerInRange();
    }

    private void AttackPlayerInRange()
    {
        // 공격 대기 시간 감소, 현실 시간에 따라 감소
        attackCooldownTimer -= Time.deltaTime;

        // 범위 안에 있는 아군을 탐색 (콜라이더 탐색)
        Collider2D[] playersInRange = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D player in playersInRange)
        {
            if (player.CompareTag("Player")) // Player 태그를 가진 아군 -> 가장 빠름
            {
                if (attackCooldownTimer <= 0)
                {
                    Debug.Log($"Enemy attacks {player.name} for {attackDamage} damage.");
                    attackCooldownTimer = attackCooldown;
                    // 여기에 아군 체력 감소 로직 추가 가능
                }
            }
        }
    }

    // 적 체력 감소 메서드
    public void TakeDamage(int damage)
    {
        MaxHP -= damage;
        Debug.Log($"Enemy takes {damage} damage. Remaining HP: {MaxHP}");
        if (MaxHP <= 0)
        {
            Die();
        }
    }

    // 적이 사망했을 때의 동작
    protected virtual void Die()
    {
        Debug.Log("Enemy has been defeated.");
        Destroy(gameObject);
    }

    // 적의 공격 범위를 시각적으로 표시 (디버그용)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
