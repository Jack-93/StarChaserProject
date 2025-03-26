using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabylonAI : CharacterBaseAI
{
    private void Start()
    {
        // Babylon ĳ���� ���� ���� ( �⺻ Ʋ�� ���� )
        attackRange = 2.0f;
        attackDamage = 10;
        skillCooldown = 5.0f;
    }

    // AttackEnemy (CharacterBaseAI ���)
    protected override void AttackEnemy()
    {
        if (targetEnemy != null) // targetEnemy�� null�� �ƴϸ� ����
        {
            // targetEnemy�� EnemyBaseAI, EnemyBaseAI�� MonoBehaviour ��� -> transform���� ��ġ ���� �̿�
            float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
            if (distanceToEnemy <= attackRange)
            {
                Debug.Log($"Babylon attacks {targetEnemy.name}");

                // ���� Health ������Ʈ�� ã�� �������� ����
                Health enemyHealth = targetEnemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage); // ������ ����
                }
            }
        }
        else
        {
            Debug.Log("No target enemy to attack");
        }
    }

    // UseSkill (CharacterBaseAI ���)
    protected override void UseSkill()
    {
        if (targetEnemy != null) // targetEnemy�� ��ȿ���� Ȯ��
        {
            skillCooldownTimer -= Time.deltaTime;
            if (skillCooldownTimer <= 0)
            {
                Debug.Log($"Babylon is using a skill on {targetEnemy.name}");
                skillCooldownTimer = skillCooldown; // ��Ÿ�� �ʱ�ȭ
                // ��ų ȿ�� �߰� ����
            }
        }
        else
        {
            Debug.Log("No target enemy to use skill on");
        }
    }
}