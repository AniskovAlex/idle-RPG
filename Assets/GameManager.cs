using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float worldSpeed;

    private void Awake()
    {
        GlobaleStatus.SetSpeed(worldSpeed);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
