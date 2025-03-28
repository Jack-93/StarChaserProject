using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;       // 카드 이름
    public string description;    // 카드 설명
    public CardGrade grade;       // 카드 등급 
    public Sprite cardImage;      // 카드 이미지

    public string skillName;      // 카드 고유 스킬 이름
    public string skillDescription;    // 스킬 효과 설명

    public int attack;            // 공격력
    public int defense;           // 방어력
    public int health;            // 체력


    // 카드 생성자 (상세정보 기입)
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

// 4가지 카드 등급 - Enum -> 분류 편의
public enum CardGrade
{
    Normal,  // 일반
    Extra,   // 엑스트라
    Elite,   // 엘리트
    Superial // 슈퍼리얼
}


