//A custom Fungus command to copy a Fungus variable value to a PlayMaker variable
using UnityEngine;
using System.Collections;
using Fungus;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace Fungus { 

    /// <summary>
    /// Write a Fungus variable value to a global playmaker variable
    /// </summary>
    [CommandInfo("Playmaker",
                 "Write to Playmaker",
                 "Write a Fungus Variable to a Playmaker variable")]

    public class WriteToPlaymaker : Command
    {

        public Flowchart flowchart;

        [UnityEngine.Tooltip("Name of the Playmaker varaiable to hold Fungus variable value")]
        [SerializeField]
        protected string destinationString;

        [UnityEngine.Tooltip("Value to write into Playmaker variable")]
        [SerializeField]
        protected string fnString;

        [UnityEngine.Tooltip("Name of the Playmaker varaiable to hold Fungus variable value")]
        [SerializeField]
        protected string destinationInt;

        [UnityEngine.Tooltip("Value to write into Playmaker variable")]
        [SerializeField]
        protected int fnInt;
       // [SerializeField]
       // protected string xyzInt;
        [UnityEngine.Tooltip("Name of the Playmaker varaiable to hold Fungus variable value")]
        [SerializeField]
        protected string destinationFloat;

        [UnityEngine.Tooltip("Value to write into Playmaker variable")]
        [SerializeField]
        protected float fnFloat;

        [UnityEngine.Tooltip("Name of the Playmaker varaiable to hold Fungus variable value")]
        [SerializeField]
        protected string destinationBool;

        [UnityEngine.Tooltip("Value to write into Playmaker variable")]
        [SerializeField]
        protected bool fnBool;

        #region public methods

        /// <summary>
        /// Write target Playmaker variable value into Fungus varaible
        /// </summary>
        public override void OnEnter()
        {
            if (destinationString != null)
            {
                WriteString(destinationString, fnString);
            }

            if (destinationInt != null)
            {
                WriteInt(destinationInt, fnInt);
            }

            if (destinationFloat != null)
            {
                WriteFloat(destinationFloat, fnFloat);
            }

            if (destinationBool != null)
            {
                WriteBool(destinationBool, fnBool);
            }

            Continue();
        }

        /// <summary>
        /// Copy target Fungus string value into Playmaker global FsmString
        /// </summary>
        /// <param name="destination">
        /// Target Playmaker global FsmString
        /// </param>
        /// <param name="stringVal">
        /// Fungus String value to write to a Playmaker FsmString
        /// </param>
        public void WriteString(string destination, string stringVal)
        {
            FsmVariables.GlobalVariables.GetFsmString(destination).Value = stringVal;
        }

        /// <summary>
        /// Copy target Fungus integer value into Playmaker global FsmInteger
        /// </summary>
        /// <param name="destination">
        /// Target Playmaker global FsmInteger
        /// </param>
        /// <param name="stringVal">
        /// Fungus String value to write to a Playmaker FsmString
        /// </param>
        public void WriteInt(string destination, int intVal)
        {
            FsmVariables.GlobalVariables.GetFsmInt(destination).Value = intVal;
        }

        /// <summary>
        /// Copy target Fungus float value into Playmaker global FsmFloat
        /// </summary>
        /// <param name="destination">
        /// Target Playmaker global FsmFloat
        /// </param>
        /// <param name="stringVal">
        /// Fungus String float to write to a Playmaker FsmFloat
        /// </param>
        public void WriteFloat(string destination, float floatVal)
        {
            FsmVariables.GlobalVariables.GetFsmFloat(destinationFloat).Value = floatVal;
        }

        /// <summary>
        /// Copy target Fungus boolean value into Playmaker global FsmBoolean
        /// </summary>
        /// <param name="destination">
        /// Target Playmaker global FsmBoolean
        /// </param>
        /// <param name="stringVal">
        /// Fungus Boolean value to write to a Playmaker FsmBoolean
        /// </param>
        public void WriteBool(string destination, bool boolVal)
        {
            FsmVariables.GlobalVariables.GetFsmBool(destination).Value = boolVal;
        }
        #endregion
    }
}