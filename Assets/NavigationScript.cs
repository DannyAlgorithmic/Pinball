using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class NavigationScript : MonoBehaviour {

    public bool RandomWalking = true;
    [Range(1, 10)]
    public float RandomWalkTime = 1.0f;

    private NavMeshAgent agent;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Use this for initialization
    void Start () {
        if (RandomWalking == true)
        {
            Vector2 randPos = new Vector2(Random.Range(-6, 6), Random.Range(-6, 6));
            agent.SetDestination(randPos);

            StartCoroutine("RandomWalk");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator RandomWalk()
    {
        while (RandomWalking == true)
        {
            yield return new WaitForSeconds(RandomWalkTime);
            Vector2 randPos = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
            agent.SetDestination(randPos);
        }
    }
    
}
