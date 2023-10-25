using System.Collections.Generic;

namespace RPGG
{
	public class StateTransitionConditionsGroup : ConditionsGroup, IStateTransitionCondition
	{
		public List<StateTransitionCondition> stateTransitionConditions = new List<StateTransitionCondition>();

		public void OnStateEnter()
		{
			foreach (var condition in stateTransitionConditions)
			{
				condition.OnStateEnter();
			}
		}

		public void OnStateExit()
		{
			foreach (var condition in stateTransitionConditions)
			{
				condition.OnStateExit();
			}
		}

		public void OnStateUpdate()
		{
			foreach (var condition in stateTransitionConditions)
			{
				condition.OnStateUpdate();
			}
		}

		public void OnStateFixedUpdate()
		{
			foreach (var condition in stateTransitionConditions)
			{
				condition.OnStateFixedUpdate();
			}
		}

		public override bool IsMet()
		{
			if (!base.IsMet())
			{
				return false;
			}

			foreach (var condition in stateTransitionConditions)
			{
				if (!condition.IsMet())
				{
					return false;
				}
			}

			return true;
		}
	}
}