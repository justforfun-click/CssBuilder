﻿using Xunit;

namespace CssBuilder.Test
{
    public class ConfigTest : TestBase
    {
        [Fact]
        public void InvalidConfigFile()
        {
            var testFolder = PrepareTestFolder("ConfigTest_InvalidConfigFileTest");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(1, exitCode);
        }

        [Fact]
        public void SingleInputNoOutputSetting()
        {
            var testFolder = PrepareTestFolder("ConfigTest_SingleInputNoOutputSetting");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b.less", "b.css", null);
            VerifyFiles(testFolder, "c.sass", "c.css", null);
        }

        [Fact]
        public void SingleInputOutputIsFile()
        {
            var testFolder = PrepareTestFolder("ConfigTest_SingleInputOutputIsFile");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", null);
            VerifyFiles(testFolder, "a.less", "out/overall.css", "body {\n  color: red;\n}\n");
        }

        [Fact]
        public void SingleInputOutputIsFolder()
        {
            var testFolder = PrepareTestFolder("ConfigTest_SingleInputOutputIsFolder");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", null);
            VerifyFiles(testFolder, "a.less", "out/a.css", "body {\n  color: red;\n}\n");
        }

        [Fact]
        public void GlobInputNoOutputSetting()
        {
            var testFolder = PrepareTestFolder("ConfigTest_GlobInputNoOutputSetting");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b/b.less", "b/b.css", "body {\n  color: blue;\n}\n");
            VerifyFiles(testFolder, "b/c/c.less", "b/c/c.css", "body {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void GlobInputOutputIsFile()
        {
            var testFolder = PrepareTestFolder("ConfigTest_GlobInputOutputIsFile");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "out/a.css", null);
            VerifyFiles(testFolder, "b/b.less", "out/b.css", null);
            VerifyFiles(testFolder, "b/c/c.less", "out/c.css", null);
            VerifyFiles(testFolder, null, "out/overall.css", "body {\n  color: red;\n}\nbody {\n  color: blue;\n}\nbody {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void GlobInputOutputIsFolder()
        {
            var testFolder = PrepareTestFolder("ConfigTest_GlobInputOutputIsFolder");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "out/a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b/b.less", "out/b.css", "body {\n  color: blue;\n}\n");
            VerifyFiles(testFolder, "b/c/c.less", "out/c.css", "body {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void MultipleConfig()
        {
            var testFolder = PrepareTestFolder("ConfigTest_MultipleConfig");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "out/overall.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b/b.less", "out/b.css", "body {\n  color: blue;\n}\n");
            VerifyFiles(testFolder, "b/c/c.less", "out/c.css", "body {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void MultipleInputNoOutputSetting()
        {
            var testFolder = PrepareTestFolder("ConfigTest_MultipleInputNoOutputSetting");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b.less", "b.css", "body {\n  color: blue;\n}\n");
            VerifyFiles(testFolder, "c.sass", "c.css", null);
        }

        [Fact]
        public void MultipleInputOutputIsFile()
        {
            var testFolder = PrepareTestFolder("ConfigTest_MultipleInputOutputIsFile");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", null);
            VerifyFiles(testFolder, "b.less", "b.css", null);
            VerifyFiles(testFolder, null, "out/overall.css", "body {\n  color: red;\n}\nbody {\n  color: blue;\n}\n");
        }


        [Fact]
        public void MultipleInputOutputIsFolder()
        {
            var testFolder = PrepareTestFolder("ConfigTest_MultipleInputOutputIsFolder");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "out/a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b/b.less", "out/b.css", null);
            VerifyFiles(testFolder, "b/c/c.less", "out/c.css", "body {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void SingleAndGlobInputNoOutputSetting()
        {
            var testFolder = PrepareTestFolder("ConfigTest_SingleAndGlobInputNoOutputSetting");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b/b.less", "b/b.css", "body {\n  color: blue;\n}\n");
            VerifyFiles(testFolder, "b/c/c.less", "b/c/c.css", "body {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void SingleAndGlobInputOutputIsFile()
        {
            var testFolder = PrepareTestFolder("ConfigTest_SingleAndGlobInputOutputIsFile");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", null);
            VerifyFiles(testFolder, "b/b.less", "b/b.css", null);
            VerifyFiles(testFolder, "b/c/c.less", "b/c/c.css", null);
            VerifyFiles(testFolder, null, "overall.css", "body {\n  color: red;\n}\nbody {\n  color: blue;\n}\nbody {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void SingleAndGlobInputOutputIsFolder()
        {
            var testFolder = PrepareTestFolder("ConfigTest_SingleAndGlobInputOutputIsFolder");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "out/a.css", "body {\n  color: red;\n}\n");
            VerifyFiles(testFolder, "b/b.less", "out/b.css", "body {\n  color: blue;\n}\n");
            VerifyFiles(testFolder, "b/c/c.less", "out/c.css", "body {\n  color: yellow;\n}\n");
        }

        [Fact]
        public void InputNotExist()
        {
            var testFolder = PrepareTestFolder("ConfigTest_InputNotExist");

            var exitCode = CssBuilder.Program.Main(new string[] { testFolder });
            Assert.Equal(0, exitCode);

            VerifyFiles(testFolder, "a.less", "a.css", null);
            VerifyFiles(testFolder, "b.less", "b.css", null);
            VerifyFiles(testFolder, "c.sass", "c.css", null);
        }
    }
}
