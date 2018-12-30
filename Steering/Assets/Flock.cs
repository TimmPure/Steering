using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    public GameObject agent;
    public GameObject[] flock;
    public int agentCount = 100;
    private float leftConstraint, rightConstraint, topConstraint, bottomConstraint;
   
	void Start () {
        flock = new GameObject[agentCount];
        
        for (int i = 0; i < flock.Length; i++)
        {
            GameObject obj = Instantiate(agent, this.transform.position, Quaternion.identity, this.transform) as GameObject;
            obj.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle*1000f);
            flock[i] = obj;
        }
	}
	
	void Update () {
		
	}
}
