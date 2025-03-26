using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabylonAI : CharacterBaseAI
{
    private void Start()
    {
        // Babylon 캐릭터 고유 설정 ( 기본 틀은 공유 )
        attackRange = 2.0f;
        attackDamage = 10;
        skillCooldown = 5.0f;
    }

    // AttackEnemy (CharacterBaseAI 상속)
    protected override void AttackEnemy()
    {
        if (targetEnemy != null) // targetEnemy가 null이 아니면 실행
        {
            // targetEnemy는 EnemyBaseAI, EnemyBaseAI는 MonoBehaviour 상속 -> transform으로 위치 정보 이용
            float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
            if (distanceToEnemy <= attackRange)
            {
                Debug.Log($"Babylon attacks {targetEnemy.name}");

                // 적의 Health 컴포넌트를 찾아 데미지를 적용
                Health enemyHealth = targetEnemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage); // 데미지 적용
                }
            }
        }
        else
        {
            Debug.Log("No target enemy to attack");
        }
    }

    // UseSkill (CharacterBaseAI 상속)
    protected override void UseSkill()
    {
        if (targetEnemy != null) // targetEnemy가 유효한지 확인
        {
            skillCooldownTimer -= Time.deltaTime;
            if (skillCooldownTimer <= 0)
            {
                Debug.Log($"Babylon is using a skill on {targetEnemy.name}");
                skillCooldownTimer = skillCooldown; // 쿨타임 초기화
                // 스킬 효과 추가 가능
            }
        }
        else
        {
            Debug.Log("No target enemy to use skill on");
        }
    }
}