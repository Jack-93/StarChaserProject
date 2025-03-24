using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* ����� Ű ��ǲ �Ŵ���
 * 1. UI ��ȣ�ۿ� ������ ���� �÷���
 * 2. Touch - TouchCount, Touch.phase, TouchPosition ��
 * 
 */
public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleTouchInput()
    {

        if (Input.touchCount > 0) // ����� ����̽� ��ġ �ν� ��
        {
            Touch touch = Input.GetTouch(0);

            // ȭ�� ��ǥ ��� - UI ��ȣ�ۿ� ������ ���� �÷��� -> ������ǥ ��� X
            Debug.Log($"Touch at Screen Position: {touch.position}");

            // �߰� �̺�Ʈ ó��(��: UI ��ư Ŭ�� Ȯ��)
            // UI ���� ���� �߰� ����
        }
    }

}
