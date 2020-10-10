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

    public static int ChanceRes=15;
    public static int ChanceMob=20;
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
        LastTilePos = 4; //6-2
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
            Resources.Load<Sprite>("Sprites/Zones/foret") 
        };
        Mobs = GameObject.Find("Mobs");
        Items = GameObject.Find("Items");
    }

    private void Update()
    {
        RightBoundaryPos = transform.position.x + 4.5f;
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
            tempTile.AddComponent<Tile>();
            tempTile.transform.SetParent(ParentOfAllTiles.transform);
            LastTilePos += 2;
        }
    }
}
