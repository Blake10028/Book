﻿using System.Collections;
using UnityEngine;
using TMPro;

public class TextPrinterPage6 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.10f; // Typing speed in seconds per character
    [SerializeField] private string defaultTextToType = "\"Rangiora, this is [playerName].”\r\n\"I'm helping them find their way home.\"\r\n\"I guess I can help,\" said Rangiora. \"I know some friends who can help us find your whānau, [playerName].\"\r\nAnd off they went to find [playerName]'s home.\r\n";

    private TMP_Text subtitleTextMesh;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        subtitleTextMesh = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        string playerName = GetPlayerName();
        string textToType = defaultTextToType.Replace("[playerName]", playerName);
        typingCoroutine = StartCoroutine(TypeTextCO(textToType));
    }

    private IEnumerator TypeTextCO(string textToType)
    {
        subtitleTextMesh.text = string.Empty;

        for (int i = 0; i < textToType.Length; i++)
        {
            subtitleTextMesh.text += textToType[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private string GetPlayerName()
    {
        if (DataManager.instance != null && DataManager.instance.inputField != null)
        {
            string playerName = DataManager.instance.inputField.text;
            if (!string.IsNullOrEmpty(playerName))
            {
                return playerName;
            }
        }
        return "Tūī"; // Default name if not found or input field is empty
    }
}