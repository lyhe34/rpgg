namespace RPGG
{
	public abstract class Condition : ICondition
	{
		public bool assertion;

		public Condition(bool assertion)
		{
			this.assertion = assertion;
		}

		public bool IsMet()
		{
			return Assert() == assertion;
		}

		protected abstract bool Assert();
	}

	public abstract class Condition<T> : ICondition<T>
	{
		public bool assertion;

		public Condition(bool assertion)
		{
			this.assertion = assertion;
		}

		public bool IsMet(T t)
		{
			return Assert(t) == assertion;
		}

		protected abstract bool Assert(T t);
	}
}