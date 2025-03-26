using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterBaseAI : MonoBehaviour
{
    // ���� ����, �⺻������ ��� ĳ���� ���� �Ӽ� ����
    public int MaxHP = 100;
    public float movementSpeed = 3.0f;      // �̵� �ӵ�
    public float attackRange = 1.0f;        // ���� ����
    public float skillCooldown = 5.0f;      // ��ų ��Ÿ��

    protected Transform targetEnemy; // ���� ��ǥ�� �Ǵ� ��
    protected float skillCooldownTimer; // ��ų ���� ��� �ð�

    private void Update()
    {
        // ���� ������ �ڵ����� �ൿ�� ��
        if (targetEnemy != null)
        {
            MoveTowardsEnemy(); // ������ �̵�
            AttackEnemy();      // ����
            UseSkill();         // ��ų ���
        }
        else
        {
            FindTargetEnemy();  // �� Ž��
        }
    }

    // ������ �̵��ϴ� �⺻ ����
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

    // ���� �����ϴ� �⺻ ���� (��ӹ޴� Ŭ�������� ����)
    protected abstract void AttackEnemy();

    // ��ų ��� (��ӹ޴� Ŭ�������� ����)
    protected abstract void UseSkill();

    // ���� ����� �� Ž�� (�ݶ��̴� Ž��)
    protected virtual void FindTargetEnemy()
    {
        // ���� ����� ���� Ž��
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange * 5);
        float closestDistance = float.MaxValue;

        foreach (Collider2D enemy in enemiesInRange)
        {
            if (enemy.CompareTag("Enemy")) // �� �±� Ȯ�� -> ���� ����
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
