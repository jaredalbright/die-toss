using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTracker : MonoBehaviour
{
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
        this.wrongTableCheck = true;
        killActiveDie();
    }

    public void passTableCheck () {
        this.tableCheck = true;
        killActiveDie();
    }

    public void passHeightCheck () {
        Debug.Log("HEIGHT CHECK");
        this.heightCheck = true;
    }

    public void passGroundCheck () {
        this.groundCheck = true;
        killActiveDie();
    }

    public bool checkForScore () {
        if (this.tableCheck && this.heightCheck && this.groundCheck && !this.wrongTableCheck) {
            return true;
        }
        if (this.heightCheck == false) {
            skyTrigger.flashRed();
        }
        return false;
    }

    public void killActiveDie() {
        this.currentDie.activateDie();
    }

    public void resetDieTracker () {
        this.tableCheck = false;
        this.heightCheck = false;
        this.groundCheck = false;
        this.wrongTableCheck = false;
        StartCoroutine(destroyDie(this.currentDie));
        this.dieLock = false;
        this.currentDie = null;
    }

    private IEnumerator destroyDie (DieActions oldDie) {
        yield return new WaitForSeconds(1);
        Destroy(oldDie.gameObject);
    }

}
