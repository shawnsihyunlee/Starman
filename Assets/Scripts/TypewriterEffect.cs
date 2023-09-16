using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string fullText;
    public float typingSpeed = 0.05f;
    public int maxCharactersOnScreen = 100; // Maximum characters to show on screen
    public float clearDelay = 0.5f; // Delay to clear text after reaching the max characters

    private string currentText = "";
    private float timer = 0f;
    private int charactersToShow = 0;

    private int cutAmount = 20;
    private bool isTyping = false;

    private void Awake()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isTyping)
        {
            timer += Time.deltaTime;
            if (timer >= typingSpeed)
            {
                timer = 0f;

                if (charactersToShow < fullText.Length)
                {
                    currentText += fullText[charactersToShow];
                    textMeshPro.text = currentText;
                    charactersToShow++;
                    // Check if we've reached the maximum characters on screen
                    if (currentText.Length > maxCharactersOnScreen)
                    {
                        currentText = currentText.Substring(cutAmount);
                    }
                }
                else
                {
                    // Text is fully typed; wait for a certain duration and then clear it
                    StartCoroutine(ClearTextAfterDelay(2.0f)); // Adjust the delay as needed
                    isTyping = false;
                }
            }
        }
    }

    public void StartTypewriterEffect(string text)
    {
        fullText = text;
        currentText = "";
        charactersToShow = 0;
        isTyping = true;
    }

    private IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        textMeshPro.text = "";
        currentText = "";
    }

    public void StopTypewriterEffect()
    {
        isTyping = false;
        currentText = fullText;
        textMeshPro.text = currentText;
    }
}
