using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterBaseAI : MonoBehaviour
{
    // 공통 변수, 기본적으로 모든 캐릭터 같은 속성 공유
    public int MaxHP = 100;
    public float movementSpeed = 3.0f;      // 이동 속도
    public float attackRange = 1.0f;        // 공격 범위
    public float skillCooldown = 5.0f;      // 스킬 쿨타임

    protected Transform targetEnemy; // 현재 목표가 되는 적
    protected float skillCooldownTimer; // 스킬 재사용 대기 시간

    private void Update()
    {
        // 적이 있으면 자동으로 행동할 것
        if (targetEnemy != null)
        {
            MoveTowardsEnemy(); // 적에게 이동
            AttackEnemy();      // 공격
            UseSkill();         // 스킬 사용
        }
        else
        {
            FindTargetEnemy();  // 적 탐색
        }
    }

    // 적으로 이동하는 기본 동작
    protected virtual void MoveTowardsEnemy()
    {
        float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.position);
        if (distanceToEnemy > attackRange)
        {
            Vector2 direction = (targetEnemy.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);
            Debug.Log($"Moving towards {targetEnemy.name}");
        }
    }

    // 적을 공격하는 기본 동작 (상속받는 클래스에서 구현)
    protected abstract void AttackEnemy();

    // 스킬 사용 (상속받는 클래스에서 구현)
    protected abstract void UseSkill();

    // 가장 가까운 적 탐색 (콜라이더 탐색)
    protected virtual void FindTargetEnemy()
    {
        // 가장 가까운 적을 탐색
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange * 5);
        float closestDistance = float.MaxValue;

        foreach (Collider2D enemy in enemiesInRange)
        {
            if (enemy.CompareTag("Enemy")) // 적 태그 확인 -> 가장 빠름
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    targetEnemy = enemy.transform;
                }
            }
        }

        if (targetEnemy != null)
        {
            Debug.Log($"Target acquired: {targetEnemy.name}");
        }
    }
}
