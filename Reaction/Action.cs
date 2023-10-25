using System.Collections.Generic;

namespace RPGG
{
	public abstract class Action
	{
		public abstract void Execute();
	}

	public abstract class Action<T>
	{
		public abstract void Execute(T parameter);
	}

	public sealed class ConditionalAction : Action
	{
		public Action action;

		public ConditionsManager conditionsManager;

		public override void Execute()
		{
			if (conditionsManager.CheckConditions())
			{
				action.Execute();
			}
		}
	}

	public sealed class ConditionalAction<T> : Action<T>
	{
		public Action action;

		public ConditionsManager<T> conditionsManager;

		public override void Execute(T parameter)
		{
			if (conditionsManager.CheckConditions(parameter))
			{
				action.Execute();
			}
		}
	}

	public sealed class ConditionalParameterAction<T> : Action<T>
	{
		public Action<T> action;

		public ConditionsManager<T> conditionsManager;

		public override void Execute(T parameter)
		{
			if (conditionsManager.CheckConditions(parameter))
			{
				action.Execute(parameter);
			}
		}
	}

	public sealed class ConditionalActionsGroup : Action
	{
		public List<Action> actions = new();

		public ConditionsManager conditionsManager;

		public override void Execute()
		{
			throw new System.NotImplementedException();
		}
	}

	public sealed class ConditionalActionsGroup<T> : Action<T>
	{
		public List<Action> actions = new();

		public ConditionsManager<T> conditionsManager;

		public override void Execute(T parameter)
		{
			if (!conditionsManager.CheckConditions(parameter)) return;

			foreach (var action in actions)
			{
				action.Execute();
			}
		}
	}

	public sealed class ConditionalParameterActionsGroup<T> : Action<T>
	{
		public List<Action> actions = new();

		public List<Action<T>> parameterActions = new();

		public ConditionsManager<T> conditionsManager;

		public override void Execute(T parameter)
		{
			if (!conditionsManager.CheckConditions(parameter)) return;

			foreach (var action in actions)
			{
				action.Execute();
			}

			foreach (var action in parameterActions)
			{
				action.Execute(parameter);
			}
		}
	}
}
