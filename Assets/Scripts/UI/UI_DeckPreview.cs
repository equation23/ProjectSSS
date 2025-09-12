using UnityEngine;
using DG.Tweening;

public class UI_DeckPreview : MonoBehaviour
{
    public UI_Card[] previewSlots; // 미리보기 슬롯 배열
    private Deck deck;

    public void Initialize(Deck deck)
    {
        this.deck = deck;
        Refresh();
    }

    public void Refresh()
    {
        if (deck == null) return;

        for (int i = 0; i < previewSlots.Length; i++)
        {
            var card = deck.Peek(i);
            if (card != null)
                previewSlots[i].SetCardAndSprite(card);
            else
                previewSlots[i].SetCardAndSprite(null);
        }
    }

    public void ShiftDownToHand(UI_Hand handUI, float duration = 0.3f, float dropOffset = 100f)
    {

        var topSlot = previewSlots[0];
        var topCard = topSlot.GetCard();

        if (topCard != null)
        {
            // Hand에서 어떤 슬롯이 새로 채워졌는지 확인
            UI_Card targetSlot = null;

            if (handUI.leftSlot.CurrentCard == topCard)
                targetSlot = handUI.leftSlot;
            else if (handUI.rightSlot.CurrentCard == topCard)
                targetSlot = handUI.rightSlot;

            if (targetSlot != null)
            {
                // 임시 이미지 생성
                var movingImg = Instantiate(topSlot.cardImage, topSlot.cardImage.transform.parent);
                movingImg.sprite = topSlot.cardImage.sprite;
                movingImg.rectTransform.position = topSlot.cardImage.rectTransform.position;

                // 이동 애니메이션
                movingImg.rectTransform.DOMove(targetSlot.cardImage.rectTransform.position, duration)
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(() =>
                    {
                        targetSlot.SetCardSprite();  // Hand UI 갱신
                        Destroy(movingImg.gameObject);
                    });
            }
        }

        //덱 프리뷰는 한 칸 내려오기
        for (int i = 0; i < previewSlots.Length - 1; i++)
        {
            int currentIndex = i;
            var slot = previewSlots[currentIndex];

            // 다음 카드 데이터
            var nextCard = previewSlots[currentIndex + 1].GetCard();

            // 임시 카드 UI를 위쪽(dropOffset)에서 시작
            var img = slot.cardImage;
            Vector3 startPos = img.rectTransform.localPosition + new Vector3(0, dropOffset, 0);

            img.rectTransform.localPosition = startPos;

            // 카드 교체
            slot.SetCardAndSprite(nextCard);

            // 애니메이션: 위에서 아래로 떨어지기
            img.rectTransform.DOLocalMoveY(startPos.y - dropOffset, duration)
                .SetEase(Ease.OutBounce);
        }
        int last = previewSlots.Length - 1;
        previewSlots[last].SetCardAndSprite(deck.Peek(last));
    }
}
