using System.Collections.Generic;

namespace RPGG
{
	public class ConditionsGroup : ICondition
	{
		public List<Condition> conditions = new();

		public virtual bool IsMet()
		{
			foreach (var condition in conditions)
			{
				if (!condition.IsMet())
				{
					return false;
				}
			}

			return true;
		}
	}

	public class ConditionsGroup<T> : ICondition<T>
	{
		public List<Condition<T>> conditions = new();

		public bool IsMet(T t)
		{
			foreach (var condition in conditions)
			{
				if (!condition.IsMet(t))
				{
					return false;
				}
			}

			return true;
		}
	}
}

