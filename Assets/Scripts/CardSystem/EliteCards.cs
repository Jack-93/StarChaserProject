using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteCards : MonoBehaviour
{
    public static Card CreateBattleshipCard(Sprite battleshipImage)
    {
        return new Card(
            "Battleship",                      // 카드 데이터 이름
            "전장을 누비며 적을 쓸어버리는 무적의 전함", // 카드 설명
            CardGrade.Elite,                  // 등급
            battleshipImage,                  // 이미지
            "전함 포격",                     // 고유 스킬 이름
            "적에게 30% 추가 피해를 주며, 2턴 동안 방어력을 15% 감소", // 스킬 효과
            120,                              // 공격력
            80,                               // 방어력
            400                               // 체력
        );
    }
}
