using UnityEngine.InputSystem;

namespace RPGG
{
	public class InputData
	{
		/// <summary>
		/// If input was triggered this frame.
		/// </summary>
		public bool Triggered { get; protected set; }

		/// <summary>
		/// If input was released this frame.
		/// </summary>
		public bool Released { get; protected set; }

		/// <summary>
		/// If input is currently held.
		/// </summary>
		public bool Held { get; protected set; }

		public Reaction OnTriggered;
		public Reaction OnReleased;
		public Reaction OnHeld;

		public virtual bool IsDown(InputValue inputValue)
		{
			var v = inputValue.Get<float>();

			return v != 0;
		}

		public void Update(InputValue inputValue)
		{
			if (IsDown(inputValue) && !Held)
			{
				Triggered = true;
				Held = true;
			}
			else if (Held && !IsDown(inputValue))
			{
				Released = true;
				Held = false;
			}
		}

		public void Reset()
		{
			Released = false;
			Triggered = false;
		}
	}

	public abstract class InputData<T> : InputData
	{
		public T Value { get; set; }
		public T LastTriggeredValue { get; set; }
	}
}