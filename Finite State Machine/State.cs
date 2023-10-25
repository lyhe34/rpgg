using System.Collections.Generic;

namespace RPGG
{
	public class State
	{
		protected string name;
		public string Name => name;

		public FiniteStateMachine Fsm { get; private set; }

		public List<StateTransition> transitions = new List<StateTransition>();

		public List<StateAction> actions = new List<StateAction>();

		public Reaction OnEnter = new();
		public Reaction OnExit = new();
		public Reaction OnUpdate = new();
		public Reaction OnFixedUpdate = new();

		public State(FiniteStateMachine fsm, string name)
		{
			Fsm = fsm;
			fsm.name = name;
			fsm.states.Add(this);
		}

		public virtual void Initialize() { }

		public void Enter()
		{
			foreach (var action in actions)
			{
				action.OnEnter();
			}

			OnEnter.Execute();

			foreach (var transition in transitions)
			{
				transition.OnStateEnter();
			}
		}

		public void Exit()
		{
			foreach (var action in actions)
			{
				action.OnExit();
			}

			OnExit.Execute();

			foreach (var transition in transitions)
			{
				transition.OnStateExit();
			}
		}

		public void Update()
		{
			foreach (var action in actions)
			{
				action.OnUpdate();
			}

			OnUpdate.Execute();

			foreach (var transition in transitions)
			{
				transition.OnStateUpdate();
			}

			foreach (var transition in transitions)
			{
				if (transition.ShouldTransit())
				{
					Fsm.ChangeState(transition.targetState);
					return;
				}
			}
		}

		public void FixedUpdate()
		{
			foreach (var action in actions)
			{
				action.OnFixedUpdate();
			}

			OnFixedUpdate.Execute();

			foreach (var transition in transitions)
			{
				transition.OnStateFixedUpdate();
			}
		}
	}

	public class State<T> : State where T : FiniteStateMachine
	{
		public new T Fsm;

		public State(T fsm, string name) : base(fsm, name)
		{
			Fsm = fsm;
			this.name = name;
		}
	}
}


