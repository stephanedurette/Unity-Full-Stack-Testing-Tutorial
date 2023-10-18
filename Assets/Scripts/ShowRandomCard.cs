using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ShowRandomCard : MonoBehaviour
{
    public TextMeshProUGUI currentCardLabel;
    public UnityEvent drawCard = new(); // We'll use this later

    static readonly System.Random rng = new();

    enum Suit
    {
        Spades, Hearts, Clubs, Diamonds
    }

    enum Rank
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack, Queen, King
    }

    // Select a random element from an enum.
    T RandomSelect<T>()
    {
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(rng.Next(values.Length));
    }

    Color SuitToColor(Suit suit)
    {
        switch (suit)
        {
            case Suit.Spades:
            case Suit.Clubs:
                return Color.black;
            case Suit.Hearts:
            case Suit.Diamonds:
                return Color.red;
            default:
                throw new InvalidOperationException($"Unknown suit: {suit}.");
        }
    }

    (string, Color) RandomCard()
    {
        Suit suit = RandomSelect<Suit>();
        Rank rank = RandomSelect<Rank>();
        return ($"{rank} of {suit}", SuitToColor(suit));
    }

    void Awake()
    {
        // Good defensive practice.
        if (currentCardLabel == null)
        {
            throw new MissingReferenceException(
                "Missing Current Card Label in Show Random Card on " +
                $"{this.name}.");
        }
    }

    void Start()
    {
        currentCardLabel.text = "";
    }

    public void OnMouseDown()
    {
        (currentCardLabel.text, currentCardLabel.color) = RandomCard();
        drawCard?.Invoke();
    }
}