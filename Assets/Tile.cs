using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Transform[] allChildren = GetComponentsInChildren<Transform>();
    List<GameObject> SpawnPoints = new List<GameObject>();
    //Spawn sets
    private int zone;  //1 foret, 2 champs, 3 desert, 4 jungle, 5 roche
    
    
    public Tile(int _zone,float chanceRes, float chanceMob)
    {
        zone = _zone;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in allChildren)
        {
            SpawnPoints.Add(child.gameObject);
            if (15 < Random.Range(0, 100))
            {
                
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
