using UnityEngine;
using UnityEngine.XR;

public class UIManager
{
    public UI_Hand handUI;
    public UI_DeckPreview deckPreviewUI;

    private UI_Root _root;

    public void SetRoot(UI_Root root) => _root = root;

    public void Initialize(CardHand hand, Deck deck)
    {

        if (_root == null)
            return;

        var canvas = Object.FindAnyObjectByType<Canvas>();

        if (handUI == null)
        {
            var prefab = Resources.Load<UI_Hand>("Prefabs/HandUI");
            handUI = Object.Instantiate(prefab, _root.transform);
        }

        if (deckPreviewUI == null)
        {
            var prefab = Resources.Load<UI_DeckPreview>("Prefabs/DeckPreviewUI");
            deckPreviewUI = Object.Instantiate(prefab, _root.transform);
        }

        handUI.Initialize(hand);
        deckPreviewUI.Initialize(deck);
    }


    public void UpdateCardUI()
    {
      // Hand 데이터를 먼저 갱신
        handUI.GetHand().RefreshHand();

        // Hand UI 갱신
        handUI.Refresh();

        deckPreviewUI.ShiftDownToHand(handUI);
    }
}
