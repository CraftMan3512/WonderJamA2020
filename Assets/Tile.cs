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
    public GameObject ItemPrefab;

    private List<Item>[] AllItems=new List<Item>[5];
    private Enemy[][] AllMobs;

    private Vector3 top;
    private Vector3 bot;
    
    // Start is called before the first frame update
    void Start()
    {
        chanceMob = TileGenerator.ChanceMob;
        chanceRes = TileGenerator.ChanceRes;
        zone = GameObject.Find("ExplorationVCam").GetComponent<TileGenerator>().CurrZone;
        //INIT
        AllMobs =  new []{
            Resources.LoadAll<Enemy>("Prefabs/Mob/Foret"),
            Resources.LoadAll<Enemy>("Prefabs/Mob/Champ"),
            Resources.LoadAll<Enemy>("Prefabs/Mob/Desert"),
            Resources.LoadAll<Enemy>("Prefabs/Mob/Jungle"),
            Resources.LoadAll<Enemy>("Prefabs/Mob/Roche")
        };
        for (int i = 0; i < 5; i++)
        {
            AllItems[i]=new List<Item>();
        }
        for (int i = 0; i < AlchemyValues.materialPool.Length; i++)
        {
            Item toAdd = AlchemyValues.materialPool[i];
            AllItems[AlchemyValues.materialPool[i].getZone()-1].Add(toAdd);
        }
       
        
        
        
        
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
                
                
                GameObject temp = Instantiate(ItemPrefab, pos, Quaternion.identity);
                temp.transform.SetParent(transform.Find("Items"));
                temp.GetComponent<ItemCreator>().setItem(GetZoneItem());
            }
            //TODO Mobs
            /*else if(chanceMob < Random.Range(1, 100))
            {
                Instantiate(GetZoneMob(), child.transform.position, Quaternion.identity);
            }*/
        }
    }

    private Item GetZoneItem()
    {
        Item result=AllItems[zone-1][Random.Range(0,AllItems[zone-1].Count)];
        return result;
    }
    //TODO ZONEMOB
    /*private GameObject GetZoneMob()
    {
        return AllMobs[zone-1][Random.Range(0, AllMobs[zone].Length-1)];
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
