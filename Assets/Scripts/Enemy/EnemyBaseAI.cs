using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAI : MonoBehaviour
{
    // 적 스펙 기본 변수
    public float attackRange = 3.0f;       // 적의 공격 범위
    public int attackDamage = 10;         // 적의 기본 공격 데미지

    protected float attackCooldown = 2.0f; // 공격 대기 시간
    private float attackCooldownTimer;    // 공격 쿨타임 타이머

    protected CharacterBaseAI targetCharacter;
    // public EnemyBaseAI targetEnemy;


    private void Update()
    {
        AttackPlayerInRange(); // 범위 내 아군을 탐색하고 공격
    }

    private void AttackPlayerInRange()
    {
        // 공격 대기 시간 감소
        attackCooldownTimer -= Time.deltaTime;

        // 공격 범위 내 캐릭터(아군) 탐색
        Collider2D[] playersInRange = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D collider in playersInRange)
        {
            // CharacterBaseAI 컴포넌트를 가진 객체를 탐색
            CharacterBaseAI player = collider.GetComponent<CharacterBaseAI>();
            if (player != null)
            {
                // 유효성 검사 (체력은 Health 클래스 활용)
                Health playerHealth = player.GetComponent<Health>();
                if (playerHealth != null && playerHealth.currentHealth > 0)
                {
                    if (attackCooldownTimer <= 0) // 공격 쿨타임 확인
                    {
                        Debug.Log($"Enemy attacks {player.name} for {attackDamage} damage.");

                        attackCooldownTimer = attackCooldown; // 쿨타임 초기화

                        playerHealth.TakeDamage(attackDamage); // 체력 감소
                        Debug.Log($"{player.name} now has {playerHealth.currentHealth} health remaining.");
                    }
                }
            }
        }
    }

    // 디버그용: 적의 공격 범위를 시각적으로 표시
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}