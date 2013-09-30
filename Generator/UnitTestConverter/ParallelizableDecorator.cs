using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace TechTalk.SpecFlow.Generator.UnitTestConverter
{
    public class ParallelizableDecorator : ITestClassTagDecorator
    {
        private const string TAG = "parallelizable";
        private readonly ITagFilterMatcher tagFilterMatcher;

        public ParallelizableDecorator(ITagFilterMatcher tagFilterMatcher)
        {
            this.tagFilterMatcher = tagFilterMatcher;
        }

        public int Priority
        {
            get { return PriorityValues.Low; }
        }

        public bool RemoveProcessedTags
        {
            get { return true; }
        }

        public bool ApplyOtherDecoratorsForProcessedTags
        {
            get { return false; }
        }

        public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext)
        {
            return CanDecorateFrom(tagName) && (generationContext.UnitTestGeneratorProvider is IParallelizableUnitTestGeneratorProvider);
        }

        private bool CanDecorateFrom(string tagName)
        {
            return tagFilterMatcher.Match(TAG, tagName);
        }

        public void DecorateFrom(string tagName, TestClassGenerationContext generationContext)
        {
            (generationContext.UnitTestGeneratorProvider as IParallelizableUnitTestGeneratorProvider).SetTestClassParallelizable(generationContext);
        }
    }
}
