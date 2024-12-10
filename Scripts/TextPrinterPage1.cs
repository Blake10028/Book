using System.Collections;
using UnityEngine;
using TMPro;

public class TextPrinterPage1 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.10f; // Typing speed in seconds per character

    private string defaultTextToType = "Deep in a forest in Aotearoa, [playerName] sat beneath the trees and the ferns.\r\nA pair of eyes peeked through the leaves, and out popped a little Kawakawa. \r\n";
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
