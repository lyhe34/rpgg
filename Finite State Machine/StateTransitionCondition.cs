namespace RPGG
{
	public abstract class StateTransitionCondition : Condition, IStateTransitionCondition
	{
		public virtual void OnStateEnter() { }

		public virtual void OnStateExit() { }

		public virtual void OnStateUpdate() { }

		public virtual void OnStateFixedUpdate() { }

		public StateTransitionCondition(bool assertion) : base(assertion) { }
	}
}