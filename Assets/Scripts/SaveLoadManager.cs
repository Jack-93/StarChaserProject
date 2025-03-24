using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ���� ���� �� �ε� ���� - GameManager ����
 * 1. ���� ���� - ����, �÷��̾� ���� ��
 * 2. �� �ε�
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
