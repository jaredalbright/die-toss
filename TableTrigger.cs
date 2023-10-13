using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

public class TableTrigger : MonoBehaviour
{   
    public Material targetMaterial; 
    public Material missMaterial;
    public string targetTag;
    public string missTag;
    public UnityEvent<GameObject> OnEnterEventTrue;

    private bool changeLock;

    public UnityEvent<GameObject> OnEnterEventFalse;

    private Renderer visual;

    void Start() {
        this.visual = this.gameObject.GetComponent<Renderer>();
        this.visual.enabled = false;
        changeLock = false;
    }
    private void OnTriggerEnter(Collider other) {
        Material currMaterial = this.visual.material;
        if (other.gameObject.tag == targetTag)
        {
            StartCoroutine(changeColor(targetMaterial, currMaterial));
            OnEnterEventTrue.Invoke(other.gameObject);
        }
        if (other.gameObject.tag == missTag)
        {
            StartCoroutine(changeColor(missMaterial, currMaterial));
            OnEnterEventFalse.Invoke(other.gameObject);
        }
    }

    private void onTriggerExit(Collider other) {
        
    }

    private IEnumerator changeColor(Material newM, Material oldM) {
        if (!changeLock) {
            changeLock = true;
            this.visual.material = newM;
            this.visual.enabled = true;
            yield return new WaitForSeconds(2);
            this.visual.enabled = false;
            this.visual.material = oldM;
            changeLock = false;
        }
    }
}
