using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Utils;

namespace TechTalk.SpecFlow.Generator.UnitTestProvider
{
    public class MbUnit3TestGeneratorProvider : MbUnitTestGeneratorProvider, IParallelizableUnitTestGeneratorProvider
    {
        public MbUnit3TestGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
        }

        public override void SetRowTest(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            CodeDomHelper.AddAttribute(testMethod, TEST_ATTR);
            CodeDomHelper.AddAttribute(testMethod, DESCRIPTION_ATTR, scenarioTitle);
        }

        public void SetTestClassParallelizable(TestClassGenerationContext generationContext)
        {
            CodeDomHelper.AddAttribute(generationContext.TestClass, "MbUnit.Framework.ParallelizableAttribute", "MbUnit.Framework.TestScope.Descendants");
        }
    }
}