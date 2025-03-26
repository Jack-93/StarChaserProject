using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabylonAI : CharacterBaseAI
{
    private void Start()
    {
        // Babylon ĳ���� ���� ���� ( �⺻ Ʋ�� ���� )
        MaxHP = 100;
        movementSpeed = 3.5f;
        attackRange = 2.0f;
        skillCooldown = 5.0f;
    }

    // AttackEnemy (CharacterBaseAI ���)
    protected override void AttackEnemy()
    {
        float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.position);
        if (distanceToEnemy <= attackRange)
        {
            Debug.Log($"Babylon is attacking {targetEnemy.name}");
            // �� ü�� ���� ���� �߰� ����
        }
    }

    // UseSkill (CharacterBaseAI ���)
    protected override void UseSkill()
    {
        skillCooldownTimer -= Time.deltaTime;
        if (skillCooldownTimer <= 0)
        {
            Debug.Log($"Babylon is using a skill on {targetEnemy.name}");
            skillCooldownTimer = skillCooldown; // ��Ÿ�� �ʱ�ȭ
            // ��ų ȿ�� �߰� ����
        }
    }

}
