using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public SpriteRenderer spriteRenderer;
    
    

    private List<Item>[] AllItems=new List<Item>[5];
    private GameObject[][] AllMobs;

    private Vector3 top;
    private Vector3 bot;
    
    // Start is called before the first frame update
    void Start()
    {
        
        chanceMob = TileGenerator.ChanceMob;
        chanceRes = TileGenerator.ChanceRes;
        zone = GameObject.Find("ExplorationVCam").GetComponent<TileGenerator>().CurrZone;
        //INIT
        AllMobs = new []
        {
            Resources.LoadAll<GameObject>("Prefabs/Mob/Foret"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Champ"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Desert"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Jungle"),
            Resources.LoadAll<GameObject>("Prefabs/Mob/Roche")
        };
        for (int i = 0; i < 5; i++)
        {
            AllItems[i]=new List<Item>();
        }
        for (int i = 0; i < AlchemyValues.materialPool.Length; i++)
        {
            Item toAdd = AlchemyValues.materialPool[i];
            if (toAdd.zone != 6)
            {
                AllItems[AlchemyValues.materialPool[i].getZone() - 1].Add(toAdd);
            }
        }
        
        //SpawnPoints
        top = transform.Find("Top").transform.position;
        bot = transform.Find("Bot").transform.position;
        Vector3 pos = (bot - top) * Random.Range(0.01f,1f)+top;
        pos.x += -rangeX + (Random.Range(0f, rangeX));
        pos.z = -1f;
        for(int i =0;i<NumberOfSpots;i++)
        {
            if (chanceRes > Random.Range(1, 100))
            {
                if (AllItems[zone - 1].Count > 0)
                {
                    GameObject temp = Instantiate(ItemPrefab, pos, Quaternion.identity);
                    temp.transform.SetParent(TileGenerator.Items.transform);
                    temp.GetComponent<ItemCreator>().setItem(GetZoneItem());
                }
            }
            else if(chanceMob > Random.Range(1, 100-chanceRes))
            {
                if (AllMobs[zone - 1].Length > 0)
                {
                    GameObject temp = Instantiate(GetZoneMob(), pos, Quaternion.identity);
                    temp.transform.SetParent(TileGenerator.Mobs.transform);
                }
            }
        }
        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = TileGenerator.allZones[zone-1];
    }
    

    private Item GetZoneItem()
    {
        Item result=AllItems[zone-1][Random.Range(0,AllItems[zone-1].Count)];
        return result;
    }

    public void setSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite=sprite;
    }

    private GameObject GetZoneMob()
    {
        if (AllMobs[zone - 1].Length != 0)
            return AllMobs[zone - 1][Random.Range(0, AllMobs[zone - 1].Length)];
        else
            return null;
    }
}

