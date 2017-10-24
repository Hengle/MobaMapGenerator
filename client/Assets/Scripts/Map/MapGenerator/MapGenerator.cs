using UnityEngine;
using System.Collections;
using UnityEditor;

public class MapGenerator : MonoBehaviour 
{
	private int _mapWidth = 100;
	private int _mapHeight = 50;

	//grid size unit is mm
	private int _gridCellSize = 25;

	private Map _map;
		
	private const string GRID_CELL_PATH = "Assets/Editor/Prefabs/gridCell.prefab";

	//the position of top left corner is vector3(0,0,0)
	public void GenerateEmptyMap()
	{		
		_map = new Map();
		_map.InitMap(_mapWidth, _mapHeight);
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

	bool CheckPosValid(Coordinate pos)
	{
		if(pos.x >= 0 && pos.x < _mapWidth)
		{
			if(pos.y >= 0 && pos.y < _mapHeight)
			{
				return true;
			}
		}
		return false;
	}

	MapCellType ConvertBrushTypeToMapCellType(BrushType brushType)
	{
		switch(brushType)
		{
		case BrushType.Ground:
			return MapCellType.Ground;
		case BrushType.Tree:
			return MapCellType.Tree;
		case BrushType.Wall:
			return MapCellType.Wall;
		}
		return MapCellType.Ground;
	}

	public void DrawMapWithBrush(MapBrush brush,Coordinate pos)
	{
		if(CheckPosValid(pos))
		{
			_map.SetMapCell(pos,ConvertBrushTypeToMapCellType(brush.curBrushType));
		}
		else
		{
			Debug.LogError("Invalid pos " + pos);
		}
	}

}
