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
    bool active;
    BoxCollider StartTrigger;

    Renderer[] RendererArray;
    


    void Start(){
        player = GameObject.FindGameObjectsWithTag("Player");
        PathNode = GetComponentsInChildren<Node>();
        // foreach(Node n in PathNode){
        //     Debug.Log(n.name);
        // }
        CheckNode();
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        active = true;
        StartTrigger = GetComponent<BoxCollider>();
        StartTrigger.transform.position = PathNode[0].transform.position;       
        // Debug.Log(StartTrigger.transform.position);
        // Debug.Log(PathNode[0].transform.position);
        startPosition = StartTrigger.transform.position;
        RendererArray = gameObject.GetComponentsInChildren<Renderer>();
    }

    void CheckNode(){
        if(CurrentNode < PathNode.Length -1)
        timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
        startPosition = player[0].transform.position;
    }

    void ShowNodes(){
        foreach (Renderer rend in RendererArray){
            rend.enabled=true;
        }
    }

    void HideNodes(){
        foreach (Renderer rend in RendererArray){
            rend.enabled=false;
        }
    }

    void Reset(){
        active = false;
        HideNodes();
        timer = 0;
        CurrentNode = 0;
        startPosition = StartTrigger.transform.position;
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player" && seasonManager.curSeason == 2){
            // Debug.Log("Let's Go!");
            active = true;
        }
    }

    void Update(){
        if (seasonManager.curSeason != 2){
            Reset();
        }
        if (seasonManager.curSeason == 2){
            ShowNodes();
        }   
        if (seasonManager.curSeason == 2 && active){
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
                    else if(CurrentNode == PathNode.Length-1){
                        Reset();
                    }
                }
            }
        }
    }
}