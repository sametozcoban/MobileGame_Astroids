using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField ]private TMP_Text _text;
    [SerializeField] private float ScoreMultiple;

    private float score;

    private bool _scoreActive = true;
    // Update is called once per frame
    void Update()
    {
        if(!_scoreActive){return;}
        scoreSystem();
        score += Time.deltaTime * ScoreMultiple;
        _text.text = Mathf.FloorToInt(score).ToString();
    }

    public int scoreSystem()
    {
        _scoreActive = true;

        int scorer = Mathf.FloorToInt(score);
        return scorer;
    }
}
