using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseAI : MonoBehaviour
{
    // 공통 변수, 기본적으로 모든 캐릭터 같은 속성 공유
    public float movementSpeed = 3.0f;   // 이동 속도
    public float attackRange = 1.0f;     // 공격 범위
    public int attackDamage = 10;        // 공격 데미지
    public float skillCooldown = 5.0f;   // 스킬 쿨타임

    protected EnemyBaseAI targetEnemy;   // 현재 목표가 되는 적(BaseEnemyAI 객체 참조)

    protected float skillCooldownTimer;  // 스킬 재사용 대기 시간

    private void Update()
    {
        // targetEnemy 유효성 검사 및 자동 행동
        if (targetEnemy == null || !IsTargetEnemyValid())
        {
            FindTargetEnemy();  // 유효하지 않으면 새로운 적 탐색
        }
        else
        {
            MoveTowardsEnemy(); // 적에게 이동
            AttackEnemy();  // 공격
            UseSkill(); // 스킬 사용
        }
    }

    // 적으로 이동하는 기본 동작
    protected virtual void MoveTowardsEnemy()
    {
        float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
        if (distanceToEnemy > attackRange)
        {
            Vector2 direction = (targetEnemy.transform.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime); // 이동 처리
            Debug.Log($"Moving towards {targetEnemy.name}");
        }
    }

    // 적을 공격하는 기본 동작 (상속받는 클래스에서 구현)
    protected abstract void AttackEnemy();

    // 스킬 사용 (상속받는 클래스에서 구현)
    protected abstract void UseSkill();

    // 공통 - 가장 가까운 적 탐색 (콜라이더 탐색, 공격 X)
    protected virtual void FindTargetEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange * 5);
        float closestDistance = float.MaxValue;
        EnemyBaseAI closestEnemy = null;

        foreach (Collider2D collider in enemiesInRange)
        {
            EnemyBaseAI enemyAI = collider.GetComponent<EnemyBaseAI>(); // 적 객체를 검색
            if (enemyAI != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemyAI.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemyAI;
                }
            }
        }

        targetEnemy = closestEnemy; // 가장 가까운 적 설정

        if (targetEnemy != null)
        {
            Debug.Log($"Target acquired: {targetEnemy.name}");
        }
        else
        {
            Debug.Log("No valid enemies found");
        }
    }

    // targetEnemy의 유효성
    protected virtual bool IsTargetEnemyValid()
    {
        if (targetEnemy == null)
        {
            return false;
        }

        // 적 객체가 활성
        if (!targetEnemy.gameObject.activeInHierarchy)
        {
            return false;
        }

        return true;
    }
}