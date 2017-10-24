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

	void OnSceneGUI() 
	{

		Handles.BeginGUI();

		//the rect to draw ui
		GUILayout.BeginArea(new Rect(20, 20, 150, 800));

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Ground"))
			Debug.Log("test");
		if(GUILayout.Button("Tree"))
			Debug.Log("test");
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Wall"))
			Debug.Log("test");
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Config"))
			Debug.Log("test");
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Save"))
			Debug.Log("test");
		GUILayout.EndHorizontal();

		GUILayout.EndArea();
		Handles.EndGUI();
	}
}
