using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        if (Input.touchCount > 0) // 모바일 디바이스 터치 인식 시
        {
            Touch touch = Input.GetTouch(0);

            // 화면 좌표 출력 - UI 상호작용 위주의 게임 플레이 -> 월드좌표 사용 X
            Debug.Log($"Touch at Screen Position: {touch.position}");

            // 추가 이벤트 처리(예: UI 버튼 클릭 확인)
            // UI 관련 로직 추가 가능
        }
    }

}
