using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject menu, game, finish;
    [SerializeField] private Player player;

    private void Start()
    {
        ShowMenu();
        GameManager.Instance.OnStartedGame.AddListener(ShowGameUI);
        GameManager.Instance.OnFinishedGame.AddListener(ShowFinishUI);
    }

    private void ShowMenu()
    {
        menu.SetActive(true);
        game.SetActive(false);
        finish.SetActive(false);
    }

    private void ShowGameUI()
    {
        menu.SetActive(false);
        game.SetActive(true);
    }

    private void ShowFinishUI()
    {
        game.SetActive(false);
        finish.SetActive(true);
    }
}
