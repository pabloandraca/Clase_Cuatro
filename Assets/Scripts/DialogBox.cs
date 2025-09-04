using TMPro;
using UnityEngine;
using System.Collections;

public class DialogBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] DialogLines dialogLines;
    [SerializeField] float textSpeed = 0.05f;

    int index;
    string currentLine;

    void OnEnable() => GameManager.OnGameStarted += StarDialog;
    void OnDisable()
    {
        GameManager.OnGameStarted -= StarDialog;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogText.text == currentLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogText.text = currentLine;
            }
        }
    }

    void StarDialog()
    {
        index = 0;
        currentLine = string.Empty;
        dialogText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        index = (index + 1) % dialogLines.lines.Length;
        dialogText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        currentLine = ReplaceTokens(dialogLines.lines[index]);

        foreach (char letra in currentLine.ToCharArray())
        {
            dialogText.text += letra;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    string ReplaceTokens(string line)
    {
        line = line.Replace("{PlayerName}", Capitalize(TokenManager.GetPlayerName()));
        line = line.Replace("{Place}", Capitalize(TokenManager.GetRandomPlace()));
        line = line.Replace("{Pokemon}", Capitalize(TokenManager.GetRandomPokemon()));
        line = line.Replace("{Item}", Capitalize(TokenManager.GetRandomItem()));
        line = line.Replace("{Medal}", Capitalize(TokenManager.GetRandomMedal()));
        return line;
    }

    string Capitalize(string line)
    {
        string[] words = line.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
        }

        return string.Join(" ", words);

    }
}