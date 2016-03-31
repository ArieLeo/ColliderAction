// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the ColliderAction extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace ColliderActionEx {

    [CustomEditor(typeof(ColliderAction))]
    [CanEditMultipleObjects]
    public sealed class ColliderActionEditor : Editor {
        #region FIELDS

        private ColliderAction Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty callbacks;
        private SerializedProperty triggerType;
        private SerializedProperty layerMask;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawTriggerTypeDropdown();
            DrawLayerMaskDropdown();

            EditorGUILayout.Space();
            
            DrawCallbacksList();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (ColliderAction)target;

            description = serializedObject.FindProperty("description");
            callbacks = serializedObject.FindProperty("callbacks");
            triggerType = serializedObject.FindProperty("triggerType");
            layerMask = serializedObject.FindProperty("layerMask");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawLayerMaskDropdown() {
            EditorGUILayout.PropertyField(
                layerMask,
                new GUIContent(
                    "Layer Mask",
                    "Specify layers used to detect triggers."));
        }

        private void DrawTriggerTypeDropdown() {
            EditorGUILayout.PropertyField(
                triggerType,
                new GUIContent(
                    "Trigger Type",
                    "Trigger that will cause the callbacks execution."));
        }

        private void DrawCallbacksList() {
            EditorGUILayout.PropertyField(
                callbacks,
                new GUIContent(
                    "Callbacks",
                    ""));
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    ColliderAction.Version,
                    ColliderAction.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Component Framework/ColliderAction")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(ColliderAction));
            }
        }

        #endregion METHODS
    }

}