using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPrinterPage15 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.10f; // Typing speed in seconds per character
    [SerializeField] private string defaultTextToType = "“Wakeup Kauri!” shouted Kawakawa.\r\n“I know you,” says Kauri. “I see\r\nYour home across the river, and you\r\nPlaying outside with your whānau.”\r\n“Will you help me cross this river to \r\nHelp me home?” asked Tūī.\r\n";

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
