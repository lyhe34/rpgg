namespace RPGG
{
	public interface ICondition
	{
		bool IsMet();
	}

	public interface ICondition<T>
	{
		bool IsMet(T t);
	}
}
