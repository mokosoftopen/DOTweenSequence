using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

[CustomEditor(typeof(DOTweenSequence))]
public class DOTweenSequenceInspector : Editor {

	DOTweenSequence _src;
	bool showPosition = true;
	string status = "select";

	void OnEnable()
	{
		_src = target as DOTweenSequence;
	}

	public override void OnInspectorGUI()
	{
		

		EditorGUILayout.LabelField( "DOTween Sequence" );

		int i = 0;
		foreach ( DOTweenAnimation d in _src.animes ) {

			//showPosition = EditorGUILayout.Foldout(showPosition, status);
			//if(showPosition)
			//{
				//EditorGUI.indentLevel++;

				EditorGUILayout.BeginHorizontal();
				
				GUILayout.Label("[" + (i+1) + "]");

				_src.animes[i] = (DOTweenAnimation)EditorGUILayout.ObjectField(d, typeof(DOTweenAnimation), true);
				GUILayout.Label(d.animationType.ToString() + (string.IsNullOrEmpty(d.id) ? "" : " [" + d.id + "]"));
				//d._method = (MoveProgramData.MoveProgramData_Method)EditorGUILayout.EnumPopup("method", d._method);
				//d.delay_time = EditorGUILayout.FloatField("delay_time", d.delay_time);
				//d.target_pos = EditorGUILayout.Vector3Field("target_pos", d.target_pos);

				
				if(GUILayout.Button("↑",EditorStyles.miniButton)){

					if ( i > 0 ) {

						var c = _src.animes[i-1];
						_src.animes[i-1] = _src.animes[i];
						_src.animes[i] = c;

					}


				}
				if(GUILayout.Button("↓",EditorStyles.miniButton)){

					if ( i < _src.animes.Length - 1 ) {

						var c = _src.animes[i+1];
						_src.animes[i+1] = _src.animes[i];
						_src.animes[i] = c;

					}

				}
				if(GUILayout.Button("×",EditorStyles.miniButton)){

					DOTweenAnimation[] c = new DOTweenAnimation[_src.animes.Length];
					_src.animes.CopyTo(c, 0);

					Debug.Log("line = "+i);

					int len = _src.animes.Length - 1;
					System.Array.Resize(ref _src.animes, len);

					for ( int j = 0; j < i; j++ ) {
						Debug.Log("copy " + j + " to " + j);
						_src.animes[j] = c[j];
					}
					for ( int j = i+1; j < c.Length; j++ ) {
						Debug.Log("copy " + j + " to " + (j-1));
						_src.animes[j-1] = c[j];
					}


				}
				EditorGUILayout.EndHorizontal();


				//EditorGUI.indentLevel--;

			//}


			i++;

		}

		if(GUILayout.Button("Add"))
			{

			int len = _src.animes.Length + 1;
			System.Array.Resize(ref _src.animes, len);

		}


	}

}
