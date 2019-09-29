using UnityEngine;
using Fungus;

namespace Fungus
{
    ///<summary>
    ///Trigger a global state transition in the Playmaker FSM
    ///</summary>
    [CommandInfo("Playmaker",
                 "Global State Transition",
                 "Send an event from Fungus to Playmaker")]
    public class FungusStateTransition : Command
    {
        [Tooltip("Takes in the FSM containing the global event you wish to trigger")]
        [SerializeField] protected PlayMakerFSM FSM;

        [Tooltip("Name of the target global event")]
        [SerializeField] protected string destinationEvent;

        #region Public methods

        /// <summary>
        /// Trigger input Global State Transition in input FSM
        /// </summary>
        public override void OnEnter()
        {
            FSM.SendEvent(destinationEvent);
            Continue();
        }
        #endregion
    }
}