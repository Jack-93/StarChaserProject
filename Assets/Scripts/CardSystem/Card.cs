using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;       // ī�� �̸�
    public string description;    // ī�� ����
    public CardGrade grade;       // ī�� ��� 
    public Sprite cardImage;      // ī�� �̹���

    public string skillName;      // ī�� ���� ��ų �̸�
    public string skillDescription;    // ��ų ȿ�� ����

    public int attack;            // ���ݷ�
    public int defense;           // ����
    public int health;            // ü��


    // ī�� ������ (������ ����)
    public Card(string name, string desc, CardGrade grade, Sprite image, string skillN, string skillDes,
        int attack, int defense, int health)
    {
        this.cardName = name;
        this.description = desc;
        this.grade = grade;
        this.cardImage = image;
        this.skillName = skillN;
        this.skillDescription = skillDes;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        
    }
}

// 4���� ī�� ��� - Enum -> �з� ����
public enum CardGrade
{
    Normal,  // �Ϲ�
    Extra,   // ����Ʈ��
    Elite,   // ����Ʈ
    Superial // ���۸���
}


