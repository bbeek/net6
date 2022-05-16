using System.Runtime.Versioning;

namespace Demoapi;

public class Platform
{
    [SupportedOSPlatform("linux")]
    public void SupportedOnLinux() { }

    [SupportedOSPlatform("windows7.0")]
    [SupportedOSPlatform("ios14.0")]
    public void SupportedOnWindowsAndIos14() { }

    [SupportedOSPlatform("Linux")]
    [SupportedOSPlatform("ios14.0")]
    public void SupportedOnLinuxAndIos14() { }

    [SupportedOSPlatformGuard("linux")]
    [SupportedOSPlatformGuard("ios14.0")]
    private readonly bool _isLinuxIOS14 = OperatingSystem.IsLinux() || OperatingSystem.IsIOSVersionAtLeast(14);

    [SupportedOSPlatformGuard("windows7.0")]
    private readonly bool _isWindows7OrAbove = OperatingSystem.IsWindowsVersionAtLeast(7);

    public void Caller()
    {
        SupportedOnLinux();

        if (OperatingSystem.IsIOSVersionAtLeast(14))
        {
            SupportedOnWindowsAndIos14();
        }

        if (OperatingSystem.IsWindowsVersionAtLeast(7))
        {
            SupportedOnWindowsAndIos14();
        }

        // The warnings are avoided using platform guard methods.
        if (_isLinuxIOS14)
        {
            SupportedOnLinuxAndIos14();
        }

        if (_isWindows7OrAbove)
        {
            SupportedOnWindowsAndIos14();
        }
    }
}