using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;

    [SerializeField]
    private Sprite animalSprite; // 카드 앞면

    [SerializeField]
    private Sprite backSprite; // 카드 뒷면

    private bool isFlipped = false;
    private bool isFlipping = false;
    public int cardID;
    private bool isMatched = false;

    public void SetCardID(int id) {
        cardID = id;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetAnimalSprite(Sprite sprite) {
        this.animalSprite = sprite;
    }

    public void FlipCard() {
        isFlipping = true;

        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);
        transform.DOScale(targetScale, 0.2f).OnComplete(() => { // 0.2f 동안 끝나면 {}의 동작을 한다.
            isFlipped = !isFlipped;
            if (isFlipped) {
                cardRenderer.sprite = animalSprite;
            } else {
                cardRenderer.sprite = backSprite;
            }

            transform.DOScale(originalScale, 0.2f).OnComplete(() => {
                isFlipping = false;
            });
        }); // 원하는 시간동안 원하는 scale 변화를 줘서 부드럽게 움직이는 효과를 준다.
    }

    void OnMouseDown() {
        if (!isFlipping && !isMatched && !isFlipped) {
            GameManager.instance.CardClicked(this);
        }
    }

    public void SetMatched() {
        isMatched = true;
    }
}
