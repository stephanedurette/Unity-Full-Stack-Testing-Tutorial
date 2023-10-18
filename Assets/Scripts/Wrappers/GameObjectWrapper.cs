using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectWrapper : IGameObject
{
    GameObject gameObject;
    public string name { get => gameObject.name; set => gameObject.name = value; }

    public GameObjectWrapper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
}
