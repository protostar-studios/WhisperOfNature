using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    private float multiplyBy = 8f;
    // every 10 second randomly turn a direction 0-180 degrees
    private float turnTime = 2f;
    private float timeLeft;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            RunFrom();
            timeLeft = turnTime;
        }
    }

    public void RunFrom()
    {
        Transform startPos = transform;
        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        float randpos = Random.Range(0, 180);
        Debug.Log("random position: " + randpos);
        Vector3 eulers = new Vector3( 0, randpos, 0);
        transform.Rotate(eulers);
        //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
        // for this if you want variable results) and store it in a new Vector3 called runTo
        Vector3 runTo = transform.position + transform.forward * multiplyBy;
        //Debug.Log("runTo = " + runTo);
        //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.
        NavMeshHit hit;    // stores the output in a variable called hit
        // 5 is the distance to check, assumes you use default for the NavMesh Layer name
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetNavMeshLayerFromName("Default"));
        transform.position = startPos.position;
        transform.rotation = startPos.rotation;
        agent.SetDestination(hit.position);
    }
}
