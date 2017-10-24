using UnityEngine;
using System.Collections;

public enum BrushType
{
	None,
	Ground,
	Tree,
	Wall
}

public class MapBrush
{
	private BrushType _curBrushType = BrushType.None;
	public BrushType curBrushType
	{
		get{return _curBrushType;}
	}


	public void SetBrushType(BrushType brushType)
	{
		_curBrushType = brushType;
	}

	public void ClearBrush()
	{
		_curBrushType = BrushType.None;
	}		
}
