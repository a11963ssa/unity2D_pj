using UnityEngine;
using Fungus;
using HutongGames.PlayMaker;

namespace HutongGames.Playmaker.Actions
{

    /// <summary>
    /// A custom PlayMaker action to copy a PlayMaker variable to a Fungus command.
    /// </summary>
    [ActionCategory(ActionCategory.ScriptControl)]
    [PlayMaker.Tooltip("Execute a named Fungus Block")]

    public class PlaymakerExecuteBlock : FsmStateAction
    { 
       [PlayMaker.Tooltip("Name of the Block to be executed")]
        public FsmString blockName;
        [PlayMaker.Tooltip("Name of the flowchart that contains the target block")]
        public Flowchart flowchart;
        [PlayMaker.Tooltip("Update the target block every frame.")]
        public FsmBool everyFrame;

        #region public methods
        /// <summary>
        /// Reset target block and everyFrame to default values
        /// </summary>
        public override void Reset()
        {
            blockName = null;

            everyFrame = true;
        }
        /// <summary>
        /// Execute target block upon entering state
        /// </summary>
        public override void OnEnter()
        {

            flowchart.ExecuteBlock(blockName.Value);

            if (!everyFrame.Value)
            {
                Finish();
            }
        }
        #endregion
    }
}