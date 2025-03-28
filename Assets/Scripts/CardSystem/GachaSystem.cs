using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<Card> allCards;        // ��ü ī�� ����Ʈ (��� ī��� �̰��� ���)
    public List<Card> playerCollection; // �÷��̾ ������ ī�� ����Ʈ

    private void Start()
    {
        playerCollection = new List<Card>(); // �÷��̾��� �ʱ� ī�� �÷��� -> ���⿡ �̱� �� ����Ʈ �߰�
        Debug.Log("Gacha System Ready!");
    }

    // ī�� �̱� �޼���
    public void PullCard()
    {
        // Ȯ���� ���� ī�� ��� ����
        CardGrade grade = GetRandomGrade();

        // �ش� ����� ī�� �߿��� �������� 1�� ����
        List<Card> availableCards = allCards.FindAll(card => card.grade == grade);
        if (availableCards.Count > 0)
        {
            // ������ ī�� ����
            Card pulledCard = availableCards[Random.Range(0, availableCards.Count)];

            // �̱� Ȯ�� �����
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

            // �÷��̾� �÷��ǿ� �߰�
            playerCollection.Add(pulledCard);

            // ���� ī�� ���
            Debug.Log($"You picked a {pulledCard.grade} card: {pulledCard.cardName}");
        }
        else
        {
            Debug.Log("No cards available for the selected grade!");
        }
    }


    // ��� Ȯ�� ����
    private CardGrade GetRandomGrade()
    {
        float randomValue = Random.Range(0f, 100f); // 0 ~ 100 ������ ����
        if (randomValue < 50f) return CardGrade.Normal;   // 50% Ȯ���� Normal
        if (randomValue < 80f) return CardGrade.Extra;    // 30% Ȯ���� Extra
        if (randomValue < 95f) return CardGrade.Elite;    // 15% Ȯ���� Elite
        return CardGrade.Superial;                       // 5% Ȯ���� Superial
    }
}
