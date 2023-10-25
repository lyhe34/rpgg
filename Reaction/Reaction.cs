using System.Collections.Generic;

namespace RPGG
{
	public class Reaction
	{
		public List<Action> Actions = new();

		public event System.Action OnExecuted;

		public void Execute()
		{
			OnExecuted?.Invoke();
		}
	}

	public class Reaction<T>
	{
		public List<Action> actions = new();
		public List<Action<T>> parameterActions = new();

		public event System.Action OnExecuted;
		public event System.Action<T> OnExecuted_Parameter;

		public void Execute(T parameter)
		{
			actions.ForEach(a => a.Execute());
			parameterActions.ForEach(a => a.Execute(parameter));

			OnExecuted?.Invoke();
			OnExecuted_Parameter?.Invoke(parameter);
		}
	}
}

