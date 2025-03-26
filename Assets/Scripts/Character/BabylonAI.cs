using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabylonAI : CharacterBaseAI
{
    private void Start()
    {
        // Babylon 캐릭터 고유 설정 ( 기본 틀은 공유 )
        MaxHP = 100;
        movementSpeed = 3.5f;
        attackRange = 2.0f;
        skillCooldown = 5.0f;
    }

    // AttackEnemy (CharacterBaseAI 상속)
    protected override void AttackEnemy()
    {
        float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.position);
        if (distanceToEnemy <= attackRange)
        {
            Debug.Log($"Babylon is attacking {targetEnemy.name}");
            // 적 체력 감소 로직 추가 가능
        }
    }

    // UseSkill (CharacterBaseAI 상속)
    protected override void UseSkill()
    {
        skillCooldownTimer -= Time.deltaTime;
        if (skillCooldownTimer <= 0)
        {
            Debug.Log($"Babylon is using a skill on {targetEnemy.name}");
            skillCooldownTimer = skillCooldown; // 쿨타임 초기화
            // 스킬 효과 추가 가능
        }
    }

}
