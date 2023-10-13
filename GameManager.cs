using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    public Team team1;
    public Team team2;

    public string player1;

    public TableTrigger table1;
    public TableTrigger Table2;

    public DieTracker dietracker;

    public ScoreTracker scoreTracker;

    private int turn_counter;

    private Team offense;
    private Team defense;
    // Start is called before the first frame update
    void Start()
    {
        this.turn_counter = 0;
        changeTurn(this.team1, this.team2);
        this.team1.setTeamID(1);
        this.team2.setTeamID(2);
    }

    public DieTracker getDieTracker() {
        return this.dietracker;
    }

    public void iterateTurnCounter() {
        this.turn_counter++;
        Debug.Log("Iterate");
        if (turn_counter == 2) {
            // changeTurn(this.defense, this.offense);
            changeTurn(this.offense, this.defense);
        }
    }

    private void changeTurn(Team currTeam, Team oldTeam) {
        currTeam.startTurn();
        this.offense = currTeam;
        this.defense = oldTeam;
        this.turn_counter = 0;
    }

    public void checkPoint() {
        if (dietracker.checkForScore()) {
            Debug.Log("Point");
            int currScore = this.offense.iterateScore();

            //add end game logic
            this.scoreTracker.updateScoreBoard(this.offense.getTeamID(), currScore);
        }
        iterateTurnCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
