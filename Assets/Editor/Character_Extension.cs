using UnityEngine;
using UnityEditor;
using System.Collections;

 [CustomEditor(typeof(Character))] 
public class Character_Extension : Editor {

     public override void OnInspectorGUI()
     {
         Character character = (Character)target;
         if (GUILayout.Button("Recalc Attributes")) character.RecalcAttributes();


         base.OnInspectorGUI();
     }
}
