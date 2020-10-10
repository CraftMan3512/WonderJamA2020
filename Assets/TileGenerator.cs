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
    
    private int TotalNumberOfTiles;
    public int CurrZone;
    
    private void Start()
    {
        LastTilePos = 4; //6-2
        Generate(1);
        CurrZone = 1;
    }

    private void Update()
    {
        RightBoundaryPos = transform.position.x + 4.5f;
        if (RightBoundaryPos - 4 >= LastTilePos)
        {
            Generate(CurrZone);
            CurrZone++;
        }
    }

    // Update is called once per frame
    void Generate(int zone)
    {
        int RealNOT = NumberOfTilesPerZone+Random.Range(0,RangeOfRandomnessOfTiles);
        for (int i = 0; i < RealNOT; i++)
        {
            GameObject tempTile = Instantiate(TilePrefab, new Vector3(LastTilePos+2,0,0),TilePrefab.transform.rotation);
            tempTile.AddComponent<Tile>();
            tempTile.transform.SetParent(ParentOfAllTiles.transform);
            LastTilePos += 2;
        }
    }
}
