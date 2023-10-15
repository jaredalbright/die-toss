using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTracker : MonoBehaviour
{
    private bool cupCheck;
    private bool wrongCupCheck;
    private bool heightCheck;
    private bool tableCheck;
    private bool dieLock;
    private bool wrongTableCheck;
    private bool groundCheck;
    private DieActions currentDie;

    public SkyTrigger skyTrigger;

    // Start is called before the first frame update
    void Start()
    {
        this.cupCheck = false;
        this.heightCheck = false;
        this.tableCheck = false;
        this.dieLock = false;
        this.wrongTableCheck = false;
    }
    public bool getLock(DieActions newDie) {
        if (this.dieLock) {
            return false;
        }
        this.dieLock = true;
        this.currentDie = newDie;
        return true;
    }

    public void wrongTable () {
        // Only if you hit the wrong side of the table first
        if (!this.tableCheck) {
            this.wrongTableCheck = true;
            killActiveDie();
        }
    }

    public void passTableCheck () {
        this.tableCheck = true;
        killActiveDie();
    }
    // The only check that won't kill the die because we don't want it stopping at the 
    // the vertex
    public void passHeightCheck () {
        this.heightCheck = true;
    }

    public void passGroundCheck () {
        this.groundCheck = true;
        killActiveDie();
    }

    public void passCupCheck () {
        this.cupCheck = true;
        killActiveDie();
    }
    
    public void wrongCup () {
        this.wrongCupCheck = true;
        killActiveDie();
    }

    public int checkForScore () {
        if (this.wrongCupCheck) {
            return -3;
        }
        if (this.heightCheck && !this.wrongTableCheck) {
            if (this.cupCheck) {
                return 3;
            }
            if (this.tableCheck && this.groundCheck) {
                return 1;
            }
        }
        if (this.heightCheck == false) {
            skyTrigger.flashRed();
        }
        return 0;
    }

    public void killActiveDie() {
        this.currentDie.activateDie();
    }

    public void resetDieTracker () {
        this.tableCheck = false;
        this.heightCheck = false;
        this.groundCheck = false;
        this.cupCheck = false;
        this.wrongTableCheck = false;
        this.wrongCupCheck = false;
        StartCoroutine(destroyDie(this.currentDie));
        this.dieLock = false;
        this.currentDie = null;
    }

    private IEnumerator destroyDie (DieActions oldDie) {
        yield return new WaitForSeconds(1);
        Destroy(oldDie.gameObject);
    }

}
