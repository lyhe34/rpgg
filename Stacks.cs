using UnityEngine;

namespace RPGG
{
	public class Stacks
	{
		private int currentStacks = 1;

		public int CurrentStacks
		{
			get { return currentStacks; }
			private set { currentStacks = value; }
		}

		public Statistic maximumStacks;

		public Statistic MaximumStacks
		{
			get { return maximumStacks; }
			private set 
			{ 
				if (maximumStacks != null)
				{
					currentStacks = (int)Mathf.Clamp(currentStacks, 0, maximumStacks.Value);
					maximumStacks = value;
				}
			}
		}

		public void AppendStack(int amount = 1)
		{
			currentStacks = (int)Mathf.Clamp(currentStacks + amount, 0, maximumStacks.Value);
		}

		public Stacks(Statistic maximumStacks) 
		{
			this.maximumStacks = maximumStacks;
		}
	}
}
