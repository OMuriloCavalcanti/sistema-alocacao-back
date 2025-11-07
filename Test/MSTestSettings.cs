using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 2, Scope = ExecutionScope.ClassLevel)]

namespace Tests
{
    [TestClass]
    public class MSTestSettings
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Executa antes de todos os testes
        }

        [AssemblyCleanup]
        public static void AssemblyClean()
        {
            // Executa depois de todos os testes
        }
    }
}
