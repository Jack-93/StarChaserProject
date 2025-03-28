using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Superial ����� ī�� ����
public class SuperialCards : MonoBehaviour
{
    public static Card CreateCaesarCard(Sprite caesarImage)
    {
        return new Card(
            "Caesar",                        // ī�� ������ �̸�
            "������ �����ϸ� ������ ����ϴ� ������", // ī�� ����
            CardGrade.Superial,              // ���
            caesarImage,                     // �̹���
            "������ ������",                  // ���� ��ų �̸�
            "�Ʊ� ��ü ���ݷ� 10% ���� �� ���� ���� 20% ����", // ��ų ȿ��
            150,                             // ���ݷ�
            100,                             // ����
            500                              // ü��
        );
    }

}
