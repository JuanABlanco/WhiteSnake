using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject miranda;

    void Awake()
    {
        GameObject objeto = Instantiate(miranda, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
