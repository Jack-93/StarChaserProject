using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // UI Ŭ�� ���� Ȯ��
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Debug.Log("UI Element clicked!");
                HandleUIButtonClick(touch.position); // ��ư Ŭ�� ó�� �޼��� ȣ��
                return; // UI Ŭ���� ��� ���� ������Ʈ ��ġ ������ �������� ����
            }

            // ���� ȭ�� ������ ��ġ ó��
            Debug.Log($"Touch at Screen Position: {touch.position}");
            HandleGameTouch(touch.position); // ���� ��ġ �̺�Ʈ ó�� �޼��� ȣ��
        }
    }

    // UI ��ư Ŭ�� ó�� ���� Ŭ����
    private void HandleUIButtonClick(Vector2 touchPosition)
    {
        Debug.Log($"Button clicked at: {touchPosition}");
        // ��ư�� ó�� ���� �߰� ����
        // ��: Ư�� UI ��ư�� Ŭ���ϸ� �ٸ� ����� ����
    }

    // ���� ��ġ ó�� ���� Ŭ����
    private void HandleGameTouch(Vector2 touchPosition)
    {
        Debug.Log($"Game screen touched at: {touchPosition}");
        // ���� ��ġ ���� �߰� ����
        // ��: �ʿ��� ĳ���� �̵�, ������ ��ȣ�ۿ� ��
    }
}

