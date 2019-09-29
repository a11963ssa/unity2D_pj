using Fungus;

namespace HutongGames.PlayMaker.Actions
{

    /// <summary>
    /// A custom PlayMaker action to copy a PlayMaker variable to a Fungus command.
    /// </summary>

    [ActionCategory(ActionCategory.ScriptControl)]
    [PlayMaker.Tooltip("Copy a PlayMaker variable to a Fungus command")]

    public class WriteToFungus : FsmStateAction
    {
        [RequiredField]
        [Tooltip("Flowchart that contains the target variables")]
        public Flowchart flowchart;
        [Tooltip("Name of Fungus String to be written to")]
        public FsmString stringDestination;
        [Tooltip("Value to write into Fungus variable")]
        public FsmString pmString;
        [Tooltip("Name of Fungus String to be written to")]
        public FsmString intDestination;
        [Tooltip("Value to write into Fungus variable")]
        public FsmInt pmInt;
        [Tooltip("Name of Fungus String to be written to")]
        public FsmString floatDestination;
        [Tooltip("Value to write into Fungus variable")]
        public FsmFloat pmFloat;
        [Tooltip("Name of Fungus String to be written to")]
        public FsmString boolDestination;
        [Tooltip("Value to write into Fungus variable")]
        public FsmBool pmBool;
        [Tooltip("Update variables every frame")]
        public FsmBool everyFrame;


        #region Public Methods
        /// <summary>
        /// Reset to default values
        /// </summary>
        public override void Reset()
        {

            flowchart = null;
            pmString = null;

            everyFrame = true;
        }
        /// <summary>
        /// Write target Playmaker variable value into Fungus varaible
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
                StoreVariable();
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
                StoreVariable();
            }
        }
        /// <summary>
        /// Hold variables
        /// </summary>
        public void StoreVariable()
        {

            var flow = flowchart;
            if (flow == null)
            {
                return;
            }   
        }
        /// <summary>
        /// Copy target Playmaker FsmString value into Fungus string
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Variable
        /// </param>
        /// <param name="pmString">
        /// Playmaker FsmString value to write to Fungus string
        /// </param>
        public void ChangeString(FsmString destination, FsmString pmString)
        {
           flowchart.SetStringVariable(destination.Value, pmString.Value);
        }

        /// <summary>
        /// Copy target Playmaker FsmInteger value into Fungus integer
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Integer
        /// </param>
        /// <param name="pmInt">
        /// Playmaker FsmInteger value to Fungus integer
        /// </param>
        public void ChangeInt(FsmString destination, FsmInt pmInt)
        {
            flowchart.SetIntegerVariable(destination.Value, pmInt.Value);
        }
        /// <summary>
        /// Copy target Playmaker FsmFloat value into Playmaker integer
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Float
        /// </param>
        /// <param name="pmInt">
        /// Playmaker FsmFloat to write to Fungus float
        /// </param>
        public void ChangeFloat(FsmString destination, FsmFloat pmFloat)
        {

            flowchart.SetFloatVariable(destination.Value, pmFloat.Value);
        }
        /// <summary>
        /// Copy target Playmaker FsmBool value into Fungus boolean
        /// </summary>
        /// <param name="destination">
        /// Target Fungus Integer
        /// </param>
        /// <param name="pmInt">
        /// Playmaker Fsmbool to write Fungus integer value
        /// </param>
        public void ChangeBoolean(FsmString destination, FsmBool pmBool)
        {

            flowchart.SetBooleanVariable(destination.Value, pmBool.Value);
        }
        #endregion
    }
}