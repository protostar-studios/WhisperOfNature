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
    public bool inbound = false;
    public float distanceThreshold;

    private AudioSource audioSource;
    


    void Start(){
        player = GameObject.FindGameObjectsWithTag("Player");
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        active = true;
        StartTrigger = GetComponent<BoxCollider>();
        startPosition = StartTrigger.transform.position;
        RendererArray = gameObject.GetComponentsInChildren<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void CheckNode(){
        if(CurrentNode < PathNode.Length -1)
        timer = 0;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
        startPosition = player[0].transform.position;
    }

    void ShowNodes(){
        // foreach (Renderer rend in RendererArray){
        //     rend.enabled=true;
        // }
        foreach (Transform child in transform){
            child.gameObject.SetActive(true);
        }
        audioSource.volume = 1.0f;
    }

    void HideNodes(){
        foreach (Transform child in transform){
            child.gameObject.SetActive(false);
        }
    }

    void Reset(){
        active = false;
        HideNodes();
        timer = 0;
        CurrentNode = 0;
        CurrentPositionHolder = PathNode[0].transform.position;
        startPosition = StartTrigger.transform.position;
        audioSource.volume = 0.0f;
    }

    void OnTriggerEnter(Collider other){
        inbound = true;
        if(other.gameObject.tag == "Player" && seasonManager.curSeason == 2){
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

            timer += Time.deltaTime * MoveSpeed;
            foreach(GameObject g in player){
                if(Vector3.Distance(g.transform.position, CurrentPositionHolder) > distanceThreshold){
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