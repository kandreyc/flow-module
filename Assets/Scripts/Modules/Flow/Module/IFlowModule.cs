using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.Flow.Base;

namespace Modules.Flow.Module
{
    public interface IFlowModule
    {
        public bool IsAnyActiveFlow();
        public bool IsFlowActive<T>() where T : FlowBase;
        public UniTask RequestFlow<TFlow>(CancellationToken token = default) where TFlow : IFlow;
        public UniTask RequestFlow<TFlow, TParam>(TParam param, CancellationToken token = default) where TFlow : IFlow<TParam>;
    }
}