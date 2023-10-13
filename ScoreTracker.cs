using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text team1ScoreText;
    public TMP_Text team2ScoreText;

    private int team1Score;
    private int team2Score;
    // Start is called before the first frame update
    void Start()
    {
        resetScoreBoard();
    }

    public void resetScoreBoard() {
        updateScoreBoard(1, 0);
        updateScoreBoard(2, 0);
    }

    public void updateScoreBoard(int team, int score) {
        if (team == 1) {
            team1ScoreText.text = score.ToString();
        }
        else if (team == 2) {
            team2ScoreText.text = score.ToString();
        }   
    }

}
