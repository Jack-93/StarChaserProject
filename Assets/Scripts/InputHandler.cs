using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 사용자 키 인풋 매니저
 * 1. UI 상호작용 위주의 게임 플레이
 * 2. Touch - TouchCount, Touch.phase, TouchPosition 등
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

            // UI 클릭 여부 확인
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Debug.Log("UI Element clicked!");
                HandleUIButtonClick(touch.position); // 버튼 클릭 처리 메서드 호출
                return; // UI 클릭인 경우 게임 오브젝트 터치 로직을 실행하지 않음
            }

            // 게임 화면 내에서 터치 처리
            Debug.Log($"Touch at Screen Position: {touch.position}");
            HandleGameTouch(touch.position); // 게임 터치 이벤트 처리 메서드 호출
        }
    }

    // UI 버튼 클릭 처리 관리 클래스
    private void HandleUIButtonClick(Vector2 touchPosition)
    {
        Debug.Log($"Button clicked at: {touchPosition}");
        // 버튼별 처리 로직 추가 가능
        // 예: 특정 UI 버튼을 클릭하면 다른 기능을 실행
    }

    // 게임 터치 처리 관리 클래스
    private void HandleGameTouch(Vector2 touchPosition)
    {
        Debug.Log($"Game screen touched at: {touchPosition}");
        // 게임 터치 로직 추가 가능
        // 예: 맵에서 캐릭터 이동, 아이템 상호작용 등
    }
}

