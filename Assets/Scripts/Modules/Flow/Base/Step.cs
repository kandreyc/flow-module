namespace Modules.Flow.Base
{
    public abstract class Step : StepBase, IConfigurableStep
    {
        public virtual void Configure() { }
    }

    public abstract class Step<TParam> : StepBase, IConfigurableStep<TParam>
    {
        protected TParam Param { get; private set; }

        public virtual void Configure(TParam param)
        {
            Param = param;
        }
    }
}