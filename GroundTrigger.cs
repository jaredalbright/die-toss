using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnterEvent;
    
    private void OnTriggerEnter(Collider other) {
        OnEnterEvent.Invoke(other.gameObject);
    }
}
