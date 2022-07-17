using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.Flow.Base;
using Modules.Flow.Interactor;
using Zenject;

namespace Modules.Flow.Module
{
    public class FlowModule : IFlowModule
    {
        [Inject] private readonly IFlowInteractor _interactor;

        public bool IsAnyActiveFlow()
        {
            return _interactor.IsAnyActiveFlow();
        }

        public bool IsFlowActive<T>() where T : FlowBase
        {
            return _interactor.IsFlowActive<T>();
        }

        public UniTask RequestFlow<TFlow>(CancellationToken token) where TFlow : IFlow
        {
            return _interactor.RequestFlow<TFlow>(token);
        }

        public UniTask RequestFlow<TFlow, TParam>(TParam param, CancellationToken token) where TFlow : IFlow<TParam>
        {
            return _interactor.RequestFlow<TFlow, TParam>(param, token);
        }
    }
}