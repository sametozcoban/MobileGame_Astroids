using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
   [SerializeField] private GameObject _gameOverDisplay;
   [SerializeField] private Obstacle_Spawner _obstacleSpawner;
   [SerializeField] private ScoreSystem _scoreSystem;
   [SerializeField] private TMP_Text _gameDisplayText;

   private int finalScore;
   
   public void EndGame()
   {
      _obstacleSpawner.enabled = false;
      _scoreSystem.enabled = false;
      _gameOverDisplay.gameObject.SetActive(true);
       finalScore = _scoreSystem.scoreSystem();
       _gameDisplayText.text = $"Your Score :  {finalScore}";
   }
}
