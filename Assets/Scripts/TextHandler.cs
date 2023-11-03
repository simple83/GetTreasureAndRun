using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{
    public TMP_Text tmpText;

    // Update is called once per frame
    void Update()
    {
        tmpText.text = "Score : " + GameManager.score + "\n" +
            "Life : " + GameManager.playerLife;
    }
}
