using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpriteSorter))]
public class SpriteSorterEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Sort Sprites", GUILayout.Height(64f)))
		{
			SpriteSorter sorter = (SpriteSorter)serializedObject.targetObject;
			sorter.SortSprites(false);
		}
	}
}
