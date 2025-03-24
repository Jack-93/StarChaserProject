using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 적 스펙 관리
 * 1. 플레이어 대비 조절
 */
public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}

