using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ShowRandomCard : MonoBehaviour
{
    public TextMeshProUGUI currentCardLabel;
    public UnityEvent drawCard;

    ShowRandomCardImpl _showRandomCardImpl;
    ShowRandomCardImpl ShowRandomCardImpl
    {
        get
        {
            if (_showRandomCardImpl == null)
                _showRandomCardImpl = new(new GameObjectWrapper(this.gameObject), new TextMeshProWrapper(currentCardLabel), new RandomWrapper(), () => drawCard?.Invoke());
            
            return _showRandomCardImpl;
        }
    }

    void Awake()
    {
        ShowRandomCardImpl.Awake();
    }

    void Start()
    {
        ShowRandomCardImpl.Start();
    }

    public void OnMouseDown()
    {
        ShowRandomCardImpl.OnMouseDown();
    }
}