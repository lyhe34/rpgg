namespace RPGG
{
	public abstract class Alter
	{
		public ConditionsManager<StatisticModification> conditionsManager;

		public float Amount(StatisticModification modification)
		{
			if (conditionsManager.CheckConditions(modification))
			{
				return Calcul(modification);
			}

			return 0;
		}

		public abstract float Calcul(StatisticModification modification);
	}
}