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
    public static float endLength;
    
    private int TotalNumberOfTiles;
    public int CurrZone;
    
    private void Start()
    {
        if (AlchemyValues.posX != 0)
        {
            GameObject.Find("ExplorationTargetGroup").transform.position = new Vector3(AlchemyValues.posX-2.3f, 0,-11);
        }
        NumberOfTilesPerZone = DayTime.maxDays * 12;
        endLength = 12+NumberOfTilesPerZone * 10 - 10;//todo regarder si le 10 est correct
        LastTilePos = 2; //6-4
        CurrZone = 1;
        Generate(CurrZone);
        
        //SFX
        ChangeMusic();

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
        RightBoundaryPos = transform.position.x + 9f;
        if (RightBoundaryPos >= LastTilePos)
        {
            CurrZone++;
            ChangeMusic();
            Generate(CurrZone);
        }
        AlchemyValues.posX = (int)RightBoundaryPos;
    }

    public void ChangeMusic()
    {

        switch (CurrZone)
        {
            
            case 1: 
                if (GameObject.Find("SoundManager").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/Forest")) GameObject.Find("SoundManager").GetComponent<SoundPlayer>().SetMusic(Resources.Load<AudioClip>("Music/Forest"));
                break;
            case 2: 
                if (GameObject.Find("SoundManager").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/Champ")) GameObject.Find("SoundManager").GetComponent<SoundPlayer>().SetMusic(Resources.Load<AudioClip>("Music/Champ"));
                break;
            case 3: 
                if (GameObject.Find("SoundManager").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/Desert")) GameObject.Find("SoundManager").GetComponent<SoundPlayer>().SetMusic(Resources.Load<AudioClip>("Music/Desert"));
                break;
            case 4: 
                if (GameObject.Find("SoundManager").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/Jungle")) GameObject.Find("SoundManager").GetComponent<SoundPlayer>().SetMusic(Resources.Load<AudioClip>("Music/Jungle"));
                break;
            case 5: 
                if (GameObject.Find("SoundManager").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/Roches")) GameObject.Find("SoundManager").GetComponent<SoundPlayer>().SetMusic(Resources.Load<AudioClip>("Music/Roches"));
                break;
            
        }
        
    }

    // Update is called once per frame
    void Generate(int zone)
    {    
        //Between Zones
        GameObject temp= Instantiate(TilePrefab, new Vector3(LastTilePos, 0, -0.2f),
            TilePrefab.transform.rotation);
        temp.AddComponent<Tile>();
        temp.transform.SetParent(ParentOfAllTiles.transform);
        temp.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0.5f); 
        
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
