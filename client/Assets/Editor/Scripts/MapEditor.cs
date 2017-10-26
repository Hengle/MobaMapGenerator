using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapEditor : Editor {

	[MenuItem("Map/NewMap")]
	static void GenerateMap()
	{
		GameObject mapGaneratorGo = new GameObject("MapGenerator");
		MapGenerator mapGenerator = mapGaneratorGo.AddComponent<MapGenerator>();
		mapGenerator.GenerateEmptyMap();
		Selection.activeGameObject = mapGaneratorGo;
	}

	[MenuItem("Map/LoadMap")]
	static void LoadMap()
	{

	}
		
	private bool _lockSelect = true;
	private MapBrush _mapBrush = new MapBrush();
	private MapGenerator _mapGenerator;

	void OnSceneGUI() 
	{
		_mapGenerator = target as MapGenerator;
		Handles.BeginGUI();
		//the rect to draw ui
		GUILayout.BeginArea(new Rect(20, 20, 150, 800));

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Ground"))
		{
			_mapBrush.SetBrushType(BrushType.Ground);
		}
		if(GUILayout.Button("Tree"))
		{
			_mapBrush.SetBrushType(BrushType.Tree);
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Wall"))
		{
			_mapBrush.SetBrushType(BrushType.Wall);
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Config"))
		{
			_mapBrush.ClearBrush();
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Save"))
		{
			_mapBrush.ClearBrush();
		}
		GUILayout.EndHorizontal();

		GUILayout.EndArea();
		Handles.EndGUI();

		LockSelectionInSceneView();
		BeginBrushMap();
	}

	void LockSelectionInSceneView()
	{
		Event e = Event.current;

		int controlID = GUIUtility.GetControlID( FocusType.Passive);

		if(_lockSelect && e.type == EventType.Layout)
		{
			HandleUtility.AddDefaultControl(controlID);
		}
	}

	void BeginBrushMap()
	{
		if(_mapBrush.curBrushType != BrushType.None)
		{
			if (Event.current.type == EventType.MouseDown   
				&& Event.current.button == 0)  
			{  
				RaycastHit hit;  
				Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);  
				if (Physics.Raycast(ray, out hit))  
				{  
					GameObject cell = hit.transform.gameObject;
					MapCell mapCell = cell.GetComponent<MapCell>();
					_mapGenerator.DrawMapWithBrush(_mapBrush,mapCell.coordinate);
				}  
			}  
		}
	}

}
