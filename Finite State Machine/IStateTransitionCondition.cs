namespace RPGG
{
	public interface IStateTransitionCondition : ICondition
	{
		void OnStateEnter();

		void OnStateExit();

		void OnStateUpdate();

		void OnStateFixedUpdate();
	}
}
