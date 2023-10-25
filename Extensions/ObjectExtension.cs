public static class ObjectExtension
{
	public static bool As<T>(this object obj, out T result)
	{
		if (obj is T)
		{
			result = (T)obj;
			return true;
		}
		result = default;
		return false;
	}
}
