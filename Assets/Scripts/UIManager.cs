using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* UI ���� 
 * 1. ���۵� UI ������ Ȯ��
 */
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    // UI Class ��� 
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

    // Score UI ��� ������Ʈ
    private void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }

}
