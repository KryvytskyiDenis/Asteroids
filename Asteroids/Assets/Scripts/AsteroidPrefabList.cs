using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPrefabList : MonoBehaviour
{
    public enum AsteroidSize
    {
        Tiny, Small, Medium, Big
    }

    public List<GameObject> list = new List<GameObject>();
}
