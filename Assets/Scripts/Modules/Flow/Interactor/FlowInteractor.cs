using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.Flow.Base;
using Modules.Flow.Module;

namespace Modules.Flow.Interactor
{
    public interface IFlowInteractor
    {
        bool IsAnyActiveFlow();
        bool IsFlowActive<TFlow>() where TFlow : FlowBase;
        public UniTask RequestFlow<T>(CancellationToken token) where T : IFlow;
        public UniTask RequestFlow<TFlow, TParam>(TParam param, CancellationToken token) where TFlow : IFlow<TParam>;
    }

    public class FlowInteractor : IFlowInteractor
    {
        private readonly FlowModel _model;
        private readonly ITypeFactory _typeFactory;

        public FlowInteractor(ITypeFactory typeFactory, FlowModel model)
        {
            _model = model;
            _typeFactory = typeFactory;
        }

        public async UniTask RequestFlow<T>(CancellationToken token) where T : IFlow
        {
            var flow = _typeFactory.Create<T>();
            flow.Configure();
            _model.ActiveFlows.Add(flow);

            try
            {
                await flow.OnStep(token);
            }
            finally
            {
                _model.ActiveFlows.Remove(flow);
            }
        }

        public async UniTask RequestFlow<TFlow, TParam>(TParam param, CancellationToken token) where TFlow : IFlow<TParam>
        {
            var flow = _typeFactory.Create<TFlow>();
            flow.Configure(param);
            _model.ActiveFlows.Add(flow);

            try
            {
                await flow.OnStep(token);
            }
            finally
            {
                _model.ActiveFlows.Remove(flow);
            }
        }

        public bool IsAnyActiveFlow()
        {
            return _model.IsAnyActiveFlow();
        }

        public bool IsFlowActive<TFlow>() where TFlow : FlowBase
        {
            return _model.IsFlowActive<TFlow>();
        }
    }
}