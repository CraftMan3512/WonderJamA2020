using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class TileGenerator : MonoBehaviour
{
    public GameObject TilePrefab;
    public GameObject ParentOfAllTiles;

    public static int ChanceRes=30;
    public static int ChanceMob=30;
    public int NumberOfTilesPerZone;
    public int RangeOfRandomnessOfTiles;
    public float RightBoundaryPos;
    public int LastTilePos;
    public static Sprite[] allZones;
    public static GameObject Mobs;
    public static GameObject Items;
    private bool GameNeedsSetup;
    
    private int TotalNumberOfTiles;
    public int CurrZone;
    
    private void Start()
    {
        if (AlchemyValues.posX != 0)
        {
            GameObject.Find("ExplorationTargetGroup").transform.position = new Vector3(AlchemyValues.posX-2.3f, 0,-11);
        }
        LastTilePos = 2; //6-4
        CurrZone = 1;
        Generate(CurrZone);
        

        //Get all zones


    }

    private void Awake()
    {
        allZones = new[]
        {
            Resources.Load<Sprite>("Sprites/Zones/foret"),
            Resources.Load<Sprite>("Sprites/Zones/champ"),
            Resources.Load<Sprite>("Sprites/Zones/desert"),
            Resources.Load<Sprite>("Sprites/Zones/jungle"),
            Resources.Load<Sprite>("Sprites/Zones/roche") 
        };
        Mobs = GameObject.Find("Mobs");
        Items = GameObject.Find("Items");
    }

    private void Update()
    {
        RightBoundaryPos = transform.position.x + 9f;
        if (RightBoundaryPos >= LastTilePos)
        {
            CurrZone++;
            Generate(CurrZone);
        }
        AlchemyValues.posX = (int)RightBoundaryPos;
    }

    // Update is called once per frame
    void Generate(int zone)
    {    
        
        
        int RealNOT = NumberOfTilesPerZone;
        for (int i = 0; i < RealNOT; i++)
        {
            GameObject tempTile = Instantiate(TilePrefab, new Vector3(LastTilePos + 2, 0, 0),
                TilePrefab.transform.rotation);
            tempTile.transform.SetParent(ParentOfAllTiles.transform);
            LastTilePos += 2;
        }
        //Between Zones
        GameObject temp= Instantiate(TilePrefab, new Vector3(LastTilePos, 0, -0.2f),
            TilePrefab.transform.rotation);
        Sprite temp3=allZones[0];
        switch (zone)
        {
            case 1:temp3=Resources.Load<Sprite>("Sprites/Zones/foretchamp");break;
            case 2:temp3=Resources.Load<Sprite>("Sprites/Zones/champdesert");break;
            case 3:temp3=Resources.Load<Sprite>("Sprites/Zones/desertjungle");break;
            case 4:temp3=Resources.Load<Sprite>("Sprites/Zones/jungleroche");break;
            default:Debug.Log("Too far my man ;)"); break;
        }
        temp.GetComponent<Tile>().setSprite(temp3);
        temp.transform.SetParent(ParentOfAllTiles.transform);
    }
}
