using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<Card> allCards;        // 전체 카드 리스트 (모든 카드는 이곳에 등록)
    public List<Card> playerCollection; // 플레이어가 소유한 카드 리스트

    private void Start()
    {
        playerCollection = new List<Card>(); // 플레이어의 초기 카드 컬렉션 -> 여기에 뽑기 시 리스트 추가
        Debug.Log("Gacha System Ready!");
    }

    // 카드 뽑기 메서드
    public void PullCard()
    {
        // 확률에 따라 카드 등급 결정
        CardGrade grade = GetRandomGrade();

        // 해당 등급의 카드 중에서 무작위로 1장 선택
        List<Card> availableCards = allCards.FindAll(card => card.grade == grade);
        if (availableCards.Count > 0)
        {
            // 무작위 카드 선택
            Card pulledCard = availableCards[Random.Range(0, availableCards.Count)];

            // 뽑기 확률 적용됨
            if (pulledCard.cardName == "Caesar")
            {
                Sprite caesarSprite = Resources.Load<Sprite>("Art/Cards/Superial/Caesar");
                pulledCard = SuperialCards.CreateCaesarCard(caesarSprite);
            }
            else if (pulledCard.cardName == "Battleship")
            {
                Sprite battleshipSprite = Resources.Load<Sprite>("Art/Cards/Elite/Battleship");
                pulledCard = EliteCards.CreateBattleshipCard(battleshipSprite);
            }

            // 플레이어 컬렉션에 추가
            playerCollection.Add(pulledCard);

            // 뽑은 카드 출력
            Debug.Log($"You picked a {pulledCard.grade} card: {pulledCard.cardName}");
        }
        else
        {
            Debug.Log("No cards available for the selected grade!");
        }
    }


    // 등급 확률 로직
    private CardGrade GetRandomGrade()
    {
        float randomValue = Random.Range(0f, 100f); // 0 ~ 100 사이의 난수
        if (randomValue < 50f) return CardGrade.Normal;   // 50% 확률로 Normal
        if (randomValue < 80f) return CardGrade.Extra;    // 30% 확률로 Extra
        if (randomValue < 95f) return CardGrade.Elite;    // 15% 확률로 Elite
        return CardGrade.Superial;                       // 5% 확률로 Superial
    }
}
