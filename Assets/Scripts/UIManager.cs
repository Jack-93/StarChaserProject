using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* UI 관리 
 * 1. 제작된 UI 디자인 확인
 */
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    // UI Class 사용 
    public Text scoreText;

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

    // Score UI 상시 업데이트
    private void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }

}
