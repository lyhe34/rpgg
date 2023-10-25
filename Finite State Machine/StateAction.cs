namespace RPGG
{
	public abstract class StateAction
	{
		public virtual void OnEnter() { }
		public virtual void OnExit() { }
		public virtual void OnUpdate() { }
		public virtual void OnFixedUpdate() { }
	}
}