using System.Runtime.CompilerServices;

namespace BlazorBugUnittest
{
    public sealed class Test1
    {
        private static VerifySettings _verifySettings = new VerifySettings();

        [ModuleInitializer]
        public static void Initialize()
        {
            _verifySettings.UseUniqueDirectory();
            if (!VerifyDiffPlex.Initialized)
                VerifyDiffPlex.Initialize(VerifyTests.DiffPlex.OutputType.Compact);
            Verifier.UseSourceFileRelativeDirectory("Snapshots");
        }

        [Test]
        public async Task TestMethod1()
        {
            var testText = "Hello, World!";
            await Verify(testText, _verifySettings);
        }
    }
}
