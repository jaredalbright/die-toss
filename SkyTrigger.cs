using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkyTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnterEvent;
    
    private void OnTriggerEnter(Collider other) {
        OnEnterEvent.Invoke(other.gameObject);
    }

    public void flashRed() {
        Debug.Log("SUCK");
        StartCoroutine(changeColor());
    }

    private IEnumerator changeColor() {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
