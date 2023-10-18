using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProWrapper : IText
{
    TextMeshProUGUI tmpro;

    public string text { get => tmpro.text; set => tmpro.text = value; }
    public Color color { get => tmpro.color; set => tmpro.color = value; }

    public TextMeshProWrapper(TextMeshProUGUI tmpro)
    {
        this.tmpro = tmpro;
    }
}
