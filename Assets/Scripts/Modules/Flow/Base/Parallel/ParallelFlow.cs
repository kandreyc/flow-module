using System;

namespace Modules.Flow.Base.Parallel
{
    public abstract class ParallelFlow : ParallelFlowBase, IFlow
    {
        protected ParallelFlow(ILogger logger, ITypeFactory factory) : base(logger, factory) { }

        public void Configure()
        {
            try
            {
                IsFlowCanBeStarted = StartCondition();

                if (CanBeStarted())
                {
                    Setup();
                }
            }
            catch (Exception e)
            {
                IsFlowCanBeStarted = false;
                Logger.Error(e, string.Empty);
            }
        }
    }

    public abstract class ParallelFlow<TParam> : ParallelFlowBase, IFlow<TParam>
    {
        protected TParam Param { get; private set; }

        protected ParallelFlow(ILogger logger, ITypeFactory factory) : base(logger, factory) { }

        public void Configure(TParam param)
        {
            try
            {
                Param = param;
                IsFlowCanBeStarted = StartCondition();

                if (CanBeStarted())
                {
                    Setup();
                }
            }
            catch (Exception e)
            {
                IsFlowCanBeStarted = false;
                Logger.Error(e, string.Empty);
            }
        }
    }
}