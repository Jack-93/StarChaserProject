using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAI : MonoBehaviour
{
    // �� ���� �⺻ ����
    public float attackRange = 3.0f;       // ���� ���� ����
    public int attackDamage = 10;         // ���� �⺻ ���� ������

    protected float attackCooldown = 2.0f; // ���� ��� �ð�
    private float attackCooldownTimer;    // ���� ��Ÿ�� Ÿ�̸�

    protected CharacterBaseAI targetCharacter;
    // public EnemyBaseAI targetEnemy;


    private void Update()
    {
        AttackPlayerInRange(); // ���� �� �Ʊ��� Ž���ϰ� ����
    }

    private void AttackPlayerInRange()
    {
        // ���� ��� �ð� ����
        attackCooldownTimer -= Time.deltaTime;

        // ���� ���� �� ĳ����(�Ʊ�) Ž��
        Collider2D[] playersInRange = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D collider in playersInRange)
        {
            // CharacterBaseAI ������Ʈ�� ���� ��ü�� Ž��
            CharacterBaseAI player = collider.GetComponent<CharacterBaseAI>();
            if (player != null)
            {
                // ��ȿ�� �˻� (ü���� Health Ŭ���� Ȱ��)
                Health playerHealth = player.GetComponent<Health>();
                if (playerHealth != null && playerHealth.currentHealth > 0)
                {
                    if (attackCooldownTimer <= 0) // ���� ��Ÿ�� Ȯ��
                    {
                        Debug.Log($"Enemy attacks {player.name} for {attackDamage} damage.");

                        attackCooldownTimer = attackCooldown; // ��Ÿ�� �ʱ�ȭ

                        playerHealth.TakeDamage(attackDamage); // ü�� ����
                        Debug.Log($"{player.name} now has {playerHealth.currentHealth} health remaining.");
                    }
                }
            }
        }
    }

    // ����׿�: ���� ���� ������ �ð������� ǥ��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}