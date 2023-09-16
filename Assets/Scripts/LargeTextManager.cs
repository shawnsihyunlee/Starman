using UnityEngine;
using TMPro;
using System.Collections;
using System.IO;

public class LargeTextManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public TypewriterEffect typewriterEffect;
    public string largeTextFilePath = "large_text.txt";
    public float typewriterSpeed = 10f; // Characters per second

    private string[] textLines;
    private int currentLineIndex = 0;

    private void Start()
    {
        // Load the large text file
        LoadLargeTextFile();

        // Start displaying the text with typewriter effect
        StartCoroutine(DisplayLargeText());
    }

    private void LoadLargeTextFile()
    {
        // Load the text file and split it into lines
        string fullPath = Path.Combine(Application.streamingAssetsPath, largeTextFilePath);

        if (File.Exists(fullPath))
        {
            textLines = File.ReadAllLines(fullPath);
        }
        else
        {
            Debug.LogError("Large text file not found: " + fullPath);
        }
    }

    private IEnumerator DisplayLargeText()
    {
        while (currentLineIndex < textLines.Length)
        {
            string currentLine = textLines[currentLineIndex];
            typewriterEffect.StartTypewriterEffect(currentLine);
            currentLineIndex++;

            yield return new WaitForSeconds(currentLine.Length / typewriterSpeed);
            typewriterEffect.StopTypewriterEffect();

            // Optionally, you can wait for player input to continue reading.
            // For example, wait for a key press or tap:
            // yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        // All lines have been displayed
        // You can implement logic here to handle what happens next
    }
}
