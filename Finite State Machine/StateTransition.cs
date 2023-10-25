namespace RPGG
{
	public class StateTransition
	{
		public FiniteStateMachine Fsm { get; private set; }

		public State targetState;

		public StateTransitionConditionsManager conditionsManager = new StateTransitionConditionsManager();

		public StateTransition(FiniteStateMachine fsm, State targetState)
		{
			Fsm = fsm;
			this.targetState = targetState;
		}

		public bool ShouldTransit()
		{
			return conditionsManager.CheckConditions();
		}

		public void OnStateEnter()
		{
			conditionsManager.OnStateEnter();
		}

		public void OnStateExit()
		{
			conditionsManager.OnStateExit();
		}

		public void OnStateUpdate()
		{
			conditionsManager.OnStateUpdate();
		}

		public void OnStateFixedUpdate()
		{
			conditionsManager.OnStateFixedUpdate();
		}
	}
}