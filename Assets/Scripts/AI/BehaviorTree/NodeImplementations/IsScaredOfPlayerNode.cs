public class IsScaredOfPlayerNode : DecisionNode
{
    public IsScaredOfPlayerNode()
    {
        Comparator = () =>
        {
            var manager = MoralityManager.GetMoralityManager();
            if (manager.Karma < -5)
            {
                return true;
            }

            return false;
        };
    }
}
