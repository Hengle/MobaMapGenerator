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

	private MapCell[,] _mapCellGo;
	//the position of top left corner is vector3(0,0,0)
	public void GenerateEmptyMap()
	{		
		_map = new Map();
		_map.InitMap(_mapWidth, _mapHeight);
		InitMapCell(_mapWidth,_mapHeight);
	}

	void InitMapCell(int width,int height)
	{
		_mapCellGo = new MapCell[width,height];
		GameObject gridCell = AssetDatabase.LoadAssetAtPath<GameObject>(GRID_CELL_PATH);
		float gridCellSize = _gridCellSize * 0.01f;
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				GameObject gridCellObj = GameObject.Instantiate(gridCell);
				MapCell mapCell = gridCellObj.AddComponent<MapCell>();
				mapCell.Init(i,j);
				_mapCellGo[i,j] = mapCell;
				gridCellObj.transform.position = new Vector3(gridCellSize * i,0,-gridCellSize * j);
				gridCellObj.transform.localScale = new Vector3(gridCellSize,gridCellSize,gridCellSize);
				gridCellObj.transform.SetParent(transform,false);
				RefreshMapCell(new Coordinate(i,j));
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
			RefreshMapCell(pos);
		}
		else
		{
			Debug.LogError("Invalid pos " + pos);
		}
	}

	void RefreshMapCell(Coordinate pos)
	{
		MapCellType mapCellTyp = _map.GetMapCellType(pos);
		_mapCellGo[pos.x,pos.y].SetMapCellType(mapCellTyp);

	}

}
