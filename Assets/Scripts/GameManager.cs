using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStarted;
    public static event Action<int, int> OnPaused;

    void OnEnable()
    {
        OnPaused += Pause;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnGameStarted.Invoke();
        }
    }


    void Pause(int i, int j)
    {
        Debug.Log("Game Paused");
    }
}