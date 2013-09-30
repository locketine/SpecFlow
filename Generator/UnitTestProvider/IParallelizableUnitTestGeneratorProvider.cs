using System;
using System.Collections.Generic;
using System.Linq;

namespace TechTalk.SpecFlow.Generator.UnitTestProvider
{
    public interface IParallelizableUnitTestGeneratorProvider
    {
        void SetTestClassParallelizable(TestClassGenerationContext generationContext);
    }
}
