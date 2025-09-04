using TMPro;
using UnityEngine;

public class InputPlayerName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    public void ConfirmName()
    {
        string playerName = inputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogError("Player name cannot be empty.");
            return;
        }
        else if (playerName.Length > 10)
        {
            Debug.LogError("Player name is too long. Maximum 12 characters allowed.");
            return;
        }
        else if (!IsAllLetters(playerName))
        {
            Debug.LogError("Player name can only contain letters.");
            return;
        }

        TokenManager.SetPlayerName(playerName);
        Debug.Log($"Player name set to: {TokenManager.GetPlayerName()}");
        inputField.text = string.Empty;
    }

    bool IsAllLetters(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c)) return false;
        }
        return true;
    }
}