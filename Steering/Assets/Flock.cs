using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    public GameObject agent;
    public GameObject[] flock;
    public int agentCount = 100;
    private float leftConstraint, rightConstraint, topConstraint, bottomConstraint;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        flock = new GameObject[agentCount];
        
        for (int i = 0; i < flock.Length; i++)
        {

            GameObject obj = Instantiate(agent, cam.ViewportToWorldPoint(new Vector3(Random.value,Random.value,10f)), Quaternion.identity, this.transform) as GameObject;
            obj.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle*1000f);
            flock[i] = obj;
        }
	}
	
	void Update () {
		
	}
}
