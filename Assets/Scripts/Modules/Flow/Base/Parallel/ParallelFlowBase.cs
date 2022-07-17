using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;

namespace Modules.Flow.Base.Parallel
{
    public abstract class ParallelFlowBase : FlowBase
    {
        protected ParallelFlowBase(ILogger logger, ITypeFactory factory) : base(logger, factory) { }

        public sealed override async UniTask OnStep(CancellationToken token)
        {
            if (!CanBeStarted())
            {
                Logger.Trace("Flow Skipped.");
                return;
            }

            token.ThrowIfCancellationRequested();
            Assert.IsTrue(Steps.Any());

            try
            {
                Logger.Trace("Flow Started.");
                await UniTask.WhenAll(Steps.Select(step => ProcessStep(step, token)));
                Logger.Trace("Flow Finished.");
            }
            catch (OperationCanceledException)
            {
                Logger.Trace("Flow Cancelled.");
                throw;
            }
        }

        private async UniTask ProcessStep(IStep step, CancellationToken token)
        {
            if (!IsStepCanBeStarted(step))
            {
                Logger.Trace("Step '{0}' skipped.", step.Name);
                return;
            }

            try
            {
                Logger.Trace("Step '{0}' started.", step.Name);
                await step.OnStep(token);
                Logger.Trace("Step '{0}' finished.", step.Name);
            }
            catch (OperationCanceledException)
            {
                token.ThrowIfCancellationRequested();
                Logger.Trace("Step '{0}' cancelled.", step.Name);
            }
            catch (Exception e)
            {
                Logger.Error(e, "Step '{0}' finished with error.", step.Name);
            }
        }
    }
}