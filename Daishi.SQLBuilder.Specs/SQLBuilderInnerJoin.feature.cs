#region Designer generated code

#region Includes

using TechTalk.SpecFlow;

#endregion

#pragma warning disable

namespace Daishi.SQLBuilder.Specs {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SQLBuilderInnerJoin")]
    public partial class SQLBuilderInnerJoinFeature {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SQLBuilderInnerJoin.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup() {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SQLBuilderInnerJoin", "Ensure that Inner Joins are correctly applied to SQL commands.", ProgrammingLanguage.CSharp, ((string[]) (null)));
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
        [NUnit.Framework.DescriptionAttribute("Apply an Inner Join to a SQL Command")]
        public virtual void ApplyAnInnerJoinToASQLCommand() {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Apply an Inner Join to a SQL Command", ((string[]) (null)));
#line 4
            this.ScenarioSetup(scenarioInfo);
#line 5
            testRunner.Given("I have generated a SQL Command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 6
            testRunner.And("I have applied an Inner Join to the command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 7
            testRunner.When("I invoke the joined command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 8
            testRunner.Then("the Inner Join should be applied to the returned dataset", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion