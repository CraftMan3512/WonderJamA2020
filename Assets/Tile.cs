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
    public float rangeX;
    public int NumberOfSpots;

    private GameObject[] ItemsForet;
    private GameObject[] ItemsChamp;
    private GameObject[] ItemsDesert;
    private GameObject[] ItemsJungle;
    private GameObject[] ItemsRoche;
    private GameObject[][] AllMobs;

    private Vector3 top;
    private Vector3 bot;
    
    // Start is called before the first frame update
    void Start()
    {
        chanceMob = TileGenerator.ChanceMob;
        chanceRes = TileGenerator.ChanceRes;
        //INIT
        AllMobs =  new []{
            Resources.LoadAll<GameObject>("Prefabs/Mob/Foret"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Champ"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Desert"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Jungle"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Roche")
        };
        ItemsForet = Resources.LoadAll<GameObject>("Prefabs/Items/Foret");
        ItemsChamp = Resources.LoadAll<GameObject>("Prefabs/Items/Champ");
        ItemsDesert = Resources.LoadAll<GameObject>("Prefabs/Items/Desert");
        ItemsJungle = Resources.LoadAll<GameObject>("Prefabs/Items/Jungle");
        ItemsRoche = Resources.LoadAll<GameObject>("Prefabs/Items/Roche");
        
        
        
        
        //SpawnPoints
        top = transform.Find("Top").transform.position;
        bot = transform.Find("Bot").transform.position;
        for(int i =0;i<NumberOfSpots;i++)
        {
            if (chanceRes > Random.Range(1, 100))
            {
                Vector3 pos = (bot - top) * Random.Range(0.01f,1f)+top;
                pos.x += -rangeX + (Random.Range(0f, rangeX));
                pos.z = 0f;
                
                
                Instantiate(GetZoneItem(), pos, Quaternion.identity);
            }
            //TODO Mobs
            /*else if(chanceMob < Random.Range(1, 100))
            {
                Instantiate(GetZoneMob(), child.transform.position, Quaternion.identity);
            }*/
        }
    }

    private GameObject GetZoneItem()
    {
        GameObject result=Resources.Load<GameObject>("Prefabs/Items/Foret/diamant");
        switch (zone)
        {
            case 1: result = ItemsForet[Random.Range(0,ItemsForet.Length-1)];break;
            case 2: result = ItemsChamp[Random.Range(0,ItemsChamp.Length-1)];break;
            case 3: result = ItemsDesert[Random.Range(0,ItemsDesert.Length-1)];break;
            case 4: result = ItemsJungle[Random.Range(0,ItemsJungle.Length-1)];break;
            case 5: result = ItemsRoche[Random.Range(0,ItemsRoche.Length-1)];break;
        }
        return result;
    }

    private GameObject GetZoneMob()
    {
        return AllMobs[zone-1][Random.Range(0, AllMobs[zone].Length-1)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
