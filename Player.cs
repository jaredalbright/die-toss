using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject rightInteractor;
    public GameObject leftInteractor;
    public string team;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        rightInteractor.tag = name;
        leftInteractor.tag = name;
        Debug.Log(name);
    }

    public void tagDie() {
        Debug.Log("HIIII");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
