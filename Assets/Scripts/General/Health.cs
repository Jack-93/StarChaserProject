using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;  // 최대 체력
    public int currentHealth;   // 현재 체력

    private void Start()
    {
        currentHealth = maxHealth; // 체력 초기화
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 체력 감소
        Debug.Log($"{gameObject.name} takes {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하이면 사망
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // 체력 증가
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // 최대 체력을 초과하지 않도록 제한
        }
        Debug.Log($"{gameObject.name} healed for {amount}. Current health: {currentHealth}");
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject); // 사망 시 오브젝트 삭제
    }

}
