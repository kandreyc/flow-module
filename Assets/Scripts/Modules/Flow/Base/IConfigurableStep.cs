namespace Modules.Flow.Base
{
    public interface IConfigurableStep : IStep
    {
        void Configure();
    }

    public interface IConfigurableStep<in TParam> : IStep
    {
        void Configure(TParam param);
    }
}