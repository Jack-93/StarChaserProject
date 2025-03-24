using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 게임 저장 및 로드 관리 - GameManager 연동
 * 1. 게임 저장 - 점수, 플레이어 정보 등
 * 2. 씬 로드
 */
public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }

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

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Score", GameManager.Instance.score);
        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        GameManager.Instance.score = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Game Loaded!");
    }

}
