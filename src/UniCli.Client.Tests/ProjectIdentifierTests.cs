using System.Runtime.InteropServices;

namespace UniCli.Client.Tests;

public class NormalizePathForHashTests
{
    [SkippableFact]
    public void BackslashesAreReplacedWithForwardSlashes_Unix()
    {
        Skip.If(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        Assert.Equal("C:/Users/dev/MyProject/Assets", ProjectIdentifier.NormalizePathForHash(@"C:\Users\dev\MyProject\Assets"));
    }

    [SkippableFact]
    public void BackslashesAreReplacedWithForwardSlashes_Windows()
    {
        Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        Assert.Equal("c:/users/dev/myproject/assets", ProjectIdentifier.NormalizePathForHash(@"C:\Users\dev\MyProject\Assets"));
    }

    [SkippableFact]
    public void ForwardSlashesArePreserved_Unix()
    {
        Skip.If(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        Assert.Equal("C:/Users/dev/MyProject/Assets", ProjectIdentifier.NormalizePathForHash("C:/Users/dev/MyProject/Assets"));
    }

    [SkippableFact]
    public void ForwardSlashesArePreserved_Windows()
    {
        Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        Assert.Equal("c:/users/dev/myproject/assets", ProjectIdentifier.NormalizePathForHash("C:/Users/dev/MyProject/Assets"));
    }

    [SkippableFact]
    public void MixedSeparatorsAreNormalized_Unix()
    {
        Skip.If(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        Assert.Equal("C:/Users/dev/MyProject/Assets", ProjectIdentifier.NormalizePathForHash(@"C:\Users/dev\MyProject/Assets"));
    }

    [SkippableFact]
    public void MixedSeparatorsAreNormalized_Windows()
    {
        Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
        Assert.Equal("c:/users/dev/myproject/assets", ProjectIdentifier.NormalizePathForHash(@"C:\Users/dev\MyProject/Assets"));
    }
}

public class GetProjectHashTests
{
    [Fact]
    public void SamePathWithDifferentSeparators_ProducesSameHash()
    {
        var hashForward = ProjectIdentifier.GetProjectHash(
            ProjectIdentifier.NormalizePathForHash("C:/Users/dev/MyProject/Assets"));
        var hashBackslash = ProjectIdentifier.GetProjectHash(
            ProjectIdentifier.NormalizePathForHash(@"C:\Users\dev\MyProject\Assets"));

        Assert.Equal(hashForward, hashBackslash);
    }

    [Fact]
    public void DifferentPaths_ProduceDifferentHashes()
    {
        var hash1 = ProjectIdentifier.GetProjectHash(
            ProjectIdentifier.NormalizePathForHash("C:/Users/dev/ProjectA/Assets"));
        var hash2 = ProjectIdentifier.GetProjectHash(
            ProjectIdentifier.NormalizePathForHash("C:/Users/dev/ProjectB/Assets"));

        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void HashIsEightCharacters()
    {
        var hash = ProjectIdentifier.GetProjectHash(
            ProjectIdentifier.NormalizePathForHash("/Users/dev/MyProject/Assets"));

        Assert.Equal(8, hash.Length);
    }

    [Fact]
    public void HashIsLowercaseHex()
    {
        var hash = ProjectIdentifier.GetProjectHash(
            ProjectIdentifier.NormalizePathForHash("/Users/dev/MyProject/Assets"));

        Assert.Matches("^[0-9a-f]{8}$", hash);
    }
}
