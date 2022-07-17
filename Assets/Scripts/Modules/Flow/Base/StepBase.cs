using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Flow.Base
{
    public abstract class StepBase : IStep
    {
        public string Name { get; }

        protected StepBase()
        {
            Name = GetType().Name;
        }

        public virtual bool CanBeStarted() => true;
        public abstract UniTask OnStep(CancellationToken token);
    }
}