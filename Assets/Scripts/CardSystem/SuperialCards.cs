using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Superial 등급의 카드 생성
public class SuperialCards : MonoBehaviour
{
    public static Card CreateCaesarCard(Sprite caesarImage)
    {
        return new Card(
            "Caesar",                        // 카드 데이터 이름
            "전투를 지휘하며 전장을 장악하는 전략가", // 카드 설명
            CardGrade.Superial,              // 등급
            caesarImage,                     // 이미지
            "전장의 지휘자",                  // 고유 스킬 이름
            "아군 전체 공격력 10% 증가 및 적의 방어력 20% 감소", // 스킬 효과
            150,                             // 공격력
            100,                             // 방어력
            500                              // 체력
        );
    }

}
