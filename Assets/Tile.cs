using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Transform[] allChildren;
    List<GameObject> SpawnPoints = new List<GameObject>();
    //Spawn sets
    private int zone;  //1 foret, 2 champs, 3 desert, 4 jungle, 5 roche
    private float chanceRes, chanceMob;
    private GameObject RessourceDrop;
    
    public Tile(int _zone,float _chanceRes, float _chanceMob)
    {
        zone = _zone;
        chanceRes = _chanceRes;
        chanceMob = _chanceMob;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            SpawnPoints.Add(child.gameObject);
            if (chanceRes < Random.Range(1, 100))
            {
               
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
