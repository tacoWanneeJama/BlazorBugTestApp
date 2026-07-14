using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

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
                VerifyDiffPlex.Initialize();
            Verifier.UseSourceFileRelativeDirectory("Snapshots");
        }

        [Test]
        [Arguments("2025-01-04 03:00:00", "004000000603DC41")]
        [Arguments("2026-05-16 03:00:00", "0040000014824483")]

        public async Task TestMethod1(DateTime date, string tag)
        {
            var testText = "Hello, World!";
            List<RegistrationsDayDto> testList = new() {
                new RegistrationsDayDto { Date = DateOnly.FromDateTime(date), Count = 42 },
                new RegistrationsDayDto { Date = DateOnly.FromDateTime(date), Count = 43 }
            };

            var hashDb = CalcualteObjectHash(tag);
            await Assert.That(testList).IsNotNull();
            var settings = GetVerifySettings();
            await Verify(testList, settings);
        }

        public static VerifySettings GetVerifySettings()
        {
            var settings = new VerifySettings();
            settings.UseUniqueDirectory();
            //settings.UseDirectory("C:\\Temp");
            return settings;
        }

        private string CalcualteObjectHash(object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            byte[] jsonBytes = Encoding.ASCII.GetBytes(jsonString);

            using (SHA256 mySHA256 = SHA256.Create())
            {
                mySHA256.ComputeHash(jsonBytes);
                string hashString = Convert.ToBase64String(mySHA256.Hash);
                return hashString;
            }
        }
    }
}
