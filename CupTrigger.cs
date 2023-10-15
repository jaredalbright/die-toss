using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupTrigger : MonoBehaviour
{

    public UnityEvent<GameObject> OnEnterEventTrue;
    public UnityEvent<GameObject> OnEnterEventFalse;
    public string targetTag;
    public string missTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == targetTag)
        {
            OnEnterEventTrue.Invoke(other.gameObject);
        }
        if (other.gameObject.tag == missTag)
        {
            OnEnterEventFalse.Invoke(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
