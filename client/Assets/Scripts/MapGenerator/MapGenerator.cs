using UnityEngine;
using System.Collections;
using UnityEditor;

public class MapGenerator : MonoBehaviour 
{
	private int _mapWidth = 100;
	private int _mapHeight = 50;

	//grid size unit is mm
	private int _gridCellSize = 25;

	private const string GRID_CELL_PATH = "Assets/Editor/Prefabs/gridCell.prefab";

	void Awake()
	{
		GenerateEmptyMap();
	}

	//the position of top left corner is vector3(0,0,0)
	public void GenerateEmptyMap()
	{
		GameObject gridCell = AssetDatabase.LoadAssetAtPath<GameObject>(GRID_CELL_PATH);
		float gridCellSize = _gridCellSize * 0.01f;
		for(int i = 0; i < _mapWidth; i++)
		{
			for(int j = 0; j < _mapHeight; j++)
			{
				GameObject gridCellObj = GameObject.Instantiate(gridCell);
				gridCellObj.transform.position = new Vector3(gridCellSize * i,0,-gridCellSize * j);
				gridCellObj.transform.localScale = new Vector3(gridCellSize,gridCellSize,gridCellSize);
				gridCellObj.transform.SetParent(transform,false);
			}
		}	
	}

}
