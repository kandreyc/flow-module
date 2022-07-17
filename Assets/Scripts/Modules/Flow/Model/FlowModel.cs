using System.Collections.Generic;
using System.Linq;
using Modules.Flow.Base;

namespace Modules.Flow.Module
{
    public class FlowModel
    {
        public readonly HashSet<IFlowStep> ActiveFlows = new();

        public bool IsAnyActiveFlow()
        {
            return ActiveFlows.Any();
        }

        public bool IsFlowActive<T>() where T : IFlowStep
        {
            return ActiveFlows.Any(flow => flow.Name == typeof(T).Name);
        }
    }
}