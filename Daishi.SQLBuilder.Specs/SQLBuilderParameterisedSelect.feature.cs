#region Designer generated code

#region Includes

using TechTalk.SpecFlow;

#endregion

#pragma warning disable

namespace Daishi.SQLBuilder.Specs {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SQLBuilderParameterisedSelect")]
    public partial class SQLBuilderParameterisedSelectFeature {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SQLBuilderParameterisedSelect.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup() {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SQLBuilderParameterisedSelect", "Ensures that parameterised Select commands are formatted correctly", ProgrammingLanguage.CSharp, ((string[]) (null)));
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
        [NUnit.Framework.DescriptionAttribute("Invoke parameterised Select command")]
        public virtual void InvokeParameterisedSelectCommand() {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invoke parameterised Select command", ((string[]) (null)));
#line 4
            this.ScenarioSetup(scenarioInfo);
#line 5
            testRunner.Given("I have generated a parameterised Select command", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 6
            testRunner.When("I view the raw command text", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 7
            testRunner.Then("the command text should be formatted correctly", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion