using System;

namespace Modules.Flow.Base.Consecutive
{
    public abstract class ConsecutiveFlow : ConsecutiveFlowBase, IFlow
    {
        protected ConsecutiveFlow(ILogger logger, ITypeFactory factory) : base(logger, factory) { }

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

    public abstract class ConsecutiveFlow<TParam> : ConsecutiveFlowBase, IFlow<TParam>
    {
        protected TParam Param { get; private set; }

        protected ConsecutiveFlow(ILogger logger, ITypeFactory factory) : base(logger, factory) { }

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