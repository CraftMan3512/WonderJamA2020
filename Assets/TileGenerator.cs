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

    public static int ChanceRes= 10;
    public static int ChanceMob= 30;
    public static int ChanceMobDropRes = 25;
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

    private int counter;
    private bool generating = false;

    private AudioClip[] songs;
    private GameObject soundManager;
    private int spawnedTiles;
    public static GameObject EndTile;
    
    private void Start()
    {
        if (AlchemyValues.posX != 0)
        {
            GameObject.Find("ExplorationTargetGroup").transform.position = new Vector3(AlchemyValues.posX-2.3f, 0,-11);
        }
        endLength = 12+NumberOfTilesPerZone * 12 - 16;//todo regarder si le 10 est correct
        NumberOfTilesPerZone = DayTime.maxDays * 12;
        LastTilePos = 2; //6-4
        CurrZone = 1;
        Generate(CurrZone);
        soundManager = GameObject.Find("SoundManager");
        EndTile = Resources.Load<GameObject>("Sprites/Zones/EndTile");
        
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
            Resources.Load<Sprite>("Sprites/Zones/roche"),
        };
        Mobs = GameObject.Find("Mobs");
        Items = GameObject.Find("Items");

        songs = SoundPlayer.songs;

    }
    

    private void Update()
    {
        RightBoundaryPos = transform.position.x + 9f;
        if (RightBoundaryPos >= LastTilePos && !generating)
        {
            CurrZone++;
            ChangeMusic();
            Generate(CurrZone);
        }
        AlchemyValues.posX = (int)RightBoundaryPos;
        
        if (counter < NumberOfTilesPerZone && generating)
        {
            GameObject tempTile = Instantiate(TilePrefab, new Vector3(LastTilePos + 2, 0, 0),
                TilePrefab.transform.rotation);
            if ((CurrZone == 5 ||CurrZone==6)&& spawnedTiles % 2 == 0)
                tempTile.GetComponent<SpriteRenderer>().flipX = true;
            tempTile.transform.SetParent(ParentOfAllTiles.transform);
            LastTilePos += 2;
            counter++;
            spawnedTiles++;
        } else if(counter == NumberOfTilesPerZone)
        {
            generating = false;
            counter = 0;
        }
        
    }

    public void ChangeMusic()
    {

        switch (CurrZone)
        {
            
            case 1: 
                soundManager.GetComponent<SoundPlayer>().SetMusic(songs[0]);
                break;
            case 2: 
                soundManager.GetComponent<SoundPlayer>().SetMusic(songs[1]);
                break;
            case 3: 
                soundManager.GetComponent<SoundPlayer>().SetMusic(songs[2]);
                break;
            case 4: 
                soundManager.GetComponent<SoundPlayer>().SetMusic(songs[3]);
                break;
            case 5: 
                soundManager.GetComponent<SoundPlayer>().SetMusic(songs[4]);
                break;
            
        }
        
    }

    // Update is called once per frame
    void Generate(int zone)
    {

        generating = true;
        counter = 0;
        AlchemyValues.AddProgress(0);
        //Between Zones
        /*GameObject temp= Instantiate(TilePrefab, new Vector3(LastTilePos, 0, -0.2f),
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
        temp.transform.SetParent(ParentOfAllTiles.transform);*/

    }

}
