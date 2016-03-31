// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the ColliderAction extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;

namespace ColliderActionEx {

    /// <summary>
    /// Allows execute callbacks on collider event like OnCollisionEnter()
    /// or OnTriggerEnter().
    /// </summary>
    public sealed class ColliderAction : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "ColliderAction";

        #endregion CONSTANTS

        #region DELEGATES
        #endregion DELEGATES

        #region EVENTS
        #endregion EVENTS

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "ColliderAction";
#pragma warning restore 0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private CallbackUnityEvent callbacks;

        [SerializeField]
        private TriggerType triggerType;

        [SerializeField]
        private LayerMask layerMask;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Callbacks executed on trigger or collision event.
        /// </summary>
        public CallbackUnityEvent Callbacks {
            get { return callbacks; }
            set { callbacks = value; }
        }

        /// <summary>
        /// What should trigger callbacks.
        /// </summary>
        public TriggerType TriggerType {
            get { return triggerType; }
            set { triggerType = value; }
        }

        /// <summary>
        /// Triggers will be detected only for specified layers.
        /// </summary>
        public LayerMask LayerMask {
            get { return layerMask; }
            set { layerMask = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() { }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() { }

        private void Update() { }

        private void OnValidate() { }

        private void OnDisable() { }

        private void OnDestroy() { }

        private void OnTriggerEnter(Collider collisionInfo) {
            // Check trigger type.
            if (TriggerType != TriggerType.OnTriggerEnter) return;
            // Check layer mask.
            if (!Utilities.IsInLayerMask(collisionInfo.gameObject, LayerMask)) {
                return;
            }

            Callbacks.Invoke(collisionInfo.gameObject);
        }

        private void OnCollisionEnter(Collision collisionInfo) {
            // Check trigger type.
            if (TriggerType != TriggerType.OnCollisionEnter) return;
            // Check layer mask.
            if (!Utilities.IsInLayerMask(collisionInfo.gameObject, LayerMask)) {
                return;
            }

            Callbacks.Invoke(collisionInfo.gameObject);
        }

        #endregion UNITY MESSAGES

        #region EVENT INVOCATORS
        #endregion INVOCATORS

        #region EVENT HANDLERS
        #endregion EVENT HANDLERS

        #region METHODS
        #endregion METHODS

    }

}