using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseAI : MonoBehaviour
{
    // ���� ����, �⺻������ ��� ĳ���� ���� �Ӽ� ����
    public float movementSpeed = 3.0f;   // �̵� �ӵ�
    public float attackRange = 1.0f;     // ���� ����
    public int attackDamage = 10;        // ���� ������
    public float skillCooldown = 5.0f;   // ��ų ��Ÿ��

    protected EnemyBaseAI targetEnemy;   // ���� ��ǥ�� �Ǵ� ��(BaseEnemyAI ��ü ����)

    protected float skillCooldownTimer;  // ��ų ���� ��� �ð�

    private void Update()
    {
        // targetEnemy ��ȿ�� �˻� �� �ڵ� �ൿ
        if (targetEnemy == null || !IsTargetEnemyValid())
        {
            FindTargetEnemy();  // ��ȿ���� ������ ���ο� �� Ž��
        }
        else
        {
            MoveTowardsEnemy(); // ������ �̵�
            AttackEnemy();  // ����
            UseSkill(); // ��ų ���
        }
    }

    // ������ �̵��ϴ� �⺻ ����
    protected virtual void MoveTowardsEnemy()
    {
        float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
        if (distanceToEnemy > attackRange)
        {
            Vector2 direction = (targetEnemy.transform.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime); // �̵� ó��
            Debug.Log($"Moving towards {targetEnemy.name}");
        }
    }

    // ���� �����ϴ� �⺻ ���� (��ӹ޴� Ŭ�������� ����)
    protected abstract void AttackEnemy();

    // ��ų ��� (��ӹ޴� Ŭ�������� ����)
    protected abstract void UseSkill();

    // ���� - ���� ����� �� Ž�� (�ݶ��̴� Ž��, ���� X)
    protected virtual void FindTargetEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange * 5);
        float closestDistance = float.MaxValue;
        EnemyBaseAI closestEnemy = null;

        foreach (Collider2D collider in enemiesInRange)
        {
            EnemyBaseAI enemyAI = collider.GetComponent<EnemyBaseAI>(); // �� ��ü�� �˻�
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

        targetEnemy = closestEnemy; // ���� ����� �� ����

        if (targetEnemy != null)
        {
            Debug.Log($"Target acquired: {targetEnemy.name}");
        }
        else
        {
            Debug.Log("No valid enemies found");
        }
    }

    // targetEnemy�� ��ȿ��
    protected virtual bool IsTargetEnemyValid()
    {
        if (targetEnemy == null)
        {
            return false;
        }

        // �� ��ü�� Ȱ��
        if (!targetEnemy.gameObject.activeInHierarchy)
        {
            return false;
        }

        return true;
    }
}