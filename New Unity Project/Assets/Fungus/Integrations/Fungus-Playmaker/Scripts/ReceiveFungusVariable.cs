using Fungus;
using HutongGames.PlayMaker;

namespace HutongGames.Playmaker.Actions
{
    /// <summary>
    /// A custom PlayMaker action to copy a PlayMaker variable to a Fungus command. 
    /// </summary>
    [ActionCategory(ActionCategory.ScriptControl)]
    [PlayMaker.Tooltip("Copy a Fungus variable value to a Playmaker variable")]

    public class ReceiveFungusVariable : FsmStateAction
    {
        [RequiredField]
        [Tooltip("Flowchart that contains the target variables")]
        public Flowchart flowchart;
        [Tooltip("Name of Fungus string to be read from")]
        public FsmString stringDestination;
        [Tooltip("Variable to hold Fungus variable value")]
        public FsmString pmString;
        [Tooltip("Name of Fungus integer to be read from")]
        public FsmString intDestination;
        [Tooltip("Variable to hold Fungus variable value")]
        public FsmInt pmInt;
        [Tooltip("Name of Fungus float to be read from")]
        public FsmString floatDestination;
        [Tooltip("Variable to hold Fungus variable value")]
        public FsmFloat pmFloat;
        [Tooltip("Name of Fungus boolean to be read from")]
        public FsmString boolDestination;
        [Tooltip("Variable to hold Fungus variable value")]
        public FsmBool pmBool;
        private string dest;
        [Tooltip("Update the variables every frame")]
        public FsmBool everyFrame;

        #region Public Methods
        /// <summary>
        /// Reset to default values
        /// </summary>
        public override void Reset()
        {

            flowchart = null;
            pmString = null;
            pmInt = null;
            pmFloat = null;
            pmBool = null;
            everyFrame = true;
        }
        /// <summary>
        /// Read target Fungus variable value into Playmaker varaible
        /// </summary>
        public override void OnEnter()
        {
            if (stringDestination != null)
            {
                ChangeString(stringDestination, pmString);
            }

            if (intDestination != null)
            {
                ChangeInt(intDestination, pmInt);
            }

            if (floatDestination != null)
            {
                ChangeFloat(floatDestination, pmFloat);
            }

            if (boolDestination != null)
            {
                ChangeBoolean(boolDestination, pmBool);
            }

            if (!everyFrame.Value)
            {
                Store_Variable();
                Finish();
            }
        }
        /// <summary>
        /// Update every frame
        /// </summary>
        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                Store_Variable();
            }
        }
        /// <summary>
        /// Hold varaibles
        /// </summary>
        public void Store_Variable()
        {
            var flow = flowchart;
            if (flow == null)
            {
                return;
            }
        }
        /// <summary>
        /// Copy target Fungus string value into playmaker string
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Variable
        /// </param>
        /// <param name="pmString">
        /// Playmaker FsmString to hold Fungus string value
        /// </param>
        public FsmString ChangeString(FsmString destination, FsmString pmString)
        {
            dest = destination.Value;
            pmString.Value = flowchart.GetStringVariable(dest);
            return pmString;
        }
        /// <summary>
        /// Copy target Fungus integer value into Playmaker integer
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Integer
        /// </param>
        /// <param name="pmInt">
        /// Playmaker FsmInteger to hold Fungus integer value
        /// </param>
        public FsmInt ChangeInt(FsmString destination, FsmInt pmInt)
        {
            dest = destination.Value;
            pmInt.Value = flowchart.GetIntegerVariable(dest);
            return pmInt;
        }
        /// <summary>
        /// Copy target Fungus float value into Playmaker FsmFloat
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Float
        /// </param>
        /// <param name="pmFloat">
        /// Playmaker FsmFloat to hold Fungus float value
        /// </param>
        public FsmFloat ChangeFloat(FsmString destination, FsmFloat pmFloat)
        {
            dest = destination.Value;
            pmFloat.Value = flowchart.GetFloatVariable(dest);
            return pmFloat;
        }
        /// <summary>
        /// Copy target Fungus boolean value into Playmaker FsmBoolean
        /// </summary>
        /// <param name="destination">
        /// Target Fungus boolean
        /// </param>
        /// <param name="pmFloat">
        /// Playmaker FsmBool to hold Fungus boolean value
        /// </param>
        public FsmBool ChangeBoolean(FsmString destination, FsmBool pmBool)
        {
            dest = destination.Value;
            pmBool.Value = flowchart.GetBooleanVariable(dest);
            return pmBool;
        }
        #endregion
    }
}


