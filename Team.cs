using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    private DieTracker dieTracker;
    public GameManager gameManager;

    public GameObject leftSpawn;

    public GameObject rightSpawn;

    public GameObject die;

    public int score;

    public string teamName;

    private int teamID;
    // Start is called before the first frame update
    void Start()
    {
        this.dieTracker = gameManager.getDieTracker();
    }

    public void setTeamID(int id) {
        this.teamID = id;
    }

    public int getTeamID() {
        return this.teamID;
    }

    // Contains logic for instatiating turn
    public void startTurn() {
        GameObject RightDie = Instantiate(die, this.rightSpawn.transform.position, this.rightSpawn.transform.rotation);
        GameObject LeftDie = Instantiate(die, this.leftSpawn.transform.position, this.leftSpawn.transform.rotation);
        RightDie.GetComponent<DieActions>().gameManager = this.gameManager;
        LeftDie.GetComponent<DieActions>().gameManager = this.gameManager;
    }

    public int iterateScore(int val) {
        this.score += val;
        return this.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
