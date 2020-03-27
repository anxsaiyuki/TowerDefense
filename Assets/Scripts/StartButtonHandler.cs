using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonHandler : MonoBehaviour
{
  public void StartGame () {
    WaveSpawner.startGame = true;
  }
}
