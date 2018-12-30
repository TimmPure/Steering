using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public GameObject agentPrefab;
    public Agent[] flock;
    public int agentCount = 100;
    private float leftConstraint, rightConstraint, topConstraint, bottomConstraint;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        flock = new Agent[agentCount];

        for (int i = 0; i < flock.Length; i++)
        {

            GameObject obj = Instantiate(agentPrefab, cam.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 10f)), Quaternion.identity, this.transform) as GameObject;
            obj.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 1000f);
            flock[i] = obj.GetComponent<Agent>();
            if (flock[i] == null) { Debug.Log("Flock[i] is null"); }
        }
    }

    void Update()
    {

        //Loop through all agents in flock, and let them separate
        foreach (Agent other in flock)
        {
            other.transform.GetComponent<Rigidbody2D>().velocity += Separation(other);
            other.transform.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(other.transform.GetComponent<Rigidbody2D>().velocity, 15f);
        }
    }

    public Vector2 Separation(Agent other)         //Returns the desired velocity to be applied to agent in order to avoid neighbours
    {

        int count = 0;
        float perceptionRadius = 10f;

        Vector2 desiredVelocity = Vector2.zero;

        for (int i = 0; i < flock.Length; i++)
        {

            if (flock[i] != other && Mathf.Abs(flock[i].transform.position.x - other.transform.position.x) < perceptionRadius && Mathf.Abs(flock[i].transform.position.y - other.transform.position.y) < perceptionRadius)
            {
                //Agent other is within perception radius; we want a vector pointing away from it
                desiredVelocity += new Vector2(1 / (other.transform.position.x - flock[i].transform.position.x), 1 / (other.transform.position.y - flock[i].transform.position.y)) * 3f;
            }

            count++;
        }

        if (count > 0)
        {
            desiredVelocity = desiredVelocity / count;
        }

        return desiredVelocity;


    }
}
