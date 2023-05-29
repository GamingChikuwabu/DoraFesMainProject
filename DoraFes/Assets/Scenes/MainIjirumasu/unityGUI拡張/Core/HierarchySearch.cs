using UnityEditor;
using UnityEngine;

public class HierarchySearch : EditorWindow
{
    private string filter;

    [MenuItem( "Tools/Example" )]
    private static void Init()
    {
        GetWindow<HierarchySearch>();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label( "Filter:", GUILayout.Width( 45 ) );
        GUI.SetNextControlName( "filterField" );
        filter = GUILayout.TextField( filter, "SearchTextField", GUILayout.Width( 120 ) );
        GUI.FocusControl( "filterField" );
        GUI.enabled = !string.IsNullOrEmpty( filter );
        if ( GUILayout.Button( "Clear", "SearchCancelButton" ) )
        {
            filter = string.Empty;
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();
    }
}