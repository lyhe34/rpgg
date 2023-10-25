using System.Collections.Generic;

namespace RPGG
{
	public class ConditionsManager
	{
		public List<ICondition> conditions = new();

		public virtual bool CheckConditions()
		{
			foreach (var condition in conditions)
			{
				if (condition.IsMet())
				{
					return true;
				}
			}

			return false;
		}
	}

	public class ConditionsManager<T>
	{
		public List<ICondition> conditions = new();

		public List<ICondition<T>> parameterConditions = new();

		public bool CheckConditions(T t)
		{
			foreach (var condition in conditions)
			{
				if (condition.IsMet())
				{
					return true;
				}
			}

			foreach (var condition in parameterConditions)
			{
				if (condition.IsMet(t))
				{
					return true;
				}
			}

			return false;
		}
	}
}

