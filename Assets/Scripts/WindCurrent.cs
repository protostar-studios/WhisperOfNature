using UnityEngine;
using System.Collections;


public class WindCurrent : MonoBehaviour{
    Node [] PathNode;
    public GameObject [] player;
    private SeasonManager seasonManager;
    int CurrentNode;
    static Vector3 CurrentPositionHolder;
    public float MoveSpeed;
    float timer;
    Vector3 startPosition;
    


    void Start(){
        player = GameObject.FindGameObjectsWithTag("Player");
        PathNode = GetComponentsInChildren<Node>();
        foreach(Node n in PathNode){
            Debug.Log(n.name);
        }
        CheckNode();
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        
    }

    void CheckNode(){
        if(CurrentNode < PathNode.Length -1)
        timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
        startPosition = player[0].transform.position;

    }

    void Update(){
        if (seasonManager.curSeason == 2){
            // Debug.Log("Fall!");
            timer += Time.deltaTime * MoveSpeed;
            foreach(GameObject g in player){
                if(g.transform.position != CurrentPositionHolder){
                    g.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, timer);
                }
                else{
                    if(CurrentNode < PathNode.Length - 1){
                        CurrentNode++;
                        CheckNode();
                    }
                }
            }
        }
    }
}