using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public GameManager gameManager;

    public void ShowHud()
    {
        gameObject.SetActive(true);
    }

    public void HideHud()
    {
        gameObject.SetActive(false);
    }
}
