using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<Card> allCards;

    private Card flippedCard;
    private bool isFlipping = false;

    [SerializeField]
    private Slider timeoutSlider;

    [SerializeField]
    private float timeLimit = 60f;
    private float currentTime;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Board board = FindFirstObjectByType<Board>();
        allCards = board.GetCards();

        currentTime = timeLimit;
        StartCoroutine("FlipAllCardsRoutine");
    }

    IEnumerator FlipAllCardsRoutine() {
        isFlipping = true;
        
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.2f);

        isFlipping = false;

        yield return StartCoroutine("CountDownTimerRoutine");
    }

    IEnumerator CountDownTimerRoutine() {
        while (currentTime > 0) {
            currentTime -= Time.deltaTime;
            timeoutSlider.value = currentTime / timeLimit;
            yield return null;
        }

        GameOver(false);
    }

    // Update is called once per frame
    void FlipAllCards() {
        foreach (Card card in allCards) {
            card.FlipCard();
        }
    }

    public void CardClicked(Card card) {
        if (isFlipping) {
            return;
        }

        card.FlipCard();

        if (flippedCard == null) {
            flippedCard = card;
        } else {
            StartCoroutine(CheckMatchRoutine(flippedCard, card));
        }
    }

    IEnumerator CheckMatchRoutine(Card card1, Card card2) {
        isFlipping = true;

        if (card1.cardID == card2.cardID) {
            card1.SetMatched();
            card2.SetMatched();
        } else {
            yield return new WaitForSeconds(1f);

            card1.FlipCard();
            card2.FlipCard();

            yield return new WaitForSeconds(0.4f);
        }

        isFlipping = false;
        flippedCard = null;
    }

    void GameOver(bool isSuccess) {
        if (isSuccess) {

        } else {
            
        }
    }
}
