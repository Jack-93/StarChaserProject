using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAI : MonoBehaviour
{
    // �� ���� �⺻ Ʋ ( ĳ�������� Ư���� ĳ���Ϳ� ����� )
    public int MaxHP = 100;               // ���� �ִ� ü��
    public float attackRange = 3.0f;      // ���� ���� ����
    public float attackDamage = 10.0f;    // ���� �⺻ ���� ������
    protected float attackCooldown = 2.0f; // ���� ��� �ð�
    private float attackCooldownTimer;

    private void Update()
    {
        AttackPlayerInRange();
    }

    private void AttackPlayerInRange()
    {
        // ���� ��� �ð� ����, ���� �ð��� ���� ����
        attackCooldownTimer -= Time.deltaTime;

        // ���� �ȿ� �ִ� �Ʊ��� Ž�� (�ݶ��̴� Ž��)
        Collider2D[] playersInRange = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D player in playersInRange)
        {
            if (player.CompareTag("Player")) // Player �±׸� ���� �Ʊ� -> ���� ����
            {
                if (attackCooldownTimer <= 0)
                {
                    Debug.Log($"Enemy attacks {player.name} for {attackDamage} damage.");
                    attackCooldownTimer = attackCooldown;
                    // ���⿡ �Ʊ� ü�� ���� ���� �߰� ����
                }
            }
        }
    }

    // �� ü�� ���� �޼���
    public void TakeDamage(int damage)
    {
        MaxHP -= damage;
        Debug.Log($"Enemy takes {damage} damage. Remaining HP: {MaxHP}");
        if (MaxHP <= 0)
        {
            Die();
        }
    }

    // ���� ������� ���� ����
    protected virtual void Die()
    {
        Debug.Log("Enemy has been defeated.");
        Destroy(gameObject);
    }

    // ���� ���� ������ �ð������� ǥ�� (����׿�)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
