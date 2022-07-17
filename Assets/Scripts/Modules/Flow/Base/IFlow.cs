namespace Modules.Flow.Base
{
    public interface IFlow : IFlowStep, IConfigurableStep
    {
        bool StartCondition();
    }

    public interface IFlow<in TParam> : IFlowStep, IConfigurableStep<TParam>
    {
        bool StartCondition();
    }
}