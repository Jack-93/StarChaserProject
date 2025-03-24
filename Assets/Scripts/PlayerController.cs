using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 플레이어 스펙 조절
 * 1. 속도, 이동 등 2D 이동 적용
 * 2. 
 */
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);
    }


}
