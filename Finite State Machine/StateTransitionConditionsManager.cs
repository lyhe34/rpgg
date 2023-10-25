using System.Collections.Generic;

namespace RPGG
{
	public class StateTransitionConditionsManager : ConditionsManager
	{
		public List<IStateTransitionCondition> stateTransitionConditions = new List<IStateTransitionCondition>();

		public override bool CheckConditions()
		{
			if (base.CheckConditions())
			{
				return true;
			}
			else
			{
				foreach (var stateTransitionCondition in stateTransitionConditions)
				{
					if (stateTransitionCondition.IsMet())
					{
						return true;
					}
				}
			}

			return false;
		}

		public void OnStateEnter()
		{
			foreach (var stateTransitionCondition in stateTransitionConditions)
			{
				stateTransitionCondition.OnStateEnter();
			}
		}

		public void OnStateExit()
		{
			foreach (var stateTransitionCondition in stateTransitionConditions)
			{
				stateTransitionCondition.OnStateExit();
			}
		}

		public void OnStateUpdate()
		{
			foreach (var stateTransitionCondition in stateTransitionConditions)
			{
				stateTransitionCondition.OnStateUpdate();
			}
		}

		public void OnStateFixedUpdate()
		{
			foreach (var stateTransitionCondition in stateTransitionConditions)
			{
				stateTransitionCondition.OnStateFixedUpdate();
			}
		}
	}
}