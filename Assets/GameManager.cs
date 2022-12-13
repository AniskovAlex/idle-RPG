using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float worldSpeed;

    private void Start()
    {
        GlobaleStatus.SetSpeed(worldSpeed);
    }
}
