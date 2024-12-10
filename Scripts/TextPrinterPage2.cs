using System.Collections;
using UnityEngine;
using TMPro;

public class TextPrinterPage2 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.10f; // Typing speed in seconds per character
    [SerializeField] private string defaultTextToType = "\"Are you alright?\" said the little Kawakawa.\r\n\"No,\" said the [playerName], \"I'm lost and can't find my way home.\" \r\nKawakawa gazed up at the child and reached out their little hand. \r\n\"I'll help you find your way home.\" said the Kawakawa.\r\nAnd off they went to find [playerName]'s home. \r\n";

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
