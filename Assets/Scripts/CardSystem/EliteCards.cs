using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteCards : MonoBehaviour
{
    public static Card CreateBattleshipCard(Sprite battleshipImage)
    {
        return new Card(
            "Battleship",                      // ī�� ������ �̸�
            "������ ����� ���� ��������� ������ ����", // ī�� ����
            CardGrade.Elite,                  // ���
            battleshipImage,                  // �̹���
            "���� ����",                     // ���� ��ų �̸�
            "������ 30% �߰� ���ظ� �ָ�, 2�� ���� ������ 15% ����", // ��ų ȿ��
            120,                              // ���ݷ�
            80,                               // ����
            400                               // ü��
        );
    }
}
