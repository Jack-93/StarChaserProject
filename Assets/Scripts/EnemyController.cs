using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* �� ���� ����
 * 1. �÷��̾� ��� ����
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

