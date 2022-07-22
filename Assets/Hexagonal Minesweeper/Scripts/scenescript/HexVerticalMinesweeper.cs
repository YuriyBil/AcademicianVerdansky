﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class HexVerticalMinesweeper : MonoBehaviour
{
    [SerializeField]
    private Transform _grid;
    [SerializeField]
    TestSaveGame pasd;
    [SerializeField]
    Player player;
    [SerializeField]
    AdventureGame adGame;
    [SerializeField]
    FightRoom fightRoom;
    //prefabs
    public GameObject hexCellPrefab;//the hex cell go with hexcell script
                                    //UI elements
    public GameObject questPanel;
    public GameObject fightPanel;
    public Text statusTxt;

    //User defined vars
    public Vector2 gridOffset;//position of the full grid
    public int numMines;//this value should not be higher than number of blank tiles
    public Sprite[] innerSprites;//reference to the sprites to be shown inside the cells. 0 is blank 7 is bomb
    public float scaleDownValue = 1;//scale value to scale down the hexagonal tile to fit screen
    public float timeToRegisterHold;//time to determine if a tap is a tap+hold

    //internal vars
    float sideLength;//this is the lendth of one side of the hexagon or the length of a corner to centre of the hexagon
    float hexTileHeight = 206;//actually the width of the hex tile graphic (distance between the pointy opposite corners)
    Vector2 levelDimensions;//grid size colum x row


    //global for optimisation
    Vector2 mouseOffsetPos;
    bool gameOver = false;
    int blankTiles;
    int revealedTiles = 0;//tracking blank tiles currently revealed
    Vector2 touchPosition;//for helping with hold detection
    float touchTime;//for helping with hold detection

    //horizontal tile shaped level can be directly used for horizontally aligned hex grid, for vertically aligned, need transposing
    int[][] levelData =
    {
        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0},
        // new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1}
// ------------------------------------------------------------
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},

        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,0,0,0,0,0,-1,-1,-1,-1},

        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},

        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},

        //  new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
//---------------------------------------------------------------
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},

       new int[] {-1,-1,-1,-1,0,0,0,0,0,0,-1,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},

        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},

        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,-1,-1,0,0,0,0,0,0,-1,-1,-1},

         new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
// -------------------------------------------------------
    };

    private int[][] _redlevelData =
   {
        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0},
        // new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
        // new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        // new int[] {-1,-1,0,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1}
// ------------------------------------------------------------
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},

        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,0,0,0,0,0,-1,-1,-1,-1},

        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},

        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},

        //  new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        // new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
//---------------------------------------------------------------
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},

        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},

        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
// -------------------------------------------------------
    };

    private int[][] _yellowlevelData =
{
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},

        new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},
        new int[] {-1,-1,-1,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},

        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,0,-1},

        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,-1,0,0,0,0,0,0,0,0,-1,-1},
        new int[] {-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1},

         new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
    };

    private int[][] _greenlevelData =
    {
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},

        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1,-1},

        new int[] {-1,-1,-1,0,0,0,0,0,-1,-1,-1,-1,-1},

        new int[] {-1,-1,0,0,0,0,0,0,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,0,0,0,0,0,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1,-1},

         new int[] {-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
    };

    //public GameObject hexGrid;

    void Start()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        ResetAllParams();
    }

    public void LoadFieldEasy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        DestroyOldField();
        ResetAllParams();
    }

    public void LoadFieldMiddle()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        DestroyOldField();
        ResetAllParams();
    }

    public void LoadFieldHard()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        DestroyOldField();
        ResetAllParams();
    }

    private void DestroyOldField()
    {
        foreach (Transform go in _grid)
        {
            Destroy(go.gameObject);
        }
    }


    void ResetAllParams()
    {
        //gets called at launch
        Camera.main.aspect = 1080.0f / 1920.0f;
        sideLength = (hexTileHeight / 2) * scaleDownValue;
        revealedTiles = 0;
        questPanel.SetActive(false);
        fightPanel.SetActive(false);//hide


        var difficulty = PlayerPrefs.GetInt("Difficulty");
        levelData = null;

        if (difficulty == 0)
        {
            levelData = _greenlevelData;
            gridOffset = new Vector2(-650f, -850f);
        }

        if (difficulty == 1)
        {
            levelData = _yellowlevelData;
            gridOffset = new Vector2(-550f, -900f);
        }

        if (difficulty == 2)
        {
            levelData = _redlevelData;
            gridOffset = new Vector2(-550f, -850f);
        }

        levelDimensions.x = levelData[0].Length;//column
        levelDimensions.y = levelData.Length;//row (we would transpose this array though)
        createGrid();//create the grid & add bubbles
        updateUI();//set UI values

        CreateSimplePrefab();

    }
    void createGrid()
    {
        levelData = transpose();
        addMines();//add mines first
                   //add hex cells
        GameObject hexTile;
        Vector2 axialPoint = new Vector2();
        Vector2 screenPoint = new Vector2();
        HexCell hc;
        blankTiles = 0;
        //loop through the rows & columns 
        for (var i = 0; i < levelDimensions.y; i++)
        {
            for (var j = 0; j < levelDimensions.x; j++)
            {
                if (levelData[i][j] != -1)
                {//not invalid tile
                    if (levelData[i][j] != 10)
                    {//not bomb
                        blankTiles++;
                    }
                    axialPoint.x = i;
                    axialPoint.y = j;
                    //convert offset points to axial points
                    axialPoint = HexHelperVertical.offsetToAxial(axialPoint);
                    //convert axial points to screen points
                    screenPoint = HexHelperVertical.axialToScreen(axialPoint, sideLength);
                    //add the grid offset value to position the grid
                    screenPoint.x += gridOffset.x;
                    screenPoint.y += gridOffset.y;
                    //place new hextile
                    hexTile = Instantiate(hexCellPrefab, screenPoint, Quaternion.identity) as GameObject;

                    hexTile.transform.SetParent(_grid);

                    //we will identify hextile by name
                    hexTile.name = "grid" + i.ToString() + "_" + j.ToString();
                    hexTile.transform.localScale = Vector2.one * scaleDownValue;//scale down to fit
                                                                                //hexTile.transform.localScale = Vector2.one * scaleDownValue;
                    hc = hexTile.GetComponent<HexCell>();
                    hc.setRandomBaseColor();
                    //store the converted axial coordinate inside the hexcell for easier reference
                    hc.axialCoordinate = axialPoint;
                    hc.setVertical();//we are dealing with vertically aligned hexagonal grid, so need to rotate
                                     //add to the list
                    if (levelData[i][j] == 10)
                    {//this is bomb
                        hc.innerSprite = innerSprites[7];
                        hc.setMine();
                    }
                    else
                    {//not bomb
                        hc.innerSprite = innerSprites[levelData[i][j]];
                    }
                }
            }
        }

    }
    void addMines()
    {
        int tileType = 0;
        List<Vector2> temp = new List<Vector2>();
        Vector2 newPt = new Vector2();
        for (var i = 0; i < levelDimensions.y; i++)
        {//loop through the level and collect all blank tiles
            for (var j = 0; j < levelDimensions.x; j++)
            {
                tileType = levelData[i][j];
                if (tileType == 0)
                {//blank tile
                    newPt = new Vector2();
                    newPt.x = i;
                    newPt.y = j;
                    temp.Add(newPt);
                }
            }
        }
        if (numMines >= temp.Count)
        {//mines cant be higher than available blank tiles, setting it to half blank tiles in wrong case
            numMines = (int)(temp.Count / 2);
        }
        for (var i = 0; i < numMines; i++)
        {
            int index = Random.Range(0, temp.Count);//set a random blank tile as bomb
            newPt = temp[index];
            temp.RemoveAt(index);
            levelData[(int)newPt.x][(int)newPt.y] = 10;//10 is mine
            updateNeighbors(newPt);//now once a new bomb is added we need to update the values with all neighbours
        }
    }

    void updateNeighbors(Vector2 offsetPoint)
    {//update neighbors around this mine in level data array
        var tileType = 0;
        Vector2 axialPoint = HexHelperVertical.offsetToAxial(offsetPoint);//convert to axial coordinate
        List<Vector2> neighbors = HexHelperVertical.getNeighbors(axialPoint);//get all neighbors for this one
        Vector2 tmpPt;
        for (var k = 0; k < neighbors.Count; k++)
        {
            tmpPt = HexHelperVertical.axialToOffset(neighbors[k]);//convert back to offset for array access
            if (validIndexes((int)tmpPt.x, (int)tmpPt.y) && validGridFreeArea((int)tmpPt.x, (int)tmpPt.y))
            {
                if (!validBombFreeArea((int)tmpPt.x, (int)tmpPt.y)) continue;
                tileType = levelData[(int)tmpPt.x][(int)tmpPt.y];
                levelData[(int)tmpPt.x][(int)tmpPt.y] = tileType + 1;////increment the value stored in the neighbor leveldata
            }
        }
    }


    void Update()
    {//gets called every frame
        if (gameOver) return;//stop game
        if (revealedTiles == blankTiles)
        {//when all valid blank tiles are found, show game over
            Debug.Log("All revealed");
            pasd.SavePlayerParams();
            SceneManager.LoadScene(1);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {//mouse down/tap down
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//store position and time
            touchTime = Time.timeSinceLevelLoad;
        }
        if (Input.GetMouseButtonUp(0))
        {//mouse release/tap up
            float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), touchPosition);
            float holdTime = Time.timeSinceLevelLoad - touchTime;
            if (distance < 10)
            {
                if (holdTime >= timeToRegisterHold)
                {
                    //this is a hold
                    markTheTile();//flag the tile
                }
                else
                {//this is a tap
                    checkAndReveal();//check the tile under tap & reveal if necessary
                }
            }
        }
    }
    void markTheTile()
    {
        GameObject tapped;
        //get offset coordinates of the cell under mouse position
        mouseOffsetPos = HexHelperVertical.axialToOffset(findCubicHexTile());
        if (!validIndexes((int)mouseOffsetPos.x, (int)mouseOffsetPos.y))
        {//end if we are outside the grid
            return;
        }
        if (levelData[(int)mouseOffsetPos.x][(int)mouseOffsetPos.y] != -1)
        {//not invalid area
            tapped = GameObject.Find("grid" + mouseOffsetPos.x.ToString() + "_" + mouseOffsetPos.y.ToString());
            HexCell hc = tapped.GetComponent<HexCell>();
            hc.markBase();//flag it
        }
    }
    void checkAndReveal()
    {
        GameObject tapped;
        //get offset coordinates of the cell under mouse position
        mouseOffsetPos = HexHelperVertical.axialToOffset(findCubicHexTile());
        if (!validIndexes((int)mouseOffsetPos.x, (int)mouseOffsetPos.y))
        {//end if we are outside the grid
            return;
        }
        if (levelData[(int)mouseOffsetPos.x][(int)mouseOffsetPos.y] != -1)
        {//not invalid area
            tapped = GameObject.Find("grid" + mouseOffsetPos.x.ToString() + "_" + mouseOffsetPos.y.ToString());
            HexCell hc = tapped.GetComponent<HexCell>();
            if (!hc.isRevealed)
            {//not yet revealed
                if (levelData[(int)mouseOffsetPos.x][(int)mouseOffsetPos.y] == 10)
                {//bomb
                    Debug.Log("bomb boom, game over");
                    hc.reveal();//reveal 

                    RandomEvent();
                    pasd.SavePlayerParams();
                }
                else if (levelData[(int)mouseOffsetPos.x][(int)mouseOffsetPos.y] == 0)
                {//blank tile with no mines near by, need recursive reveal
                    Debug.Log("connected reveal");
                    revealConnectedTiles(hc);//reveal connected tiles too
                }
                else
                {
                    revealedTiles++;//increment reveal count
                    hc.reveal();//reveal single
                }

            }
        }
        updateUI();//set UI values
    }

    private void RandomEvent()
    {
        int sd = Random.Range(1, 2 + 1);
        if (sd == 2)
        {
            adGame.Start();

            showExpeditionStop();
            Debug.Log("Quest");
        }

        if (sd == 1)
        {
            fightRoom.Start();

            showFight();
            Debug.Log("fightRoom");
        }




    }

    void revealConnectedTiles(HexCell hc)
    {
        //playSoundFx(popSnd);
        Vector2 axialPoint;
        Vector2 offsetPoint;
        GameObject neighborTile;
        HexCell neighborHC;
        List<Vector2> compareList = new List<Vector2>();//start a list of cells to compare
        compareList.Add(hc.axialCoordinate);//add first cell
        while (compareList.Count > 0)
        {//loop till we have no items in the compare list
            axialPoint = compareList[0];//take first element in the list
            List<Vector2> neighbors = HexHelperVertical.getNeighbors(axialPoint);//get all neighbors for this one
            while (neighbors.Count > 0)
            {//do this untill all neighbors are attended
                axialPoint = neighbors[0];//take first neighbor
                offsetPoint = HexHelperVertical.axialToOffset(axialPoint);//find the offset coordinate
                if (validIndexes((int)offsetPoint.x, (int)offsetPoint.y) && validGridFreeArea((int)offsetPoint.x, (int)offsetPoint.y) && validBombFreeArea((int)offsetPoint.x, (int)offsetPoint.y))
                {//end if the coordinate is outside our grid or nonusable grid area or bomb
                    neighborTile = GameObject.Find("grid" + offsetPoint.x.ToString() + "_" + offsetPoint.y.ToString());//find the hex tile by name
                    neighborHC = neighborTile.GetComponent<HexCell>();
                    if (!neighborHC.isRevealed)
                    {//if this cell is not yet revealed, proceed
                        revealedTiles++;
                        neighborHC.reveal();
                        if (levelData[(int)offsetPoint.x][(int)offsetPoint.y] == 0)
                        {//this one is also a no neighbor tile, so add
                            compareList.Add(neighborHC.axialCoordinate);//no we need to add it to compare list so that the process gets repeated on its neighbors
                        }
                    }
                }
                neighbors.Remove(axialPoint);//remove processed neighbor
            }
            axialPoint = compareList[0];//sometimes one cell without any neighbours gets through, catch it here, just in case
            offsetPoint = HexHelperVertical.axialToOffset(axialPoint);
            neighborTile = GameObject.Find("grid" + offsetPoint.x.ToString() + "_" + offsetPoint.y.ToString());
            neighborHC = neighborTile.GetComponent<HexCell>();
            if (!neighborHC.isRevealed)
            {//if this cell is not yet revealed, proceed
                revealedTiles++;
                neighborHC.reveal();
            }
            compareList.Remove(axialPoint);//remove the cell from compare list. process repeats
        }
    }
    Vector2 findCubicHexTile()
    {//find the cell under mouse/tap
        var pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);//convert mouse position to world position
        pos.x -= gridOffset.x;
        pos.y -= gridOffset.y;
        return HexHelperVertical.screenToAxial(pos, sideLength);//find axial coordinates
    }
    bool validGridFreeArea(int i, int j)
    {//check if the tile is outside effective area
        int tileType = levelData[i][j];
        if (tileType == -1)
        {
            return false;
        }
        return true;
    }
    bool validBombFreeArea(int i, int j)
    {//check if the tile is a mine
        int tileType = levelData[i][j];
        if (tileType == 10)
        {
            return false;
        }
        return true;
    }
    bool validIndexes(float iVal, float jVal)
    {//check if the index values are within grid dimensions
        if (iVal < 0 || jVal < 0 || iVal >= levelDimensions.y || jVal >= levelDimensions.x)
        {
            return false;
        }
        return true;
    }
    int[][] transpose()
    {//we swap rows & columns of the level array here as our static data is not for vertical layout.
        int[][] levelDataTranspose = new int[(int)levelDimensions.y][];
        for (var i = 0; i < levelDimensions.y; i++)
        {
            levelDataTranspose[i] = new int[(int)levelDimensions.x];
            for (var j = 0; j < levelDimensions.x; j++)
            {
                levelDataTranspose[i][j] = levelData[j][i];
            }
        }
        return levelDataTranspose;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0); //reload to restart
    }

    private void updateUI()
    {
        statusTxt.text = revealedTiles.ToString() + "/" + blankTiles.ToString();
    }
    public void ConinueGame()
    {

        questPanel.SetActive(false);
        gameOver = false;
    }
    private void showExpeditionStop()
    {
        questPanel.SetActive(true);
        gameOver = true;
    }
    private void showFight()
    {
        fightPanel.SetActive(true);
        gameOver = true;
    }
    public void HidenFight()
    {
        fightPanel.SetActive(false);
        gameOver = false;
    }

    public void LoadMainMenu()
    {
        PlayerPrefs.SetInt("FirstStart", 1);
        SceneManager.LoadScene("MainScreen");
    }

    void CreateSimplePrefab()
    {
        GameObject instance = Instantiate(_grid.gameObject);
        string localPath = "Assets/test_pref.prefab";
        // localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        PrefabUtility.SaveAsPrefabAssetAndConnect(instance, localPath, InteractionMode.UserAction);
    }
}
