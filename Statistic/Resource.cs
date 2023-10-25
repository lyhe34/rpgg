using UnityEngine;

namespace RPGG
{
	public class Resource : Statistic
	{
		public Resource(float value, StatisticsManager manager = null) : base(manager) 
		{
			this.value = value;
		}

		public void Modify(StatisticModifier modifier)
		{
			if (modifier.isPeriodic)
			{
				var existingModification = manager.timedModifications.Find(m => m.modifier == modifier);

				if (existingModification != null)
				{
					if (existingModification.timer != null && existingModification.timer.As(out PeriodicTimer existingPeriodicTimer))
					{
						existingPeriodicTimer.Reset();
					}
					else
					{
						PeriodicTimer periodicTimer = new PeriodicTimer(modifier.duration, modifier.rate);
						periodicTimer.OnTimerEnd.OnExecuted += () => manager.RemoveTimedModification(existingModification);
						periodicTimer.OnUpdate.OnExecuted += () => ApplyModification(existingModification);
						existingModification.timer = periodicTimer;
					}

					if (modifier.isStackable)
					{
						if (existingModification.stacks != null)
						{
							existingModification.stacks.AppendStack();
						}
						else if(existingModification.modifier.maximumStacks != null)
						{
							existingModification.stacks = new Stacks(modifier.maximumStacks);
						}
					}
				}
				else
				{
					PeriodicTimer timer = new PeriodicTimer(modifier.duration, modifier.rate);

					Stacks stacks = null;

					if (modifier.isStackable && modifier.maximumStacks != null)
					{
						stacks = new Stacks(modifier.maximumStacks);
					}

					StatisticModification modification = new StatisticModification(this, modifier, stacks, timer);

					timer.OnTimerEnd.OnExecuted += () => manager.RemoveTimedModification(modification);
					timer.OnUpdate.OnExecuted += () => ApplyModification(modification);

					manager.AddTimedModification(modification);
				}
			}
			else
			{
				StatisticModification modification = new StatisticModification(this, modifier);

				ApplyModification(modification);
			}
		}

		private void ApplyModification(StatisticModification modification)
		{
			modification.Reset();

			if (preCalculConditions.CheckConditions(modification))
			{
				Alter(modification);

				ClampValue(modification);
			}
			else
			{
				return;
			}

			if (postCalculConditions.CheckConditions(modification))
			{
				React(modification);
			}
		}

		public void SetValue(float value, bool triggerReaction = false)
		{
			
		}
	}
}
