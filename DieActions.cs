using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DieActions : MonoBehaviour
{
    public GameManager gameManager;
    private DieTracker dietracker;
    private bool active;

    private Vector3 startPos;

    private Vector3 throwPos;

    private bool holds_lock;
    private string team;

    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.gameObject.transform.position;
        this.holds_lock = false;
        this.dietracker = gameManager.getDieTracker();
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(activate);
        grabInteractable.selectExited.AddListener(startThrow);
    }

    public void activate(SelectEnterEventArgs args) {
        // change to use player tag and then get team tag via gamemanager
        this.team = args.interactorObject.transform.tag;
        // Only one person can throw at a time
        if (this.dietracker.getLock(this) == false) {
            this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            this.gameObject.transform.position = this.startPos;
            this.gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        } 
        else {
            this.holds_lock = true;
        }
    }

    // reduces logic inside of update and activates the die incase it is caught
    public void startThrow(SelectExitEventArgs args) {
        if (this.holds_lock) {
            this.gameObject.tag = this.team;
            //this.active = true;
            this.throwPos = this.gameObject.transform.position;
        }
    }

    public void activateDie() {
        this.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.active) {
            float speed = this.GetComponent<Rigidbody>().velocity.magnitude;
            
            if (speed == 0) {
                this.active = false;
                Debug.Log("Speed 0");
                this.gameManager.checkPoint();
                this.dietracker.resetDieTracker();
            }
        }
    }
}
