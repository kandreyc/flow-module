using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Flow.Base
{
    public interface IStep
    {
        string Name { get; }
        bool CanBeStarted();
        UniTask OnStep(CancellationToken token);
    }
}