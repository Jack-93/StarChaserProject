using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;  // �ִ� ü��
    public int currentHealth;   // ���� ü��

    private void Start()
    {
        currentHealth = maxHealth; // ü�� �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ü�� ����
        Debug.Log($"{gameObject.name} takes {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 �����̸� ���
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // ü�� ����
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // �ִ� ü���� �ʰ����� �ʵ��� ����
        }
        Debug.Log($"{gameObject.name} healed for {amount}. Current health: {currentHealth}");
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject); // ��� �� ������Ʈ ����
    }

}
