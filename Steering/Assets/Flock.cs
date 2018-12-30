using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    public GameObject agent;
    public GameObject[] flock;
    public int agentCount = 100;

	// Use this for initialization
	void Start () {
        flock = new GameObject[agentCount];

        for (int i = 0; i < flock.Length; i++)
        {
            GameObject obj = Instantiate(agent, this.transform.position, Quaternion.identity) as GameObject;
            obj.transform.parent = this.transform;
            obj.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle*1000f);
            flock[i] = obj;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
