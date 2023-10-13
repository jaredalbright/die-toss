using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSettings : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        // transform.gameObject.tag = player.name;
        Debug.Log("Settings worked " + transform.gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
