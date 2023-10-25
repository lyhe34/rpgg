using System.Collections.Generic;
using UnityEngine;

namespace RPGG
{
	[DefaultExecutionOrder(-1)]
	public class FiniteStateMachine : MonoBehaviour
	{
		public List<State> states = new();

		public State CurrentState { get; private set; }

		public State this[string name] { get { return states.Find(s => s.Name == name); } }

		public void Initialize(State firstState)
		{
			foreach (var state in states)
			{
				state.Initialize();
			}

			CurrentState = firstState;
			CurrentState.Enter();
		}

		public void ChangeState(State state)
		{
			CurrentState.Exit();

			CurrentState = state;

			CurrentState.Enter();
		}

		private void Update()
		{
			CurrentState.Update();
		}

		private void FixedUpdate()
		{
			CurrentState.FixedUpdate();
		}
	}
}

