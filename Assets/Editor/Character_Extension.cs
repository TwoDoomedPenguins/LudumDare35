using UnityEngine;
using UnityEditor;
using System.Collections;

 [CustomEditor(typeof(Character))] 
public class Character_Extension : Editor {

     public override void OnInspectorGUI()
     {
         Character character = (Character)target;
         GUILayout.BeginHorizontal();
         if (GUILayout.Button("Recalc Attributes")) character.RecalcAttributes();
         if (GUILayout.Button("Create Random Attack")) character.createRandomAttackSequence();
         GUILayout.EndHorizontal();

         base.OnInspectorGUI();
     }
}
