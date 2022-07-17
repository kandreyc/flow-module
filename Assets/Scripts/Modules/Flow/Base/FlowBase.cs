using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Flow.Base
{
    public interface IFlowStep : IStep
    {
        TStep AddStep<TStep>() where TStep : IConfigurableStep;
        TStep AddStep<TStep, TParam>(TParam param) where TStep : IConfigurableStep<TParam>;
    }

    public abstract class FlowBase : IFlowStep
    {
        public string Name { get; }
        protected ILogger Logger { get; }
        protected List<IStep> Steps { get; }
        private readonly ITypeFactory _factory;
        protected bool IsFlowCanBeStarted { get; set; } = true;

        protected FlowBase(ILogger logger, ITypeFactory factory)
        {
            Logger = logger;
            _factory = factory;
            Name = GetType().Name;
            Steps = new List<IStep>();
        }

        public TStep AddStep<TStep>() where TStep : IConfigurableStep
        {
            var step = _factory.Create<TStep>();
            step.Configure();
            Steps.Add(step);
            return step;
        }

        public TStep AddStep<TStep, TParam>(TParam param) where TStep : IConfigurableStep<TParam>
        {
            var step = _factory.Create<TStep>();
            step.Configure(param);
            Steps.Add(step);
            return step;
        }

        public abstract UniTask OnStep(CancellationToken token);

        protected bool IsStepCanBeStarted(IStep step)
        {
            try
            {
                return step.CanBeStarted();
            }
            catch (Exception e)
            {
                Logger.Error(e, string.Empty);
                return false;
            }
        }

        public bool CanBeStarted()
        {
            return IsFlowCanBeStarted;
        }

        protected abstract void Setup();
        public virtual bool StartCondition() => true;
    }
}