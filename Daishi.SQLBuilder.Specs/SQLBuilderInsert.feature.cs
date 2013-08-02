#region Designer generated code

#region Includes

using TechTalk.SpecFlow;

#endregion

#pragma warning disable

namespace Daishi.SQLBuilder.Specs {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.2.1")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SQLBuilderInsert")]
    public partial class SQLBuilderInsertFeature {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SQLBuilderInsert.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup() {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SQLBuilderInsert", "Ensure that SQL commands are correctly applied by the SQLCommand component.", ProgrammingLanguage.CSharp, ((string[]) (null)));
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
        [NUnit.Framework.DescriptionAttribute("Insert data")]
        public virtual void InsertData() {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Insert data", ((string[]) (null)));
#line 4
            this.ScenarioSetup(scenarioInfo);
#line 5
            testRunner.Given("I have provided a SQL insert command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 6
            testRunner.When("I invoke the command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 7
            testRunner.Then("a row is added to the database", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion