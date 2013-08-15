#region Designer generated code

#region Includes

using TechTalk.SpecFlow;

#endregion

#pragma warning disable

namespace Daishi.SQLBuilder.Specs {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SQLBuilderOutputParameters")]
    public partial class SQLBuilderOutputParametersFeature {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SQLBuilderOutputParameters.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup() {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SQLBuilderOutputParameters", "Ensures that SqpParameters applied to SQLBuilder are applied and returned as outp" +
                                                                                                                                             "ut.", ProgrammingLanguage.CSharp, ((string[]) (null)));
            testRunner.OnFeatureStart(featureInfo);
        }

        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown() {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }

        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize() {}

        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown() {
            testRunner.OnScenarioEnd();
        }

        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo) {
            testRunner.OnScenarioStart(scenarioInfo);
        }

        public virtual void ScenarioCleanup() {
            testRunner.CollectScenarioErrors();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add two output parameters to a query")]
        public virtual void AddTwoOutputParametersToAQuery() {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two output parameters to a query", ((string[]) (null)));
#line 4
            this.ScenarioSetup(scenarioInfo);
#line 5
            testRunner.Given("I have generated a SqlCommand", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 6
            testRunner.And("I have applied 2 SqlParameters to the command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 7
            testRunner.When("I invoke the parameterised command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 8
            testRunner.Then("the SqlParameters should be output with the command result", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion