using System.Collections.Generic;
using UnityEngine;

namespace NorskaLib.Spreadsheets
{
    public enum SpreadsheetSerializationFormat
    {
        JSON,
        Binary
    }

    public abstract class SpreadsheetsContainerBase : ScriptableObject
    {
        #region Editor
#if UNITY_EDITOR

        /// <summary>
        /// NOTE: This field is used in the Editor only and should not be adressed in the build!
        /// </summary>
        [SerializeField, HideInInspector]
        public string documentId;

        /// <summary>
        /// NOTE: This field is used in the Editor only and should not be adressed in the build!
        /// </summary>
        [SerializeField, HideInInspector]
        public List<string> selectedTogglesIds;

        /// <summary>
        /// NOTE: This field is used in the Editor only and should not be adressed in the build!
        /// </summary>
        [SerializeField, HideInInspector]
        public bool foldoutImportGUI;

        /// <summary>
        /// NOTE: This field is used in the Editor only and should not be adressed in the build!
        /// </summary>
        [SerializeField, HideInInspector]
        public bool foldoutSerializationGUI;

        /// <summary>
        /// NOTE: This field is used in the Editor only and should not be adressed in the build!
        /// </summary>
        [SerializeField, HideInInspector]
        public string serializationOutputPath = "../../Configs";

        /// <summary>
        /// NOTE: This field is used in the Editor only and should not be adressed in the build!
        /// </summary>
        [SerializeField, HideInInspector]
        public string serializationFileName = "Configs.v0.1";

        [SerializeField, HideInInspector]
        public SpreadsheetSerializationFormat serializationFormat;

#endif
        #endregion
    }
}