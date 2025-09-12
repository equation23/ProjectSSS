using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardData", fileName = "NewCardData")]
public class CardData : ScriptableObject
{
    public CardEnum cardEnum;      // 카드 타입 (예: GUNFIRE, SWORDATTACK)
    public Sprite cardSprite;      // 카드 이미지
    public string cardName;        // 카드 이름
    [TextArea]
    public string description;     // 카드 설명
    public int cost;               // 사용 비용 
}