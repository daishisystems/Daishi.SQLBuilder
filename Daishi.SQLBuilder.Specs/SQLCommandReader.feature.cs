#region Designer generated code

#region Includes

using TechTalk.SpecFlow;

#endregion

#pragma warning disable

namespace Daishi.SQLBuilder.Specs {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SQLCommandReader")]
    public partial class SQLCommandReaderFeature {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SQLCommandReader.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup() {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SQLCommandReader", "Ensure that datasets returned from SQLCommand in SQLCommandType.Reader are persis" +
                                                                                                                                   "ted to a SQLDataReader", ProgrammingLanguage.CSharp, ((string[]) (null)));
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
        [NUnit.Framework.DescriptionAttribute("Read data")]
        public virtual void ReadData() {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read data", ((string[]) (null)));
#line 4
            this.ScenarioSetup(scenarioInfo);
#line 5
            testRunner.Given("I have invoked a select command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 6
            testRunner.And("SQLCommand is in read-mode", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 7
            testRunner.When("the requested data is returned", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 8
            testRunner.Then("the rows are persisted to a SQLDataReader", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion