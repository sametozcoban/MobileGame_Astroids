using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
   Scene_Control _gameOver;
   [SerializeField] public GameOverHandler _gameOverHandler;

   bool gameOver;
   public void Crash()
   {
      gameOver = true;
      gameObject.SetActive(false);
      _gameOverHandler.EndGame();
   }
}
   