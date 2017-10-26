using UnityEngine;
using System.Collections;

public class MapCell : MonoBehaviour 
{
	public Coordinate coordinate;

	private Material _material;

	public void Init(int x,int y)
	{
		coordinate = new Coordinate(x,y);
		_material = GetComponent<Renderer>().material;
	}		

	public void SetMapCellType(MapCellType mapCellType)
	{
		switch(mapCellType)
		{
		case MapCellType.Ground:
			_material.SetColor("_EmisColor",Color.white);
			break;
		case MapCellType.Tree:
			_material.SetColor("_EmisColor",Color.green);
			break;
		case MapCellType.Wall:
			_material.SetColor("_EmisColor",Color.gray);
			break;
		}
	}
}
